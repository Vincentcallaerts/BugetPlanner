using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugetPlanner.Models
{
    public class InkomstUitgaveListViewModel
    {
        public int Id { get; set; }
        public int Bedrag { get; set; }
        public bool Inkomst { get; set; }
        public string Beschrijving { get; set; }
        public DateTime Date { get; set; }
    }
}
