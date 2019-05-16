using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BesicApp1.Models
{

    public class geoloc
    {
        public List<Country> Countries { get; set; }
        public List<State> States { get; set; }
        public List<City> Cities { get; set; }

    }
    public class Country
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
    public class State
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
    public class City
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }


}