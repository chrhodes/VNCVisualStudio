using System;
using System.Data.Entity;

using VNC;

namespace $xxxMODULExxx$$xxxNAMESPACExxx$.Persistence.Data
{
    public class $xxxMODULExxx$DbContextDatabaseInitializer : CreateDatabaseIfNotExists<$xxxMODULExxx$DbContext>
    {
        protected override void Seed($xxxMODULExxx$DbContext context)
        {
            Int64 startTicks = Log.PERSISTENCE("Enter", Common.LOG_CATEGORY);
            
            base.Seed(context);
            
            Log.PERSISTENCE("Exit", Common.LOG_CATEGORY, startTicks);             
        }
    }
}
