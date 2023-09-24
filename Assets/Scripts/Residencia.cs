using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UnityEngine;

//public class RoomData
//{
//    public int idResidencia;
//    public string name;
//    public float area;
//    public float perimeter;
//    public float PotenciaIluminacao;

//    public RoomData(int _idResidencia, string _name, float _area, float _perimeter)
//    {
//        idResidencia = _idResidencia;
//        name = _name;
//        area = _area;
//        perimeter = _perimeter;
//    }

//    public float PontosDeLuz()
//    {
//        const float potenciaInicial = 100f; // Potência inicial para os primeiros 6m²
//        const float potenciaPorMetrosQuadradosExtras = 60f; // Potência adicional a cada 4m²

//        if (area <= 6f)
//        {
//            return potenciaInicial;
//        }
//        else
//        {
//            float areaExcedente = area - 6f;
//            float potenciaAdicional = Mathf.Floor(areaExcedente / 4f) * potenciaPorMetrosQuadradosExtras;
//            PotenciaIluminacao = potenciaInicial + potenciaAdicional;
//            return PotenciaIluminacao;
//        }
//    }
//}

public class Residencia
{
    public int Residencia_ID { get; set; }
    public double Residencia_Area { get; set; }
    public double Residencia_Perimetro { get; set; }
    public int Residencia_NumFases { get; set; }
    public int Residencia_NumPav { get; set; }
    //public string Residencia_PadraoEnergia { get; set; }
    //public string Residencia_CxDist { get; set; }
    public string Residencia_Descr { get; set; }


    public Residencia(int residencia_ID, double residencia_area, double residencia_perimetro, int residencia_numfases, 
        int residencia_numpav, string residencia_descr)
    {
        Residencia_ID = residencia_ID;
        Residencia_Area = residencia_area;
        Residencia_Perimetro = residencia_perimetro;
        Residencia_NumFases = residencia_numfases;
        Residencia_NumPav = residencia_numpav;
        Residencia_Descr = residencia_descr;
    }

    public static List<Residencia> GetResidenciasFromDB(string connectionString)
    {
        List<Residencia> residencias = new List<Residencia>();

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM [dbo].[Residencia]";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int residencia_ID = reader.GetInt32(0); // ID
                            double residencia_Area = reader.GetDouble(1); // Area da Residencia
                            double residencia_Perimetro = reader.GetDouble(2); // Perimetro da Residencia
                            int residencia_NumFases = reader.GetInt32(3); // 1- Monofasico e 2- Bifasico
                            int residencia_NumPavimentos = reader.GetInt32(4); // Numero de andares
                            //string residencia_PadraoEnergia = reader.GetString(5); //
                            //string residencia_CxDist = reader.GetString(6);
                            string residencia_Desc = reader.GetString(5);

                            //Residencia residencia = new Residencia(residencia_ID, residencia_Area, residencia_Perimetro, residencia_NumFases,
                            //   residencia_NumPavimentos, residencia_PadraoEnergia, residencia_CxDist, residencia_Desc);

                            Residencia residencia = new Residencia(residencia_ID, residencia_Area, residencia_Perimetro, residencia_NumFases,
                               residencia_NumPavimentos, residencia_Desc);

                            residencias.Add(residencia);
                        }
                    }
                }
            }
        }
        catch (SqlException e)
        {
            Debug.Log(e.ToString());
        }

        return residencias;
    }
}
