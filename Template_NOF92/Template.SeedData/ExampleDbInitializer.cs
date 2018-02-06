using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Template.DataBase;
using Template.Model;

namespace Template.SeedData
{
    public class ExampleDbInitializer : DropCreateDatabaseAlways<ExampleDbContext>
    {
        private ExampleDbContext Context;
        protected override void Seed(ExampleDbContext context)
        {

            this.Context = context;
            var fg =  AddNewFilm("Forest Gump","Stephan Speilberger","Drama", "https://www.youtube.com/watch?v=bLvqoHBptjg");
            var ju = AddNewFilm("Jumanji","Micheal bay","Comedy", "https://www.youtube.com/watch?v=bLvqoHBptjg");
            var tg= AddNewFilm("Top Gun","Kelly Holmes","Action", "https://www.youtube.com/watch?v=bLvqoHBptjg");

            var bh = AddNewCustomer("Bill Hanson");
            var rb =AddNewCustomer("Rikky Bobby");
            var cj = AddNewCustomer("Carl JR");

            AddNewRental(bh, fg,12.99m, new DateTime(2018,03,18),new DateTime(2018,05,18));
            AddNewRental(rb, ju,10.99m, new DateTime(2018,01,21), new DateTime(2018,02,24));
            AddNewRental(cj, tg,15.99m, new DateTime(2018,05,02), new DateTime(2018,07,28));


        }

        private Film AddNewFilm(string filmtitle,string director,string genre,string trailer)
        {
            var film = new Film() { FilmTitle = filmtitle, Director = director, Genre = genre,Trailer = trailer };
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

        private Rental AddNewRental(Customer customer, Film film, decimal price, DateTime dateout, DateTime datereturned)
        {
            var Rental = new Rental() { CustomerID = customer.CustomerID, FilmID = film.FilmID, Price = price,DateOut = dateout,DateReturned = datereturned };
            Context.Rentals.Add(Rental);
            Context.SaveChanges(); 
            return Rental;
        }

    }
}
