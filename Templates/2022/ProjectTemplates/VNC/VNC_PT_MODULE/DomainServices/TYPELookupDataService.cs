using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

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
            Int64 startTicks = 0;
            if (Common.VNCLogging.Constructor) startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            _contextCreator = context;

            if (Common.VNCLogging.Constructor) Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Enums (none)


        #endregion

        #region Structures (none)


        #endregion

        #region Fields and Properties

        private Func<$xxxAPPLICATIONxxx$DbContext> _contextCreator;

        #endregion

        #region Event Handlers (none)


        #endregion

        #region Public Methods

        public async Task<IEnumerable<LookupItem>> Get$xxxTYPExxx$LookupAsync()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.DomainServices) startTicks = Log.DOMAINSERVICES("($xxxTYPExxx$LookupDataService) Enter", Common.LOG_CATEGORY);

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

            if (Common.VNCLogging.DomainServices)Log.DOMAINSERVICES("($xxxTYPExxx$LookupDataService) Exit", Common.LOG_CATEGORY, startTicks);

            return result;
        }

        #endregion

        #region Protected Methods


        #endregion

        #region Private Methods


        #endregion

    }
}
