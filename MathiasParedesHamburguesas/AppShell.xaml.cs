namespace MathiasParedesHamburguesas;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(Mp_Views.BurgerItemPage), typeof(Mp_Views.BurgerItemPage));
        Routing.RegisterRoute(nameof(Mp_Views.BurgerListPage), typeof(Mp_Views.BurgerListPage));

    }
}
