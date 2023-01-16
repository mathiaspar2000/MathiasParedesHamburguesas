using MathiasParedesHamburguesas.Mp_Data;
namespace MathiasParedesHamburguesas;

public partial class App : Application
{

    public static MpBurgerDatabase BurgerRepo { get; private set; }

    public App(MpBurgerDatabase repo)
    {
        InitializeComponent();

        MainPage = new AppShell();

        BurgerRepo = repo;
    }

}
