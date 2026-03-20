using System;
using System.Windows.Forms;

using Microsoft.Office.Tools.Ribbon;

using Visio = Microsoft.Office.Interop.Visio;

using $safeprojectname$;

using $safeprojectname$Application;
using $safeprojectname$Application.Actions;

namespace $safeprojectname$
{
    public partial class Ribbon
    {
        // TODO(crhodes)
        // This Region can be removed.  It is left here to show functionality from
        // original lessons

        #region REMOVE

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            Common.WriteToDebugWindow("Ribbon()");
            AddShapeToNewPage();
        }

        private void button2_Click(object sender, RibbonControlEventArgs e)
        {
            Common.WriteToDebugWindow("Ribbon()");
            AddFooter();
        }

        private void AddShapeToNewPage()
        {
            Visio.Application app = Globals.ThisAddIn.Application;

            Visio.Document doc = app.ActiveDocument;

            Visio.Page currentPage = app.ActivePage;

            Visio.Page newPage = doc.Pages.Add();

            Visio.Document stencil = app.Documents.OpenEx("Basic_U.vssx", (short)Visio.VisOpenSaveArgs.visOpenDocked);

            Visio.Shape stencilSquare = currentPage.Drop(stencil.Masters["Square"], 1, 5);
            Visio.Shape stencilCircle = currentPage.Drop(stencil.Masters["Circle"], 3, 5);
            Visio.Shape stencilTriangle = currentPage.Drop(stencil.Masters["Triangle"], 5, 5);

            stencilSquare.Text = "Square";
            stencilCircle.Text = "Circle";
            stencilTriangle.Text = "Triangle";

            newPage.NameU = "My New Page";

            Visio.Shape shape1 = currentPage.DrawRectangle(1, 1, 2, 1.5);
            Visio.Shape shape2 = currentPage.DrawRectangle(1, 3, 2, 3.5);

            Visio.Shape shape3 = newPage.DrawRectangle(1, 1, 2, 1.5);
            Visio.Shape shape4 = newPage.DrawRectangle(1, 3, 2, 3.5);

            shape1.Text = currentPage.Name;
            shape2.Text = newPage.Name;

            shape3.Text = shape3.Name;
            shape4.Text = shape4.Name;
        }

        private void AddFooter()
        {
            Visio.Application app = Globals.ThisAddIn.Application;

            Visio.Document doc = app.ActiveDocument;

            doc.FooterLeft = "&f&e";
            doc.FooterCenter = "";
            doc.FooterRight = "&d &p-&P";

            var font = doc.HeaderFooterFont;

            font.Size = (decimal)8;

            doc.HeaderFooterFont = font;

            var size = doc.HeaderFooterFont.Size;

            doc.HeaderMargin[Visio.VisUnitCodes.visDrawingUnits] = 0.13;
            doc.FooterMargin[Visio.VisUnitCodes.visDrawingUnits] = 0.13;
        }

        #endregion

        #region EventHandlers

        #region Help Events

        // NOTE(crhodes)
        // Minimal logic in Ribbon.
        // Wrap all calls in Try/Catch to avoid crashing AddIn
        // Or not seeing errors

        // try
        // {
            // Call Something in $safeprojectname$Application
        // }
        // catch (Exception ex)
        // {
            // Common.WriteToDebugWindow(ex.Message, force: true);
        // }

        private void btnDisplayAddInInfo_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                VNC.VSTOAddIn.AddInInfo.DisplayInfo();
            }
            catch (Exception ex)
            {
                Common.WriteToDebugWindow(ex.Message, force: true);
            }
        }

        private void btnToggleDeveloperMode_Click(object sender, RibbonControlEventArgs e)
        {
            VNC.VSTOAddIn.Common.DeveloperMode = !VNC.VSTOAddIn.Common.DeveloperMode;
            Globals.Ribbons.Ribbon.rgDebug.Visible = VNC.VSTOAddIn.Common.DeveloperMode;
        }

        #endregion

        #region Debug Events

        private void btnDebugWindow_Click(object sender, RibbonControlEventArgs e)
        {
            VNC.VSTOAddIn.Common.DebugWindow.Visible = !VNC.VSTOAddIn.Common.DebugWindow.Visible;
        }

        private void btnWatchWindow_Click(object sender, RibbonControlEventArgs e)
        {
            VNC.VSTOAddIn.Common.WatchWindow.Visible = !VNC.VSTOAddIn.Common.WatchWindow.Visible;
        }

        private void rcbLogToDebugWindow_Click(object sender, RibbonControlEventArgs e)
        {
            MessageBox.Show(System.Reflection.MethodInfo.GetCurrentMethod().Name);
        }

        private void rcbEnableAppEvents_Click(object sender, RibbonControlEventArgs e)
        {
            Common.EnableAppEvents = rcbEnableAppEvents.Checked;

            if (Common.EnableAppEvents)
            {
                if (Common.AppEvents == null)
                {
                    Common.AppEvents = new $safeprojectname$Application.Events.VisioAppEvents();
                    Common.AppEvents.VisioApplication = Globals.ThisAddIn.Application;
                }
            }
            else
            {
                Common.AppEvents.VisioApplication = null;
                Common.AppEvents = null;
            }
        }

        private void rcbDisplayEvents_Click(object sender, RibbonControlEventArgs e)
        {
            $safeprojectname$Application.Common.DisplayEvents = rcbDisplayEvents.Checked;
        }

        private void rcbDisplayChattyEvents_Click(object sender, RibbonControlEventArgs e)
        {
            Common.DisplayChattyEvents = rcbDisplayChattyEvents.Checked;
        }

        private void rcbToggleDeveloperUIMode_Click(object sender, RibbonControlEventArgs e)
        {
            // This is for changing the visibility of MVVM DeveloperInfo stuff.

            try
            {
                Visio_Application.DeveloperModeUI(rcbDeveloperUIMode.Checked);
            }
            catch (Exception ex)
            {
                Common.WriteToDebugWindow(ex.Message, force: true);
            }
        }
        
        private void rcbUILaunchApproaches_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.Ribbons.Ribbon.rtUILaunchApproaches.Visible = Globals.Ribbons.Ribbon.rcbUILaunchApproaches.Checked;
        }        

        #endregion

        #endregion

    }
}
