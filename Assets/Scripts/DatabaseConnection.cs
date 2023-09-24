//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System.Data.SqlClient;
//using UnityEngine.UI;



//public class GenerateLabels : MonoBehaviour
//{

//    // after the sql query is executed we will have a filled users array
//    //List users = new List();
//    List<User> users = new List<User>();
//    // Use this for initialization
//    void Start()
//    {
//        // initialize global users array
//        users = ConnectToDB();
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }
//    void OnGUI()
//    {
//        int i = 0;
//        // create a cube for each user
//        foreach (User user in users)
//        {
//            Rect position = new Rect(i * 20, i * 20, 100, 20);
//            GUI.Label(position, user.Name);
//            i++;
//        }
//    }

//    // function to connect to the db and the users list
//    List<User> ConnectToDB()
//    {
//        //List users = new List();
//        List<User> users = new List<User>();
//        // Build connection string
//        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
//        builder.DataSource = "DESKTOP-EC0DF6O";
//        builder.UserID = "sa";
//        builder.Password = "Tro2211Taina";
//        builder.InitialCatalog = "Dimensionamento";
//        try
//        {
//            // connect to the databases
//            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
//            {
//                // if open then the connection is established
//                connection.Open();
//                Debug.Log("connection established");
//                // sql command
//                string sql = "SELECT MAX(u.[Name]), " +
//                    "MAX(u.[AboutMe]), " +
//                    "MAX(u.[UserPrincipalName]), " +
//                    "string_agg(s.[Name], ', '), " +
//                    "u.Id FROM [dbo].[Users] u " +
//                    "inner join [dbo].[UserSkills] us " +
//                    "on us.UserId = u.Id " +
//                    "inner join [dbo].[Skills] s " +
//                    "on us.SkillId = s.Id " +
//                    "group by u.Id";
//                // execute sql command
//                using (SqlCommand command = new SqlCommand(sql, connection))
//                {
//                    // read
//                    using (SqlDataReader reader = command.ExecuteReader())
//                    {
//                        // each line in the output
//                        while (reader.Read())
//                        {
//                            // to avoid SqlNullValueException
//                            if (!reader.IsDBNull(0)
//                                & !reader.IsDBNull(1)
//                                & !reader.IsDBNull(3))
//                            {
//                                // Skills list to be attached to each user object
//                                //List skills = new List();
//                                List<Skill> skills = new List<Skill>();
//                                // get output parameters
//                                string username = reader.GetString(0);
//                                string aboutString = reader.GetString(1);
//                                string skillsString = reader.GetString(3);
//                                // as we are getting a list of skills as 
//                                // a single string delimited by comma
//                                // we split the string
//                                string[] skillsList = skillsString.Split(',');
//                                // we now iterate through each skill to initialize our
//                                // skill object and put it into skills list
//                                foreach (string skillName in skillsList)
//                                {
//                                    // initialize a skill object with a trimmed string
//                                    Skill skill = new Skill(skillName.Trim());
//                                    // append to the skills array
//                                    skills.Add(skill);
//                                }
//                                // initialize User oobject
//                                User user = new User(username.Trim(), aboutString.Trim(), skills);
//                                users.Add(user);
//                            }
//                        }
//                    }
//                }
//            }
//        }
//        catch (SqlException e)
//        {
//            Debug.Log(e.ToString());
//        }
//        return users;
//    }
//}

//// init class for skill to create an array list of skills for a user
//public class Skill
//{
//    public string Name { get; set; }
//    public Skill(string Name)
//    {
//        this.Name = Name;
//    }
//}

//// init class for User (that is shown on the cube)
//public class User
//{
//    public string Name { get; set; }
//    public string About { get; set; }
//    //public List Skills { get; set; }
//    public List<Skill> Skills { get; set; }

//    public User(string Name, string About, List<Skill> Skills)
//    {
//        this.Name = Name;
//        this.About = About;
//        this.Skills = Skills;
//    }

