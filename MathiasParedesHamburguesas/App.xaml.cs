using MathiasParedesHamburguesas.Mp_Data;
namespace MathiasParedesHamburguesas;

public partial class App : Application
{

    public static BurgerDatabase BurgerRepo { get; private set; }

    public App(BurgerDatabase repo)
    {
        InitializeComponent();

        MainPage = new AppShell();

        BurgerRepo = repo;
    }

}
