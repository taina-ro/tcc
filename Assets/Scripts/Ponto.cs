using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ponto
{
    public int Ponto_ID { get; set; }
    public double Ponto_PosicaoX { get; set; }
    public double Ponto_PosicaoY { get; set; }
    public double Ponto_PosicaoZ { get; set; }
    public int Local_ID { get; set; }
    public int TipoDePonto_ID { get; set; }

    public Ponto(int ponto_ID, double ponto_posicaoX, double ponto_posicaoY, double ponto_posicaoZ, int local_ID, int tipodeponto_ID)
    {
        Ponto_ID = ponto_ID;
        Ponto_PosicaoX = ponto_posicaoX;
        Ponto_PosicaoY = ponto_posicaoY;
        Ponto_PosicaoZ = ponto_posicaoZ;
        Local_ID = local_ID;
        TipoDePonto_ID = tipodeponto_ID;

    }

}
