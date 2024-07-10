using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Persistence.Database;

using VNC;

using VNC.Core.DomainServices;

namespace $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.DomainServices
{
    public class $xxxTYPExxx$LookupDataService : I$xxxTYPExxx$LookupDataService
    {

        #region Constructors, Initialization, and Load

        public $xxxTYPExxx$LookupDataService(Func<$xxxAPPLICATIONxxx$DbContext> context)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            _contextCreator = context;

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Enums


        #endregion

        #region Structures


        #endregion

        #region Fields and Properties

        private Func<$xxxAPPLICATIONxxx$DbContext> _contextCreator;

        #endregion

        #region Event Handlers


        #endregion

        #region Public Methods

        public async Task<IEnumerable<LookupItem>> Get$xxxTYPExxx$LookupAsync()
        {
            Int64 startTicks = Log.DOMAINSERVICES("($xxxTYPExxx$LookupDataService) Enter", Common.LOG_CATEGORY);

            IEnumerable<LookupItem> result;

            using (var ctx = _contextCreator())
            {
                result =  await ctx.$xxxTYPExxx$sSet.AsNoTracking()
                  .Select(f =>
                  new LookupItem
                  {
                      Id = f.Id,
                      DisplayMember = f.FieldString
                  })
                  .ToListAsync();
            }

            Log.DOMAINSERVICES("($xxxTYPExxx$LookupDataService) Exit", Common.LOG_CATEGORY, startTicks);

            return result;
        }

        #endregion

        #region Protected Methods


        #endregion

        #region Private Methods


        #endregion

    }
}
