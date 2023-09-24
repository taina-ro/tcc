using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carga
{
    public int Carga_ID { get; set; }
    public int Ponto_ID { get; set; }
    public int Circuito_ID { get; set; }
    public int Carga_Pot { get; set; }
    public int TipoDeCarga_ID { get; set; }

    public Carga(int carga_ID, int ponto_ID, int circuito_ID, int carga_pot, int tipodecarga_ID)
    {
        Carga_ID = carga_ID;
        Ponto_ID = ponto_ID;
        Circuito_ID = circuito_ID;
        Carga_Pot = carga_pot;
        TipoDeCarga_ID = tipodecarga_ID;
    }

}