//    public override string ToString()
//    {
//        return "Person: " + this.Name + " About me: " + this.About;
//    }
//}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System.Data;
//using System.Data.SqlClient;

//public class SQLConnection : MonoBehaviour
//{
//    // String de conexão com o banco de dados
//    private string connectionString = "Data Source=DESKTOP-EC0DF6O;Initial Catalog=Dimensionamento;User ID=sa;Password=Tro2211Taina";

//    void Start()
//    {
//        // Cria uma conexão com o banco de dados
//        SqlConnection connection = new SqlConnection(connectionString);

//        try
//        {
//            // Abre a conexão
//            connection.Open();

//            // Execute consultas SQL ou operações no banco de dados aqui
//            Debug.Log("Banco de dados conectado!");

//            // Feche a conexão quando terminar
//            connection.Close();
//        }
//        catch (SqlException e)
//        {
//            Debug.LogError("Erro ao conectar ao banco de dados: " + e.Message);
//        }
//    }
//}



// FUNCIONA
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System.Data.SqlClient;
//using UnityEngine.UI;

//public class GenerateLabels : MonoBehaviour
//{
//    List<Residencia> residencias = new List<Residencia>();

//    // Use this for initialization
//    void Start()
//    {
//        // Inicialize a lista de residências
//        residencias = GetResidenciasFromDB();
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }

//    void OnGUI()
//    {
//        int i = 0;
//        // Crie uma exibição para cada residência
//        foreach (Residencia residencia in residencias)
//        {
//            Rect position = new Rect(i * 20, i * 20, 100, 20);
//            GUI.Label(position, "Residencia_ID: " + residencia.Residencia_ID.ToString() +
//                "Residencia_Area:" + residencia.Residencia_Area.ToString() + "Residencia_Perim:" + residencia.Residencia_Perimetro.ToString());

//            i++;
//        }
//    }

//    List<Residencia> GetResidenciasFromDB()
//    {
//        List<Residencia> residencias = new List<Residencia>();

//        string connectionString = "Data Source=DESKTOP-EC0DF6O;Initial Catalog=Dimensionamento;User ID=sa;Password=Tro2211Taina";

//        try
//        {
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                connection.Open();
//                Debug.Log("Conexão estabelecida");

//                // Consulta SQL para selecionar os dados da tabela "Residencia"
//                string sql = "SELECT * FROM [dbo].[Residencia]";

//                using (SqlCommand command = new SqlCommand(sql, connection))
//                {
//                    using (SqlDataReader reader = command.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {
//                            // Ler os valores das colunas da tabela "Residencia"
//                            int residencia_ID = reader.GetInt32(0);
//                            double residencia_Area = reader.GetDouble(1);
//                            double residencia_Perimetro = reader.GetDouble(2);
//                            int residencia_NumFases = reader.GetInt32(3);
//                            int residencia_NumPavimentos = reader.GetInt32(4);
//                            string residencia_PadraoEnergia = reader.GetString(5);
//                            string residencia_CxDist = reader.GetString(6);
//                            string residencia_Desc = reader.GetString(7);

//                            Residencia residencia = new Residencia(residencia_ID, residencia_Area, residencia_Perimetro, residencia_NumFases,
//                               residencia_NumPavimentos, residencia_PadraoEnergia, residencia_CxDist, residencia_Desc);

//                            residencias.Add(residencia);
//                        }
//                    }
//                }
//            }
//        }
//        catch (SqlException e)
//        {
//            Debug.Log(e.ToString());
//        }
//        return residencias;
//    }

//}

//using System.Collections;
//using System.Data;
//using System.Data.SqlClient;
//using UnityEngine;

//public class DatabaseConnection : MonoBehaviour
//{
//    //private static readonly string connectionString = "Data Source=DESKTOP-EC0DF6O;Initial Catalog=Dimensionamento;User ID=sa;Password=Tro2211Taina";

//    public static IDbConnection GetConnection(string connectionString)
//    {
//        SqlConnection connection = new SqlConnection(connectionString);
//        connection.Open();
//        return connection;
//    }
//}



