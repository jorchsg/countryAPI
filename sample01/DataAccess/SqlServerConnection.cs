using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

class SqlServerConnection
{
    private static SqlServerConnection instance;
    private string connectionString = "Data Source=DESKTOP-I02R4ND; Initial Catalog=world2021; User Id=sa; Integrated Security = true;";
    private SqlConnection connection;

    //constructor
    private SqlServerConnection()
    {
        if (connection == null) connection = new SqlConnection(connectionString);
    }

    //get connection instance
    public static SqlServerConnection GetConnection()
    {
        if (instance == null) instance = new SqlServerConnection();
        return instance;
    }

    //open connection
    private bool OpenConnection()
    {
        bool open = false;
        try
        {
            connection.Open();
            open = true;
        }
        catch (SqlException ex)
        {
            Console.WriteLine(ex.GetType().ToString() + " : " + ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.GetType().ToString() + " : " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.GetType().ToString() + " : " + ex.Message);
        }
        return open;
    }

    //execute query
    public DataTable ExecuteQuery(SqlCommand command)
    {
        DataTable table = new DataTable();
        if (OpenConnection())
        {
            command.Connection = connection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            try
            {
                adapter.Fill(table);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.GetType().ToString() + " : " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().ToString() + " : " + ex.Message);
            }
            connection.Close();
        }
        return table;
    }
}
