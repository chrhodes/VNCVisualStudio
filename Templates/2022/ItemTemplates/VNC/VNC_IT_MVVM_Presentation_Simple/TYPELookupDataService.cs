using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using $customAPPLICATION$.Persistence.Data;

using VNC;

using VNC.Core.DomainServices;

namespace $customAPPLICATION$.DomainServices
{
    public class $customTYPE$LookupDataService : I$customTYPE$LookupDataService
    {

        #region Constructors, Initialization, and Load

        public $customTYPE$LookupDataService(Func<$customAPPLICATION$DbContext> context)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            _contextCreator = context;

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion

        #region Enums


        #endregion

        #region Structures


        #endregion

        #region Fields and Properties

        private Func<$customAPPLICATION$DbContext> _contextCreator;

        #endregion

        #region Event Handlers


        #endregion

        #region Public Methods

        public async Task<IEnumerable<LookupItem>> Get$customTYPE$LookupAsync()
        {
            Int64 startTicks = Log.DOMAINSERVICES("($customTYPE$LookupDataService) Enter", Common.LOG_APPNAME);

            IEnumerable<LookupItem> result;

            using (var ctx = _contextCreator())
            {
                result =  await ctx.$customTYPE$sSet.AsNoTracking()
                  .Select(f =>
                  new LookupItem
                  {
                      Id = f.Id,
                      DisplayMember = f.FieldString
                  })
                  .ToListAsync();
            }

            Log.DOMAINSERVICES("($customTYPE$LookupDataService) Exit", Common.LOG_APPNAME, startTicks);

            return result;
        }

        #endregion

        #region Protected Methods


        #endregion

        #region Private Methods


        #endregion

    }
}
