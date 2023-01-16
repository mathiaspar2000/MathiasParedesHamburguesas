using MathiasParedesHamburguesas.Mp_Models;
namespace MathiasParedesHamburguesas.Mp_Views;

public partial class BurgerListPage : ContentPage
{
    public BurgerListPage()
    {
        InitializeComponent();
        List<MpBurger> Mpburger = App.BurgerRepo.GetAllBurgers();
        burgerList.ItemsSource = Mpburger;
    }
    async void OnItemAdded(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(BurgerItemPage));
    }

    private void ActualizarDatos(object sender, EventArgs e)
    {
        List<MpBurger> Mpburger = App.BurgerRepo.GetAllBurgers();
        burgerList.ItemsSource = Mpburger;
    }
    private async void SelectedItem(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            var Mpburgers = (Mp_Models.MpBurger)e.CurrentSelection[0];
            await Shell.Current.GoToAsync($"{nameof(BurgerItemPage)}?{nameof(BurgerItemPage.ItemId)}={Mpburgers.Id}");
            burgerList.SelectedItem = null;
        }
    }

}