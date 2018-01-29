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

        public decimal price { get; set; }
        public DateTime DateOut { get; set; }
        public DateTime DateReturned { get; set; }
        public DateTime DateReturnBy { get; set; }

        public Customer Customer { get; set; }
        public Film Film { get; set; }

    }
}
