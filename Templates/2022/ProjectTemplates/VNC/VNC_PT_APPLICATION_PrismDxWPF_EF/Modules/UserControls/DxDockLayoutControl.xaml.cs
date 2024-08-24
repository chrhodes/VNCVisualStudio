using System;
using System.Windows.Controls;

namespace VNC.WPF.Presentation.Dx.Views
{
    public partial class DxDockLayoutControl : UserControl
    {
        public DxDockLayoutControl()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.Constructor) startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            InitializeComponent();

            if (Common.VNCLogging.Constructor) Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }
    }
}
