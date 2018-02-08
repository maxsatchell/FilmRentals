using NakedObjects;
using System.Linq;
using System;


namespace Template.Model
{
    //This example service acts as both a 'repository' (with methods for
    //retrieving objects from the database) and as a 'factory' i.e. providing
    //one or more methods for creating new object(s) from scratch.
    public class FilmService
    {
        #region Injected Services
        //An implementation of this interface is injected automatically by the framework
        public IDomainObjectContainer Container { set; protected get; }
        #endregion
        public Film CreateNewFilm()
        {
            //'Transient' means 'unsaved' -  returned to the user
            //for fields to be filled-in and the object saved.
            return Container.NewTransientInstance<Film>();
        }

        public IQueryable<Film> AllFilms()
        {
            //The 'Container' masks all the complexities of 
            //dealing with the database directly.
            return Container.Instances<Film>();
        }

        public IQueryable<Film> FindFilmByName(string name)
        {
            //Filters students to find a match
            return AllFilms().Where(c => c.FilmTitle.ToUpper().Contains(name.ToUpper()));
        }

        public IQueryable<Film> AllFilmsThisYear()
        {
            int year = DateTime.Today.Year;

            return Container.Instances<Film>().Where(f => f.DateReleased.Value.Year == year); 
        }


    }

}
