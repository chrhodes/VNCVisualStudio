using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using SupportTools_Visio.Domain;

using VisioHelper = VNC.AddinHelper.Visio;
using VNC;

namespace SupportTools_Visio.Presentation.Views
{
    public partial class $safeitemname$ : UserControl
    {
        #region Constructors and Load

        public $safeitemname$()
        {
            Log.Trace("Enter", Common.PROJECT_NAME);
            InitializeComponent();
            LoadControlContents();
            Log.Trace("Exit", Common.PROJECT_NAME);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Log.Trace("Enter", Common.PROJECT_NAME);
            //VNC.Log.Trace("", Common.LOG_APPNAME, 0);
            //VisioHelper.DisplayInWatchWindow(string.Format("{0}()",
            //    System.Reflection.MethodInfo.GetCurrentMethod().Name));
            Log.Trace("Exit", Common.PROJECT_NAME);
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            Log.Trace("Enter", Common.PROJECT_NAME);
            //VNC.Log.Trace("", Common.LOG_APPNAME, 0);
            //VisioHelper.DisplayInWatchWindow(string.Format("{0}()",
            //    System.Reflection.MethodInfo.GetCurrentMethod().Name));
            Log.Trace("Exit", Common.PROJECT_NAME);
        }

        #endregion

        #region Event Handlers


        #endregion

        #region Private Methods

        private void LoadControlContents()
        {
            try
            {
                //visioCommand_Picker.PopulateControlFromFile(Common.cCONFIG_FILE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

    }
}
