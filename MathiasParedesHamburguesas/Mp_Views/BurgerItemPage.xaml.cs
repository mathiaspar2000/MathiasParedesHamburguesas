using MathiasParedesHamburguesas.Mp_Models;
namespace MathiasParedesHamburguesas.Mp_Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class BurgerItemPage : ContentPage
{
    MpBurger Item = new MpBurger();
    MpBurger aux = new MpBurger();
    bool _flag;
    public int ItemId
    {
        get { return ItemId; }
        set { loadBurger(value); }
    }
    public BurgerItemPage()
    {
        List<MpBurger> burger = App.BurgerRepo.GetAllBurgers();
        //burgerList.ItemsSource = burger; 
        InitializeComponent();
    }
    private void loadBurger(int id)
    {
        Mp_Models.MpBurger burgerSearch = new Mp_Models.MpBurger();
        burgerSearch = App.BurgerRepo.getID(id);
        aux = burgerSearch;
        BindingContext = burgerSearch;
    }
    private async void OnSaveClicked(object sender, EventArgs e)
    {
        if (BindingContext == null)
        {
            Item.Name = nameB.Text;
            Item.Description = descB.Text;
            Item.WithExtraCheese = _flag;
            App.BurgerRepo.AddNewBurger(Item);
        }
        else
        {
            App.BurgerRepo.updateData(aux.Id, aux.Name, aux.Description, aux.WithExtraCheese);
            await Shell.Current.GoToAsync("..");
        }
    }
    private void OnDeleteClicked(object sender, EventArgs e)
    {
        App.BurgerRepo.deleteBurger(ItemId);
        Shell.Current.GoToAsync("..");
    }
    private void OnCancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
    private void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        _flag = e.Value;
    }
}