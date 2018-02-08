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
            var fg =  AddNewFilm("Forest Gump","Stephan Speilberger","Drama", "https://www.youtube.com/watch?v=bLvqoHBptjg","12",new DateTime(2014, 03, 15));
            var ju = AddNewFilm("Jumanji","Micheal bay","Comedy", "https://www.youtube.com/watch?v=bLvqoHBptjg","PG", new DateTime(2018, 02, 06));
            var tg= AddNewFilm("Top Gun","Kelly Holmes","Action", "https://www.youtube.com/watch?v=bLvqoHBptjg","15", new DateTime(1995, 02, 07));

            var bh = AddNewCustomer("Bill Hanson", 24);
            var rb =AddNewCustomer("Rikky Bobby", 17);
            var cj = AddNewCustomer("Carl JR",15);

            var bhfg = AddNewRental(bh, fg,12.99m, new DateTime(2018,03,18),new DateTime(2018,05,18),new DateTime(2014,02,06));
            var rbju = AddNewRental(rb, ju,10.99m, new DateTime(2018,01,21), new DateTime(2018,01,01), new DateTime(2018,02,08));
            var cjtg = AddNewRental(cj, tg,15.99m, new DateTime(2018,05,02), new DateTime(2018,07,28), new DateTime(2018,03,01));
       

        }


        private Film AddNewFilm(string filmtitle,string director,string genre,string trailer,int rating,DateTime datereleased)
        {
            var film = new Film() { FilmTitle = filmtitle, Director = director, Genre = genre, Trailer = trailer, Rating = rating, DateReleased = datereleased };
            Context.Films.Add(film);
            Context.SaveChanges();
            return film;
        }

        private Customer AddNewCustomer(string name, int age)
        {
            var customer= new Customer() { Name = name, Age = age};
            Context.Customers.Add(customer);
            Context.SaveChanges();
            return customer;
        }

        private Rental AddNewRental(Customer customer, Film film,decimal price,DateTime dateout,DateTime datereturned,DateTime datereturnby)
        {
            var Rental = new Rental() { CustomerID = customer.CustomerID, FilmID = film.FilmID, Price = price,DateOut = dateout,DateReturned = datereturned, DateReturnBy = datereturnby };
            Context.Rentals.Add(Rental);
            Context.SaveChanges(); 
            return Rental;
        }

    }
}
