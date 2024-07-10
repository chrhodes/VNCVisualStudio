using System;
using System.Data.Entity;

namespace $safeprojectname$
{
    public class $customAPPLICATION$NDbContextDatabaseInitializer : CreateDatabaseIfNotExists<$customAPPLICATION$DbContext>
    {
        protected override void Seed($customAPPLICATION$DbContext context)
        {
            Console.WriteLine("Seed($customAPPLICATION$DbContext)");
            base.Seed(context);
        }
    }
}
