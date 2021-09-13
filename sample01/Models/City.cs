using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


public class City
{
    #region properties

    public int Id;
    public string Id_city;
    public string Name;

    #endregion

    #region constructors

    public City(int id, string id_city, string name)
    {
        Id = id;
        Id_city = id_city;
        Name = name;
    }

    #endregion
}

