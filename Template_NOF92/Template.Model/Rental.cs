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
        [MemberOrder(10)]
        public virtual decimal Price { get; set; }
        [MemberOrder(20)]
        public virtual DateTime? DateOut { get; set; }
        [MemberOrder(30)]
        public virtual DateTime? DateReturnBy { get; set; }

        [Hidden(WhenTo.UntilPersisted)]
        public virtual DateTime? DateReturned { get; set; }
        

        [NakedObjectsIgnore]
        public virtual int CustomerID { get; set; }
        [MemberOrder(40)]
        public virtual Customer Customer { get; set; }
        [NakedObjectsIgnore]
        public virtual int FilmID { get; set; }                 //Allows Rental to be made and saved; but only in this order
        [MemberOrder(50)]
        public virtual Film Film { get; set; }

        public string Validate(Film film, Customer customer)
        {
            var rb = new ReasonBuilder();
            rb.AppendOnCondition(film.Rating >= customer.Age, "Not Old Enough");
            return rb.Reason;
        }


    }
}
