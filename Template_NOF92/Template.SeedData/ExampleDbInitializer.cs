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
            var fg =  AddNewFilm("Forest Gump");
            var ju = AddNewFilm("Jumanji");
            AddNewFilm("Top Gun");

            var bh = AddNewCustomer("Bill Hanson");
            AddNewCustomer("Rikky Bobby");
            AddNewCustomer("Carl JR");

        }

        private Film AddNewFilm(string filmtitle)
        {
            var film = new Film() { FilmTitle = filmtitle };
            Context.Films.Add(film);
            Context.SaveChanges();
            return film;
        }

        private Customer AddNewCustomer(string name)
        {
            var customer= new Customer() { Name = name };
            Context.Customers.Add(customer);
            Context.SaveChanges();
            return customer;
        }

        private Rental AddNewRental(Customer bh, Film fg)
        {
            var Rental = new Rental() { Customer = bh, Film = fg };
            Context.Rentals.Add(Rental);
            Context.SaveChanges();
            return Rental;
        }

    }
}
