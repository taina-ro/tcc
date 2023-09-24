using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipoDePonto
{
    public int TipoDePonto_ID { get; set; }
    public byte[] TipoDePonto_Imagem { get; set; }
    public string TipoDePonto_Descr { get; set; }

    public TipoDePonto (int tipodeponto_id, byte[] tipodeponto_imagem, string tipodeponto_descr)
    {
        TipoDePonto_ID = tipodeponto_id;
        TipoDePonto_Imagem = tipodeponto_imagem;
        TipoDePonto_Descr  = tipodeponto_descr;

    }

}
