using System.Collections.Generic;
using System.Linq;

using $safeprojectname$.Interfaces;

namespace $safeprojectname$.$customTYPE$.Queries.Get$customTYPE$List
{
    public class Get$customTYPE$sListQuery : IGet$customTYPE$sListQuery
    {
        private readonly IDatabaseService _database;

        public Get$customTYPE$sListQuery(IDatabaseService database)
        {
            _database = database;
        }

        public List<$customTYPE$Model> Execute()
        //public List<Customer> Execute()
        {
            //using (var context = new CustomPoolAndSpaDbContext())
            //{
            //    return context.CustomerSet.AsNoTracking()
            //        .OrderBy(c => c.Name)
            //        .ToList();
            //}

            //var customers = _database.Customers.ToList();
            //return customers;

            var items = _database.$customTYPE$s
                .Select(p => new $customTYPE$Model()
                {
                    Id = p.Id,
                    //Name = p.FirstName
                });

            return items.ToList();
        }
    }
}
