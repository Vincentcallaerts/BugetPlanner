using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugetPlanner.Models
{
    public class InkomstUitgaveEditViewModel
    {
        public int Bedrag { get; set; }
        public bool Inkomst { get; set; }
        public string Beschrijving { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<SelectListItem> InkomstUitgaveBeschrijving { get; set; } = new List<SelectListItem>()
        {
            new SelectListItem("Werk","Werk"),
            new SelectListItem("Date","Date"),
            new SelectListItem("Café","Café"),
            new SelectListItem("Cinema","Cinema"),
            new SelectListItem("Vrijwiligerswerk","Vrijwiligerswerk"),

        };
    }
}
