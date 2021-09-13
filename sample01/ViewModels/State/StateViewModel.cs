using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class StateViewModel : JsonResponse
{
    public State State { get; set; }
    public List<City> Cities { get; set; }
}
