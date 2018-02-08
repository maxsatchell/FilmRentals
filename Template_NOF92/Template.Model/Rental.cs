using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Model
{
    public class Rental
    {
        #region injected services 
        public IDomainObjectContainer Container { protected get; set; }
#endregion

        [NakedObjectsIgnore]//Indicates that this property will never be seen in the UI
        public virtual int RentalID { get; set; }

        public string Title()
        {
            var t = Container.NewTitleBuilder();
            t.Append(Customer).Append("Rental of").Append(Film);
            return t.ToString();
        }

        public virtual decimal Price { get; set; }
        public virtual DateTime? DateOut { get; set; }
        public virtual DateTime? DateReturned { get; set; }
        public virtual DateTime? DateReturnBy { get; set; }

        [NakedObjectsIgnore]
        public virtual int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        [NakedObjectsIgnore]
        public virtual int FilmID { get; set; }
        public virtual Film Film { get; set; }

    }
}
