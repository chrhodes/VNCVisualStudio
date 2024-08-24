using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

using DevExpress.Xpf.Core.Native;

namespace VNC.WPF.Presentation.Dx.Views
{
    public partial class VNCCoreLoggingConfig : UserControl, INotifyPropertyChanged
    {
        public VNCCoreLoggingConfig()
        {
            Int64 startTicks = 0;
            if (Common.VNCCoreLogging.Constructor) startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            InitializeComponent();

            DataContext = this;
            Loaded += OnLoaded;

            if (Common.VNCCoreLogging.Constructor) Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        // NOTE(crhodes)
        // Need to have LoggingUIConfig available 
        // so bindings to labels and tooltips will work at initialization

        private LoggingUIConfigVNCARCH _loggingUIConfig = new LoggingUIConfigVNCARCH();

        public LoggingUIConfigVNCARCH LoggingUIConfig
        {
            get => _loggingUIConfig;
            set
            {
                if (_loggingUIConfig == value)
                    return;
                _loggingUIConfig = value;
                OnPropertyChanged();
            }
        }        

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        // This is the traditional approach - requires string name to be passed in

        //private void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            Int64 startTicks = 0;
#if LOGGING
            if (Common.VNCCoreLogging.INPC) startTicks = Log.VIEW_LOW($"Enter ({propertyName})", Common.LOG_CATEGORY);
#endif
            // This is the new CompilerServices attribute!

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
#if LOGGING
            if (Common.VNCCoreLogging.INPC) Log.VIEW_LOW("Exit", Common.LOG_CATEGORY, startTicks);
#endif
        }

        #endregion

        private void ceInfo00C_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            Common.VNCCoreLogging.Info00 = (Boolean)e.NewValue;
        }

        private void ceArch00C_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            Common.VNCCoreLogging.Constructor = (Boolean)e.NewValue;
        }

        private void ceArch01C_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            Common.VNCCoreLogging.Event = (Boolean)e.NewValue;
        }

        private void ceArch02C_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            Common.VNCCoreLogging.EventHandler = (Boolean)e.NewValue;
        }

        private void ceArch03C_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            Common.VNCCoreLogging.ApplicationInitialize = (Boolean)e.NewValue;
        }

        private void ceArch04C_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            Common.VNCCoreLogging.Core = (Boolean)e.NewValue;
        }

        private void ceArch05C_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            Common.VNCCoreLogging.Module = (Boolean)e.NewValue;
        }

        private void ceArch06C_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            Common.VNCCoreLogging.ModuleInitialize = (Boolean)e.NewValue;
        }

        private void ceArch07C_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            Common.VNCCoreLogging.Application = (Boolean)e.NewValue;
        }

        private void ceArch08C_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            Common.VNCCoreLogging.ApplicationServices = (Boolean)e.NewValue;
        }

        private void ceArch09C_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            Common.VNCCoreLogging.Domain = (Boolean)e.NewValue;
        }

        private void ceArch10C_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            Common.VNCCoreLogging.DomainServices = (Boolean)e.NewValue;
        }

        private void ceArch11C_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            Common.VNCCoreLogging.Persistence = (Boolean)e.NewValue;
        }

        private void ceArch12C_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            Common.VNCCoreLogging.PersistenceLow = (Boolean)e.NewValue;
        }

        private void ceArch13C_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            Common.VNCCoreLogging.Infrastructure = (Boolean)e.NewValue;
        }

        private void ceArch14C_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            Common.VNCCoreLogging.Presentation = (Boolean)e.NewValue;
        }

        private void ceArch15C_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            Common.VNCCoreLogging.View = (Boolean)e.NewValue;
        }

        private void ceArch16C_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            Common.VNCCoreLogging.ViewLow = (Boolean)e.NewValue;
        }

        private void ceArch17C_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            Common.VNCCoreLogging.ViewModel = (Boolean)e.NewValue;
        }

        private void ceArch18C_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            Common.VNCCoreLogging.ViewModelLow = (Boolean)e.NewValue;
        }

        private void ceINPC_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            Common.VNCCoreLogging.INPC = (Boolean)e.NewValue;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.EventHandler) startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_CATEGORY);

            ceInfo00C.IsChecked = Common.VNCCoreLogging.Info00;
            //ceInfo01C.IsChecked = Common.VNCCoreLogging.Info01;
            //ceInfo02C.IsChecked = Common.VNCCoreLogging.Info02;
            //ceInfo03C.IsChecked = Common.VNCCoreLogging.Info03;
            //ceInfo04C.IsChecked = Common.VNCCoreLogging.Info04;

            //ceDebug00C.IsChecked = Common.VNCCoreLogging.Debug00;
            //ceDebug01C.IsChecked = Common.VNCCoreLogging.Debug01;
            //ceDebug02C.IsChecked = Common.VNCCoreLogging.Debug02;
            //ceDebug03C.IsChecked = Common.VNCCoreLogging.Debug03;
            //ceDebug04C.IsChecked = Common.VNCCoreLogging.Debug04;

            ceArch00C.IsChecked = Common.VNCCoreLogging.Constructor;
            ceArch01C.IsChecked = Common.VNCCoreLogging.Event;
            ceArch02C.IsChecked = Common.VNCCoreLogging.EventHandler;
            ceArch03C.IsChecked = Common.VNCCoreLogging.ApplicationInitialize;
            ceArch04C.IsChecked = Common.VNCCoreLogging.Core;
            ceArch05C.IsChecked = Common.VNCCoreLogging.Module;
            ceArch06C.IsChecked = Common.VNCCoreLogging.ModuleInitialize;
            ceArch07C.IsChecked = Common.VNCCoreLogging.Application;
            ceArch08C.IsChecked = Common.VNCCoreLogging.ApplicationServices;
            ceArch09C.IsChecked = Common.VNCCoreLogging.Domain;
            ceArch10C.IsChecked = Common.VNCCoreLogging.DomainServices;
            ceArch11C.IsChecked = Common.VNCCoreLogging.Persistence;
            ceArch12C.IsChecked = Common.VNCCoreLogging.PersistenceLow;
            ceArch13C.IsChecked = Common.VNCCoreLogging.Infrastructure;
            ceArch14C.IsChecked = Common.VNCCoreLogging.Presentation;
            ceArch15C.IsChecked = Common.VNCCoreLogging.View;
            ceArch16C.IsChecked = Common.VNCCoreLogging.ViewLow;
            ceArch17C.IsChecked = Common.VNCCoreLogging.ViewModel;
            ceArch18C.IsChecked = Common.VNCCoreLogging.ViewModelLow;

            ceINPC.IsChecked = Common.VNCCoreLogging.INPC;

            if (Common.VNCLogging.EventHandler) Log.EVENT_HANDLER("Exit", Common.LOG_CATEGORY, startTicks);
        }
    }
}
