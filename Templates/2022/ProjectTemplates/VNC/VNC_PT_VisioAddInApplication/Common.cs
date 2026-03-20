
namespace $safeprojectname$
{
    public class Common : VNC.VSTOAddIn.Common
    {
        new public const string LOG_CATEGORY = "$safeprojectname$";

        public static Events.VisioAppEvents AppEvents;
        public static Events.AddInApplicationEvents AddInApplicationEvents;

        public static Microsoft.Office.Interop.Visio.Application VisioApplication { get; set; }

    }
}
