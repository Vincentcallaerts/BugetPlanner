using BugetPlanner.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugetPlanner.Database
{
    public interface IInkomstUitgaveDatabase
    {
        InkomstUitgave GetInkomstUitgave(int id);
        IEnumerable<InkomstUitgave> GetInkomstUitgaves();
        InkomstUitgave Insert(InkomstUitgave inkomstUitgave);
        void Delete(int id);
        void Update(int id, InkomstUitgave updated);
    }
    public class InkomstUitgaveDatabase : IInkomstUitgaveDatabase
    {
        private readonly InkomstUitgaveDbContext dataDbContext;

        public InkomstUitgaveDatabase(InkomstUitgaveDbContext dataDbContext)
        {
            this.dataDbContext = dataDbContext;
        }
        public void Delete(int id)
        {
            var inkomstUitgave = dataDbContext.InkomstUitgave.SingleOrDefault(m => m.Id == id);
            if (inkomstUitgave != null)
            {
                dataDbContext.Remove(inkomstUitgave);
                dataDbContext.SaveChanges();

            }
        }

        public IEnumerable<InkomstUitgave> GetInkomstUitgaves()
        {
            return dataDbContext.InkomstUitgave.Select(x => x);
        }

        public InkomstUitgave GetInkomstUitgave(int id)
        {
            return dataDbContext.InkomstUitgave.FirstOrDefault(m => m.Id == id); 
        }

        public InkomstUitgave Insert(InkomstUitgave inkomstUitgave)
        {
            dataDbContext.InkomstUitgave.Add(inkomstUitgave);
            dataDbContext.SaveChanges();

            return inkomstUitgave;
        }

        public void Update(int id, InkomstUitgave updated)
        {
            var inkomstUitgave = dataDbContext.InkomstUitgave.SingleOrDefault(m => m.Id == id);
            if (inkomstUitgave != null)
            {
                inkomstUitgave.Inkomst = updated.Inkomst;
                inkomstUitgave.Beschrijving = updated.Beschrijving;
                inkomstUitgave.Bedrag = updated.Bedrag;
                inkomstUitgave.Date = updated.Date;

                dataDbContext.SaveChanges();
            }
        }
    }
}
