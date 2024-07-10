using EasyConsole;

namespace VNC_Console_Explore_Threading.Pages
{
    class $safeitemname$ : Page
    {
        public $safeitemname$(Program program) : base("$safeitemname$", program)
        {
        }

        public override void Display()
        {
            base.Display();

            Output.WriteLine("Hello from Page 1Biii");

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}
