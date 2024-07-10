using System;
using System.Data.Entity;

using VNC;

namespace $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Persistence.Database
{
    public class $xxxAPPLICATIONxxx$DbContextDatabaseInitializer : CreateDatabaseIfNotExists<$xxxAPPLICATIONxxx$DbContext>
    {
        protected override void Seed($xxxAPPLICATIONxxx$DbContext context)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.Persistence) startTicks = Log.PERSISTENCE("Enter", Common.LOG_CATEGORY);
            
            base.Seed(context);
            
            if (Common.VNCLogging.Persistence) Log.PERSISTENCE("Exit", Common.LOG_CATEGORY, startTicks);             
        }
    }
}
