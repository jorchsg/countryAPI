using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


public class Country
{
    #region Properties

    public string Id { get; set; }
    public string Name { get; set; }

    #endregion

    #region constructors

    public Country()
    {
        Id = "";
        Name = "";
    }

    public Country(string id)
    {
        string query = "select id, name from countries order by name";
        SqlCommand command = new SqlCommand(query);
        command.Parameters.AddWithValue("@id", id);
        DataTable table = SqlServerConnection.GetConnection().ExecuteQuery(command);
        if(table.Rows.Count > 0)
        {
            DataRow row = table.Rows[0];
            Id = (string)row["id"];
            Name = (string)row["name"];
        }

        else
            throw new RecordNotFoundException(GetType().ToString(), id);
    }

    public Country(string id, string name)
    {
        Id = id;

        if (id == "MEX")
            Name = name;
        else
            throw new RecordNotFoundException(GetType().ToString(), id);
    }

    #endregion


    #region instance methods
    
    public List<State> GetStates()
    {
        List<State> list = new List<State>();
        list.Add(new State("BC", "Baja California"));
        list.Add(new State("SIN", "Sinaloa"));
        list.Add(new State("SON", "Sonora"));
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

        string query = "select id, name from countries order by name";
        SqlCommand command = new SqlCommand(query);
        DataTable table = SqlServerConnection.GetConnection().ExecuteQuery(command);
        foreach (DataRow row in table.Rows)
        {
            string id = (string)row["id"];
            string name = (string)row["name"];
            list.Add(new Country(id, name));
        }

        //return list
        return list;
    }

    #endregion




}

