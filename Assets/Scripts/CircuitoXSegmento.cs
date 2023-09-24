using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitoXSegmento
{
    public int Circuito_ID { get; set; }
    public int Ponto_ID_A { get; set; }
    public int Ponto_ID_B { get; set; }

    public CircuitoXSegmento(int circuito_id, int ponto_id_a, int ponto_id_b) 
    {
        Circuito_ID = circuito_id;
        Ponto_ID_A = ponto_id_a;
        Ponto_ID_B = ponto_id_b;
    }

}
