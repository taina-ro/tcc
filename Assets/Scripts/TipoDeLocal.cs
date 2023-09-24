using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UnityEngine;


public class TipoDeLocal
{
    public int TipoDeLocal_ID { get; set; }
    public string TipoDeLocal_Descr { get; set; }

    public TipoDeLocal(int tipodelocal_ID, string tipodelocal_descr)
    {
        TipoDeLocal_ID = tipodelocal_ID;
        TipoDeLocal_Descr = tipodelocal_descr;
    }
    public static List<TipoDeLocal> GetTipoDeLocalFromDB(string connectionString)
    {
        List<TipoDeLocal> tipodelocais = new List<TipoDeLocal>();

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM [dbo].[TipoDeLocal]";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int tipodelocal_ID = reader.GetInt32(0); // ID
                            string tipodelocal_Desc = reader.GetString(1);

                            TipoDeLocal tipodelocal = new TipoDeLocal(tipodelocal_ID, tipodelocal_Desc);
                            tipodelocais.Add(tipodelocal);
                        }
                    }
                }
            }
        }
        catch (SqlException e)
        {
            Debug.Log(e.ToString());
        }

        return tipodelocais;
    }
}