using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UnityEngine;

public class TipoDeCarga
{
    public int TipoDeCarga_ID { get; set; }
    public int TipoDeCarga_Tensao { get; set; }
    public int TipoDeCarga_Pot { get; set; }
    public string TipoDeCarga_Descr { get; set; }

    public TipoDeCarga(int tipodecarga_id, int tipodecarga_tensao, int tipodecarga_pot, string tipodecarga_descr)
    {
        TipoDeCarga_ID = tipodecarga_id;
        TipoDeCarga_Tensao = tipodecarga_tensao;
        TipoDeCarga_Pot = tipodecarga_pot;
        TipoDeCarga_Descr = tipodecarga_descr;
    }

    public static List<TipoDeCarga> GetTipoDeCargaFromDB(string connectionString)
    {
        List<TipoDeCarga> tipodecargas = new List<TipoDeCarga>();

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM [dbo].[TipoDeCarga]";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int tipodecarga_ID = reader.GetInt32(0); // ID
                            int tipodecarga_Tensao = reader.GetInt32(1); // Tensao de alimentaçao: 127V ou 220V
                            int tipodecarga_Pot = reader.GetInt32(2); // Potencia do Equipamento e VA
                            string tipodecarga_Desc = reader.GetString(3); // Chuveiro, geladeira, iluminação

                            TipoDeCarga tipodecarga = new TipoDeCarga(tipodecarga_ID, tipodecarga_Tensao, tipodecarga_Pot, tipodecarga_Desc);
                            tipodecargas.Add(tipodecarga);
                        }
                    }
                }
            }
        }
        catch (SqlException e)
        {
            Debug.Log(e.ToString());
        }

        return tipodecargas;
    }

}