using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

using $customAPPLICATION$.Domain;

using VNC;
using VNC.Core.DomainServices;

namespace $customAPPLICATION$.DomainServices
{
    public class $customTYPE$DataServiceMock : I$customTYPE$DataService
    {
        public IEnumerable<$customTYPE$> All()
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);
            
            // TODO(crhodes)
            // Load data from real database.
            // For now just return hard coded list.

            yield return new $customTYPE$
            {
                Id = 1,
                FieldString = "FieldString",
                FieldDouble = 2.0,
                FieldInt = 23

            };
            
            yield return new $customTYPE$ 
            { 
                Id = 2, 
                FieldString = null, 
                FieldDouble = Double.MaxValue, 
                FieldInt = int.MaxValue
            };
            
            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public Task<List<$customTYPE$>> AllAsync()
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);
            
            throw new NotImplementedException();
            
            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public IEnumerable<$customTYPE$> AllInclude(params Expression<Func<$customTYPE$, object>>[] includeProperties)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);
            
            throw new NotImplementedException();
            
            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public Task<IEnumerable<$customTYPE$>> AllIncludeAsync(params Expression<Func<$customTYPE$, object>>[] includeProperties)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);
            
            throw new NotImplementedException();
            
            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public void Delete(int entityId)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);
            
            throw new NotImplementedException();
            
            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public void DeleteAsync(int entityId)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);
            
            throw new NotImplementedException();
            
            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public IEnumerable<$customTYPE$> FindBy(Expression<Func<$customTYPE$, bool>> predicate)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);
            
            throw new NotImplementedException();
            
            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public Task<IEnumerable<$customTYPE$>> FindByAsync(Expression<Func<$customTYPE$, bool>> predicate)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);
            
            throw new NotImplementedException();
            
            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public $customTYPE$ FindById(int entityId)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);
            
            throw new NotImplementedException();
            
            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);            
        }

        public Task<$customTYPE$> FindByIdAsync(int entityId)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);
            
            throw new NotImplementedException();
            
            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public IEnumerable<$customTYPE$> FindByInclude(Expression<Func<$customTYPE$, bool>> predicate, params Expression<Func<$customTYPE$, object>>[] includeProperties)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);
            
            throw new NotImplementedException();
            
            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public Task<IEnumerable<$customTYPE$>> FindByIncludeAsync(Expression<Func<$customTYPE$, bool>> predicate, params Expression<Func<$customTYPE$, object>>[] includeProperties)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);
            
            throw new NotImplementedException();
            
            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public bool HasChanges()
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);
                        
            throw new NotImplementedException();
            
            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);            
        }

        public void Insert($customTYPE$ entity)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);
            
            throw new NotImplementedException();
            
            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public Task<$customTYPE$> InsertAsync($customTYPE$ entity)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);
            
            throw new NotImplementedException();
            
            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public void Update($customTYPE$ entity)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);
            
            throw new NotImplementedException();
            
            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public Task<$customTYPE$> UpdateAsync($customTYPE$ entity)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);
            
            throw new NotImplementedException();
            
            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public Task UpdateAsync()
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);
            
            throw new NotImplementedException();
            
            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        Task IDataService<$customTYPE$>.DeleteAsync(int entityId)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);
            
            throw new NotImplementedException();
            
            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        Task IDataService<$customTYPE$>.InsertAsync($customTYPE$ entity)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);
            
            throw new NotImplementedException();
            
            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        Task IDataService<$customTYPE$>.UpdateAsync($customTYPE$ entity)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);
            
            throw new NotImplementedException();
            
            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }
    }
}
