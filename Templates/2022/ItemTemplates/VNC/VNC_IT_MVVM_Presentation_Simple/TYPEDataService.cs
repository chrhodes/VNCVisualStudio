using System;
using System.Data.Entity;
using System.Threading.Tasks;

using $customAPPLICATION$.Domain;
using $customAPPLICATION$.Persistence.Data;

using VNC;
using VNC.Core.DomainServices;

namespace $customAPPLICATION$.DomainServices
{

    public class $customTYPE$DataService : GenericEFRepository<$customTYPE$, $customAPPLICATION$DbContext>, I$customTYPE$DataService
    {

        #region Constructors, Initialization, and Load

        public $customTYPE$DataService($customAPPLICATION$DbContext context)
            : base(context)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion

        #region Enums


        #endregion

        #region Structures


        #endregion

        #region Fields and Properties

        
        #endregion

        #region Event Handlers


        #endregion

        #region Public Methods

        public override async Task<$customTYPE$> FindByIdAsync(int id)
        {
            Int64 startTicks = Log.DOMAINSERVICES("($customTYPE$DataService) Enter", Common.LOG_APPNAME);

            var result = await Context.$customTYPE$sSet
                .Include(f => f.PhoneNumbers)
                .SingleAsync(f => f.Id == id);

            Log.DOMAINSERVICES("($customTYPE$DataService) Exit", Common.LOG_APPNAME, startTicks);

            return result;
        }

        public void RemovePhoneNumber($customTYPE$PhoneNumber model)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            Context.$customTYPE$PhoneNumbersSet.Remove(model);

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }


        #endregion
        
        #region Protected Methods


        #endregion

        #region Private Methods


        #endregion
   
    }
}
