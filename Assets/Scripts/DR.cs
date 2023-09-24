using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UnityEngine;


public class DR
{
    public int DR_ID { get; set; }
    public int DR_CorrenteNom { get; set; }
    public string DR_Descr { get; set; }

    public DR(int dr_ID, int dr_correntenom, string dr_descr)
    {
        DR_ID = dr_ID;
        DR_CorrenteNom = dr_correntenom;
        DR_Descr = dr_descr;
    }

    public static List<DR> GetDRsFromDB(string connectionString)
    {
        List<DR> drs = new List<DR>();

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM [dbo].[DR]";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int dr_ID = reader.GetInt32(0);
                            int dr_CorrenteNom = reader.GetInt32(1);
                            string dr_Descr = reader.GetString(2);

                            DR dr = new DR(dr_ID, dr_CorrenteNom, dr_Descr);

                            drs.Add(dr);
                        }
                    }
                }
            }
        }
        catch (SqlException e)
        {
            Debug.Log(e.ToString());
        }

        return drs;
    }
}


