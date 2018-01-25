using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NakedObjects;

namespace Template.Model
{
    public class Customer
    {
        [NakedObjectsIgnore]//Indicates that this property will never be seen in the UI
        public virtual int Id { get; set; }

        [Title]//This property will be used for the object's title at the top of the view and in a link
        public virtual string Name { get; set; }
    }
}
