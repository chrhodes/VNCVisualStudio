using System;
using System.Reflection;
using System.Windows.Forms;

namespace VNCVSProjectWizard
{
    public partial class Form1 : Form
    {
        private static string _cUSTOM5;
        private static string _cUSTOM4;
        private static string _cUSTOM3;
        private static string _cUSTOM2;
        private static string _cUSTOM1;
        private static string customAPPLICATION;
        private static string customMODULE;
        private static string customNAMESPACE;

        private static string customEVENT;
        private static string customTYPE;
        private static string customITEM;

        private static string customACTION;

        public Form1()
        {
            InitializeComponent();
            //lblAppVersion.Text = Assembly.GetExecutingAssembly().GetCustomAttribute(typeof(AssemblyInformationalVersionAttribute)).ToString();
            var aiva = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), false);

            lblAppVersion.Text = ((AssemblyInformationalVersionAttribute)aiva[0]).InformationalVersion.ToString();
        }

        public static string CustomAPPLICATION
        {
            get
            {
                return customAPPLICATION;
            }
            set
            {
                customAPPLICATION = value;
            }
        }

        public static string CustomMODULE
        {
            get
            {
                return customMODULE;
            }
            set
            {
                customMODULE = value;
            }
        }

        public static string CustomNAMESPACE
        {
            get
            {
                return customNAMESPACE;
            }
            set
            {
                customNAMESPACE = value;
            }
        }

        public static string CustomEVENT
        {
            get
            {
                return customEVENT;
            }
            set
            {
                customEVENT = value;
            }
        }

        public static string CustomTYPE
        {
            get
            {
                return customTYPE;
            }
            set
            {
                customTYPE = value;
            }
        }

        public static string CustomITEM
        {
            get
            {
                return customITEM;
            }
            set
            {
                customITEM = value;
            }
        }

        public static string CustomACTION
        {
            get
            {
                return customACTION;
            }
            set
            {
                customACTION = value;
            }
        }


        public static string CUSTOM1
        {
            get => _cUSTOM1;
            set => _cUSTOM1 = value;
        }


        public static string CUSTOM2
        {
            get => _cUSTOM2;
            set => _cUSTOM2 = value;
        }


        public static string CUSTOM3
        {
            get => _cUSTOM3;
            set => _cUSTOM3 = value;
        }


        public static string CUSTOM4
        {
            get => _cUSTOM4;
            set => _cUSTOM4 = value;
        }

        
        public static string CUSTOM5
        {
            get => _cUSTOM5;
            set => _cUSTOM5 = value;
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            customAPPLICATION = txtAPPLICATION.Text;
            customMODULE = txtMODULE.Text;
            customNAMESPACE = txtNAMESPACE.Text;

            customEVENT = txtEVENT.Text;
            customTYPE = txtTYPE.Text;
            customITEM = txtITEM.Text;

            customACTION = txtACTION.Text;

            _cUSTOM1 = txtCUSTOM1.Text;
            _cUSTOM2 = txtCUSTOM2.Text;
            _cUSTOM3 = txtCUSTOM3.Text;
            _cUSTOM4 = txtCUSTOM4.Text;
            _cUSTOM5 = txtCUSTOM5.Text;

            this.Close();
        }
    }
}
