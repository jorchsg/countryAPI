using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


public class Country
{
    #region Properties

    public int Id { get; set; }
    public string Id_country { get; set; }
    public string Name { get; set; }

    #endregion

    #region constructors

    public Country()
    {
        Id = 0;
        Id_country = "";
        Name = "";
    }

    public Country(int id)
    {
        string query = "select id, id_country, name from countries  where id=@id order by name";
        SqlCommand command = new SqlCommand(query);
        command.Parameters.AddWithValue("@id", id);
        DataTable table = SqlServerConnection.GetConnection().ExecuteQuery(command);
        if(table.Rows.Count > 0)
        {
            DataRow row = table.Rows[0];
            Id = (int)row["id"];
            Id_country = (string)row["id_country"];
            Name = (string)row["name"];
        }
        else
            throw new RecordNotFoundException(GetType().ToString(), id.ToString());
    }

    public Country(int id, string id_country, string name)
    {
        Id = id;
        Id_country = id_country;
        Name = name;
        //if (id_country == "CAN")
        //    Name = name;
        //else
        //    throw new RecordNotFoundException(GetType().ToString(), id_country);
    }

    #endregion


    #region instance methods
    
    public List<State> GetStates(int fk_country)
    {
        
        List<State> list = new List<State>();
        
        string query = "select id, id_state, name from states where fk_country=@fk_country order by name";
        SqlCommand command = new SqlCommand(query);
        command.Parameters.AddWithValue("@fk_country", fk_country);
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

    #region class methods

    public static List<Country> GetAll()
    {
        //Create Empty
        List<Country> list = new List<Country>();

        //Populate List

        /*
        list.Add(new Country("Can", "Canada"));
        list.Add(new Country("MEX", "Mexico"));
        list.Add(new Country("USA", "United States"));
        */

        string query = "select id, id_country, name from countries order by name";
        SqlCommand command = new SqlCommand(query);
        DataTable table = SqlServerConnection.GetConnection().ExecuteQuery(command);
        foreach (DataRow row in table.Rows)
        {
            int id = (int)row["id"];
            string id_country = (string)row["id_country"];
            string name = (string)row["name"];
            list.Add(new Country(id, id_country, name));
        }

        //return list
        return list;
    }

    #endregion




}

