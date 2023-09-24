using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circuito
{
    public int Circuito_ID { get; set; }
    public int Circuito_Tensao { get; set; }
    public string Circuito_Descr { get; set; }
    public int DR_ID { get; set; }
    public int Residencia_ID { get; set; }
    public int Circuito_NumCondutores { get; set; }
    public double Circuito_SecaoFase { get; set; }
    public double Circuito_SecaoProtecao { get; set; }

    public Circuito (int circuito_ID, int circuito_tensao, string circuito_descr, int dr_ID, int residencia_ID, int circuito_numcondutores,
        double circuito_secaofase, double circuito_secaoprotecao) 
    {
        Circuito_ID = circuito_ID;
        Circuito_Tensao = circuito_tensao;
        Circuito_Descr = circuito_descr;
        DR_ID = dr_ID;
        Residencia_ID = residencia_ID;
        Circuito_NumCondutores = circuito_numcondutores;
        Circuito_SecaoFase = circuito_secaofase;
        Circuito_SecaoProtecao = circuito_secaoprotecao;
    }

}
