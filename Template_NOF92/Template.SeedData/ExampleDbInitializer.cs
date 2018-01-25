using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Template.DataBase;
using Template.Model;

namespace Template.SeedData
{
    public class ExampleDbInitializer : DropCreateDatabaseIfModelChanges<ExampleDbContext>
    {
        private ExampleDbContext Context;
        protected override void Seed(ExampleDbContext context)
        {
            this.Context = context;
            AddNewStudent("Forest Gump");
            AddNewStudent("Jumanji");
            AddNewStudent("Top Gun");

            AddNewCustomer("Bill Hanson");
            AddNewCustomer("Rikky Bobby");
            AddNewCustomer("Carl JR");

        }

        private void AddNewStudent(string filmtitle)
        {
            var film = new Films() { FilmTitle = filmtitle };
            Context.Films.Add(film);
        }

        private void AddNewCustomer(string name)
        {
            var customer= new Customer() { Name = name };
            Context.Customers.Add(customer);
        }

    }
}
