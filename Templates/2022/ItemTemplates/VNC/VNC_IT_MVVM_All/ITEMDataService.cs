using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Domain;
using $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Persistence.Database;

using VNC;
using VNC.Core.DomainServices;

namespace $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.DomainServices
{

    public class $xxxITEMxxx$DataService : GenericEFRepository<$xxxITEMxxx$, $xxxAPPLICATIONxxx$DbContext>, I$xxxITEMxxx$DataService
    {

        #region Constructors, Initialization, and Load

        public $xxxITEMxxx$DataService($xxxAPPLICATIONxxx$DbContext context)
            : base(context)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.Constructor) startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            if (Common.VNCLogging.Constructor) Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Enums (none)


        #endregion

        #region Structures (none)


        #endregion

        #region Fields and Properties (none)


        #endregion

        #region Event Handlers (none)


        #endregion

        #region Public Methods

        public async Task<bool> IsReferencedBy$xxxTYPExxx$Async(int id)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.DomainServices) startTicks = Log.DOMAINSERVICES("($xxxITEMxxx$DataService) Enter", Common.LOG_CATEGORY);

            var result = await Context.$xxxTYPExxx$sSet.AsNoTracking()
                .AnyAsync(f => f.Favorite$xxxITEMxxx$Id == id);

            if (Common.VNCLogging.DomainServices)Log.DOMAINSERVICES("($xxxITEMxxx$DataService) Exit", Common.LOG_CATEGORY, startTicks);

            return result;
        }

        #endregion

        #region Protected Methods (none)


        #endregion

        #region Private Methods (none)


        #endregion
    }
}
