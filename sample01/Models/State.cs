using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


public class State
{
    #region properties

    public int Id { get; set; }
    public string Id_state { get; set; }
    public string Name { get; set; }

    #endregion

    #region constructors

    public State()
    {
        Id = 0;
        Id_state = "";
        Name = "";
    }

    public State(int id)
    {
        string query = "select id, id_state, name from states where id=@id order by name";
        SqlCommand command = new SqlCommand(query);
        command.Parameters.AddWithValue("@id", id);
        DataTable table = SqlServerConnection.GetConnection().ExecuteQuery(command);
        if (table.Rows.Count > 0)
        {
            DataRow row = table.Rows[0];
            Id = (int)row["id"];
            Id_state = (string)row["id_state"];
            Name = (string)row["name"];
        }
        else
            throw new RecordNotFoundException(GetType().ToString(), id.ToString());
    }
    public State(int id, string id_country, string name)
    {
        Id = id;
        Id_state = id_country;
        Name = name;
    }

    #endregion

    #region instance methods

    public List<City> GetCities(int fk_state)
    {
        List<City> list = new List<City>();

        string query = "select id, id_city, name from cities where fk_state=@fk_state order by name";
        SqlCommand command = new SqlCommand(query);
        command.Parameters.AddWithValue("@fk_state", fk_state);
        DataTable table = SqlServerConnection.GetConnection().ExecuteQuery(command);
        foreach (DataRow row in table.Rows)
        {
            int id = (int)row["id"];
            string id_city = (string)row["id_city"];
            string name = (string)row["name"];
            list.Add(new City(id, id_city, name));
        }

        //return list
        return list;
    }

    #endregion

    #region class methods

    public static List<State> GetAll()
    {
        //Create Empty
        List<State> list = new List<State>();

        //Populate List

        string query = "select id, id_state, name from states order by name";
        SqlCommand command = new SqlCommand(query);
        DataTable table = SqlServerConnection.GetConnection().ExecuteQuery(command);
        foreach (DataRow row in table.Rows)
        {
            int id = (int)row["id"];
            string id_state = (string)row["id_state"];
            string name = (string)row["name"];
            list.Add(new State(id, id_state, name));
        }

        //return list
        return list;
    }

    #endregion

}

