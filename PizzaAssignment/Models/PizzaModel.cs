using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaAssignment.Models
{
    public class PizzaModel
    {
        public string PizzaSize { get; set; }
        public int SizePrice { get; set; }
        public List<string> PizzaToping { get; set; }
        public int TopingPrice { get; set; }
    }
}
