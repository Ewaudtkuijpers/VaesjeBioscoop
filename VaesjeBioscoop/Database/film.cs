using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaesjeBioscoop.Database
{
    public class film
    {
        public int id { get; set; }

        public string? titel { get; set; }

        public string? beschijving { get; set; }

        public int leeftijd { get; set; }

        public string? poster { get; set; }
    }
}
