using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segmento
{
    public int Ponto_ID_A { get; set; }
    public int Ponto_ID_B { get; set; }
    public int TipoDeEletroduto_ID { get; set; }

    public Segmento(int ponto_id_a, int ponto_id_b, int tipodeeletroduto_id) 
    {
        Ponto_ID_A = ponto_id_a;
        Ponto_ID_B = ponto_id_b;
        TipoDeEletroduto_ID = tipodeeletroduto_id;
    }

}
