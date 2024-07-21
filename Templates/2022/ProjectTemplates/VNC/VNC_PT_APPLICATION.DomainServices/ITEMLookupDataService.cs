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
    public class $xxxITEMxxx$LookupDataService : I$xxxITEMxxx$LookupDataService
    {

        #region Constructors, Initialization, and Load

        public $xxxITEMxxx$LookupDataService(Func<$xxxAPPLICATIONxxx$DbContext> context)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.Constructor) startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            _contextCreator = context;

            if (Common.VNCLogging.Constructor) Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
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

        public async Task<IEnumerable<LookupItem>> Get$xxxITEMxxx$LookupAsync()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.DomainServices) startTicks = Log.DOMAINSERVICES("($xxxITEMxxx$LookupDataService) Enter", Common.LOG_CATEGORY);

            IEnumerable<LookupItem> result;

            using (var ctx = _contextCreator())
            {
                result =  await ctx.$xxxITEMxxx$sSet.AsNoTracking()
                  .Select(f =>
                  new LookupItem
                  {
                      Id = f.Id,
                      DisplayMember = f.Name
                  })
                  .ToListAsync();
            }

            if (Common.VNCLogging.DomainServices) Log.DOMAINSERVICES("($xxxITEMxxx$LookupDataService) Exit", Common.LOG_CATEGORY, startTicks);

            return result;
        }

        #endregion

        #region Protected Methods


        #endregion

        #region Private Methods


        #endregion

    }
}
