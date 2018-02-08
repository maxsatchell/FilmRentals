using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NakedObjects;

namespace Template.Model
{
    public class RentalService
    {
        #region Injected Services
        //An implementation of this interface is injected automatically by the framework
        public IDomainObjectContainer Container { set; protected get; }
        #endregion
        public Rental CreateNewRental()
        {
            //'Transient' means 'unsaved' -  returned to the user
            //for fields to be filled-in and the object saved.
            return Container.NewTransientInstance<Rental>();
        }

        public IQueryable<Rental> AllRentals()
        {
            //The 'Container' masks all the complexities of 
            //dealing with the database directly.
            return Container.Instances<Rental>();
        }

        public IQueryable<Rental> OverdueRentals(DateTime DateReturnBy)
        {
            return Container.Instances<Rental>().Where(r => r.DateReturnBy >= DateTime.Today);
        }

        public IQueryable<Rental> FindRentalByCustomerName(string name)
        {
            
            return AllRentals().Where(c => c.Customer.Name.ToUpper().Contains(name.ToUpper()));
        }
        public IQueryable<Rental> FindRentalByFilmtitle(string name)
        {
           
            return AllRentals().Where(c => c.Film.FilmTitle.ToUpper().Contains(name.ToUpper()));
        }
        public IQueryable<Rental> FindRentalByRating(int rating)
        {
            return AllRentals().Where(c => c.Film.Rating.Equals(rating));
        }


    }
}
