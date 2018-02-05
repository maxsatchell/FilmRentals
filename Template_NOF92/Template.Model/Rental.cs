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
        

        [NakedObjectsIgnore]//Indicates that this property will never be seen in the UI
        public virtual int RentalID { get; set; }

        public virtual decimal price { get; set; }
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
