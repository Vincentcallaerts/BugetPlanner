using BugetPlanner.Database;
using BugetPlanner.Domain;
using BugetPlanner.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace BugetPlanner.Controllers
{
    public class InkomstUitgaveController : Controller
    {
        private readonly IInkomstUitgaveDatabase bugetDatabase;
        public InkomstUitgaveController(IInkomstUitgaveDatabase bugetDatabase)
        {
            this.bugetDatabase = bugetDatabase;
        }
        public IActionResult Index()
        {
            var vm = bugetDatabase.GetInkomstUitgaves().Select(x => new InkomstUitgaveListViewModel
            {
                Id = x.Id,
                Beschrijving = x.Beschrijving,
                Bedrag = x.Bedrag,
                Inkomst = x.Inkomst,
                Date = x.Date

            });

            return View(vm);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new InkomstUitgaveCreateViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] InkomstUitgaveCreateViewModel x)
        {
            if (TryValidateModel(x))
            {
                bugetDatabase.Insert(new InkomstUitgave
                {
                    Beschrijving = x.Beschrijving,
                    Bedrag = x.Bedrag,
                    Inkomst = x.Inkomst,
                    Date = x.Date
                });
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public IActionResult Detail([FromRoute] int id)
        {
            var x = bugetDatabase.GetInkomstUitgave(id);
            var vm = new InkomstUitgaveDetailViewModel
            {
                Beschrijving = x.Beschrijving,
                Bedrag = x.Bedrag,
                Inkomst = x.Inkomst,
                Date = x.Date
            };

            return View(vm);

        }
        public IActionResult Edit([FromRoute] int id)
        {
            var x = bugetDatabase.GetInkomstUitgave(id);
            var vm = new InkomstUitgaveEditViewModel
            {
                Beschrijving = x.Beschrijving,
                Bedrag = x.Bedrag,
                Inkomst = x.Inkomst,
                Date = x.Date
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, [FromForm] InkomstUitgaveEditViewModel x)
        {
            if (TryValidateModel(x))
            {
                bugetDatabase.Update(id, new InkomstUitgave()
                {
                    Beschrijving = x.Beschrijving,
                    Bedrag = x.Bedrag,
                    Inkomst = x.Inkomst,
                    Date = x.Date
                });

                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ComfirmDelete([FromRoute] int id, bool useless)
        {
            bugetDatabase.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
