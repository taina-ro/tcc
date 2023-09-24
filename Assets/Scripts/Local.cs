using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UnityEngine;

public class Local
{
    public int Local_ID { get; set; }
    public string Local_Descr { get; set; }
    public double Local_Area { get; set; }
    public double Local_Perimetro { get; set; }
    public int TipoDeLocal_ID { get; set; }
    public int Residencia_ID { get; set; }

    public Local(int local_ID, string local_descr, double local_area, double local_perimetro, int tipodelocal_ID, int residencia_ID)
    {
        Local_ID = local_ID;
        Local_Descr = local_descr;
        Local_Area = local_area;
        Local_Perimetro = local_perimetro;
        TipoDeLocal_ID = tipodelocal_ID;
        Residencia_ID = residencia_ID;
    }
    public static List<Local> GetLocalFromDB(string connectionString)
    {
        List<Local> locais = new List<Local>();

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM [dbo].[Local]";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int local_ID = reader.GetInt32(0); // ID
                            string local_Desc = reader.GetString(1); // Copa, cozinha, banheiro...

                            // verifica se o valor é nulo no banco de dados e substitui por zero
                            double local_area = reader.IsDBNull(2) ? 0.0 : reader.GetDouble(2);
                            double local_perimetro = reader.IsDBNull(3) ? 0.0 : reader.GetDouble(3);
                            
                            int tipodelocal_id = reader.GetInt32(4);
                            int residencia_id = reader.GetInt32(5);

                            Local local = new Local(local_ID, local_Desc, local_area, local_perimetro, tipodelocal_id, residencia_id);
                            locais.Add(local);
                        }
                    }
                }
            }
        }
        catch (SqlException e)
        {
            Debug.Log(e.ToString());
        }

        return locais;
    }
}
