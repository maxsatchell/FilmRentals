using NakedObjects;
using System.Linq;


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
        public Films CreateNewFilm()
        {
            //'Transient' means 'unsaved' -  returned to the user
            //for fields to be filled-in and the object saved.
            return Container.NewTransientInstance<Films>();
        }

        public IQueryable<Films> AllFilms()
        {
            //The 'Container' masks all the complexities of 
            //dealing with the database directly.
            return Container.Instances<Films>();
        }

        public IQueryable<Films> FindFilmByName(string name)
        {
            //Filters students to find a match
            return AllFilms().Where(c => c.FilmTitle.ToUpper().Contains(name.ToUpper()));
        }
    }

}
