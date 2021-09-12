using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class CountryViewModel : JsonResponse
{
    public Country Country { get; set; }
    public List<State> States { get; set; }
}
