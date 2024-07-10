using EasyConsole;

namespace VNC_Console_Explore_Threading.Pages
{
    class $safeitemname$ : MenuPage
    {
        public $safeitemname$(Program program) : base("$safeitemname$", program,
                  new Option("Page 1Bi", () => program.NavigateTo<Page1Bi>()),
                  new Option("Page 1Bii", () => program.NavigateTo<Page1Bii>())
            )
        {
        }

        public override void Display()
        {
            base.Display();

            Output.WriteLine("Hello from Page 1B");

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}
