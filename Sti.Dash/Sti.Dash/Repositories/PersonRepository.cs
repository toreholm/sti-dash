using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sti.Dash.Repositories
{
    public class PersonRepository
    {

        public List<Person> GetAll()
        {
            using (DashboardContext context = new DashboardContext())
            {

                var persons = context.People;
                return persons.ToList();




            }

        }

    }
}