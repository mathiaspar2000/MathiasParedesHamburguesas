using MathiasParedesHamburguesas.Mp_Models;
namespace MathiasParedesHamburguesas.Mp_Views;

public partial class BurgerListPage : ContentPage
{
    public BurgerListPage()
    {
        InitializeComponent();
        BindingContext = this;
    }
    async void OnItemAdded(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(BurgerItemPage), true, new Dictionary <string, object>
        {
            ["Item"] = new MpBurger()
        });
    }

    private void ActualizarDatos(object sender, EventArgs e)
    {
        List<MpBurger> Mpburger = App.BurgerRepo.GetAllBurgers();
        burgerList.ItemsSource = Mpburger;
    }
   

    private void CollectionView_SelectionChanced(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not MpBurger Item)
            return;
        
        Shell.Current.GoToAsync(nameof(BurgerItemPage), true,new Dictionary< string, object>
            {
                ["Item"] = Item
            });

    }



}