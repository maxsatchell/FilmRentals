using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Model
{
   //This example service acts as both a 'repository' (with methods for
    //retrieving objects from the database) and as a 'factory' i.e. providing
    //one or more methods for creating new object(s) from scratch.
    public class CustomerService
    {
        #region Injected Services
        //An implementation of this interface is injected automatically by the framework
        public IDomainObjectContainer Container { set; protected get; }
        #endregion
        public Customer CreateNewCustomer()
        {
            //'Transient' means 'unsaved' -  returned to the user
            //for fields to be filled-in and the object saved.
            return Container.NewTransientInstance<Customer>();
        }

        public IQueryable<Customer>AllCustomers()
        {
            //The 'Container' masks all the complexities of 
            //dealing with the database directly.
            return Container.Instances<Customer>();
        }

        public IQueryable<Customer> FindCustomerByName(string name)
        {
            //Filters students to find a match
            return AllCustomers().Where(c => c.Name.ToUpper().Contains(name.ToUpper()));
        }

        

    }

}

