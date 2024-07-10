using EasyConsole;
using $safeprojectname$.Pages;

namespace $safeprojectname$.MenuPages
{
    class Concept1Menu : MenuPage
    {
        public Concept1Menu(Program program) : base("Page 1", program,
                  new Option("Page 1A", () => program.NavigateTo<Page1A>()),
                  new Option("Page 1B", () => program.NavigateTo<Page1B>()))
        {
        }
    }
}
