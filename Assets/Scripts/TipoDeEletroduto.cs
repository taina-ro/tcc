using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipoDeEletroduto
{
    public int TipoDeEletroduto_ID { get; set; }
    public int TipoDeEletroduto_TamNom { get; set; }


    public TipoDeEletroduto (int tipodeeletroduto_id, int tipodeeletroduto_tamnom)
    {
        TipoDeEletroduto_ID = tipodeeletroduto_id;
        TipoDeEletroduto_TamNom = tipodeeletroduto_tamnom;
    }
}
