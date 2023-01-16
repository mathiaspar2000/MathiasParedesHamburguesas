using MathiasParedesHamburguesas.Mp_Models;
namespace MathiasParedesHamburguesas.Mp_Views;

public partial class BurgerListPage : ContentPage
{
    public BurgerListPage()
    {
        InitializeComponent();
        List<Burger> burger = App.BurgerRepo.GetAllBurgers();
        burgerList.ItemsSource = burger;
    }
    async void OnItemAdded(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(BurgerItemPage));
    }

    private void ActualizarDatos(object sender, EventArgs e)
    {
        List<Burger> burger = App.BurgerRepo.GetAllBurgers();
        burgerList.ItemsSource = burger;
    }
    private async void SelectedItem(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            var burgers = (Mp_Models.Burger)e.CurrentSelection[0];
            await Shell.Current.GoToAsync($"{nameof(BurgerItemPage)}?{nameof(BurgerItemPage.ItemId)}={burgers.Id}");
            burgerList.SelectedItem = null;
        }
    }

}