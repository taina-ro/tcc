//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Manager : MonoBehaviour
{

    List<Residencia> residencias = new List<Residencia>();
    List<DR> drs = new List<DR>();
    List<TipoDeLocal> tiposdelocais = new List<TipoDeLocal>();
    List<Local> locais = new List<Local>();
    List<TipoDeCarga> cargas = new List<TipoDeCarga>();
    public double PotenciaIluminacao;
    public double PotenciaDeIluminacaoTotal = 0.0;
    public double PotenciaPTUG;
    public double PotenciaPTUGTotal = 0.0;


    void Start()
    {
        // Inicialize a lista de residências
        string connectionString = "Data Source=DESKTOP-EC0DF6O;Initial Catalog=Dimensionamento;User ID=sa;Password=Tro2211Taina";
        residencias = Residencia.GetResidenciasFromDB(connectionString); // obtem os dados da tabela residencia
        drs = DR.GetDRsFromDB(connectionString); // obtem os dados da tabela DR
        tiposdelocais = TipoDeLocal.GetTipoDeLocalFromDB(connectionString); // obtem os dados da tabela TipoDeLocal
        locais = Local.GetLocalFromDB(connectionString); // obtem os dados da tabela Local
        cargas = TipoDeCarga.GetTipoDeCargaFromDB(connectionString); // obtem os dados da tabela TipoDeCarga

        SaveToCSV("C:/Users/taina/segundaVersaoTcc/Assets/Tests/Out/results.csv");
        
    }

    //void OnGUI()
    //{
    //    GUILayout.BeginVertical();
    //    int i = 0;

    //    foreach (TipoDeCarga carga in cargas)
    //    {
    //        Rect position = new Rect(i * 20, i * 20, 100, 20);
    //        GUI.Label(position, "TipoDeCarga_ID: " + carga.TipoDeCarga_ID.ToString());
    //        i++;
    //    }

    //    GUILayout.EndVertical();
    //}

    public double PontosDeLuz(double area)
    {
        const double potenciaInicial = 100; // Potência inicial para os primeiros 6m²
        const double potenciaPorMetrosQuadradosExtras = 60; // Potência adicional a cada 4m²

        if (area <= 6f)
        {
            return potenciaInicial;
        }
        else
        {
            double areaExcedente = area - 6;
            double potenciaAdicional = (double)Mathf.Floor((float)areaExcedente / 4f) * potenciaPorMetrosQuadradosExtras;
            PotenciaIluminacao = potenciaInicial + potenciaAdicional;
            return PotenciaIluminacao;
        }
    }

    public double QuantidadePTUG(double area, double perimetro, string tipodecomodo)
    {
        double qntInicial = 1;

        if (area < 6f)
        {
          qntInicial = 1;
        }
        else
        {
            if (tipodecomodo.Contains("Sala") || tipodecomodo.Contains("Dormitorio"))
            {
               
                double perimetroexcedente = perimetro - 5;

                Debug.Log(perimetroexcedente.ToString());

                if(perimetroexcedente > 0)
                {
                    double pontosExtras = (double)Mathf.Floor((float)perimetroexcedente / 5f);
                    qntInicial += pontosExtras;
                }
            }
            else if (tipodecomodo.Contains("Cozinha") || tipodecomodo.Contains("Copa") || tipodecomodo.Contains("Copa-Cozinha") || tipodecomodo.Contains("Area de Servico") || tipodecomodo.Contains("Lavanderia"))
            {

                qntInicial = Mathf.FloorToInt((float)perimetro / 3.5f);
            }
            else if (tipodecomodo.Contains("Varanda") || tipodecomodo.Contains("Banheiro") || tipodecomodo.Contains("Hall") || tipodecomodo.Contains("Area Externa"))
            {
                qntInicial = 1;
            }
            else
            {
                // Outros tipos de cômodos
                return 0; // Não se encaixa em nenhuma regra, 0 pontos de tomada
            }

        }
        return qntInicial*100;
    }

    void SaveToCSV(string filePath)
    {

        if (File.Exists(filePath))
        {
            // Se o arquivo existir, exclua-o para substituí-lo pelo novo
            File.Delete(filePath);
        }

        // Crie um arquivo CSV e um StreamWriter para escrever nele
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            // Escreva o cabeçalho do CSV
            writer.WriteLine("Dependencia,Area, Perimetro, Potencia de Iluminacao, PTUG");

            // Escreva os dados de cada local
            foreach (Local local in locais)
            {
                // Calcule a potência de iluminação
                double areaDoLocal = local.Local_Area; // Substitua pelo atributo correto
                double potenciaDeIluminacao = PontosDeLuz(areaDoLocal);
                PotenciaDeIluminacaoTotal = PotenciaDeIluminacaoTotal + potenciaDeIluminacao;

                double quantidadedeptug = QuantidadePTUG(areaDoLocal, local.Local_Perimetro, local.Local_Descr);
                // Escreva os dados no formato CSV
                string line = $"{local.Local_Descr},{areaDoLocal}, {local.Local_Perimetro},{potenciaDeIluminacao}, {quantidadedeptug}";
                writer.WriteLine(line);
            }

            string linetotal = $"{"Total"}, {0}, {0},  {PotenciaDeIluminacaoTotal}, {0}, {0}, {0}, {0} ";
            writer.WriteLine(linetotal);


        }
        Debug.Log("Dados salvos em arquivo CSV: " + filePath);
    }
}
