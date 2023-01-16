using MathiasParedesHamburguesas.Mp_Models;
namespace MathiasParedesHamburguesas.Mp_Views;

[QueryProperty(nameof(Item), nameof(Item))]
public partial class BurgerItemPage : ContentPage
{
 //   MpBurger ItemN = new MpBurger();
   // MpBurger aux = new MpBurger();
    bool _flag;
    public MpBurger Item
    {
        get => BindingContext as MpBurger;
        set => BindingContext = value;
    }
    public BurgerItemPage()
    {
       // List<MpBurger> burger = App.BurgerRepo.GetAllBurgers();
        //burgerList.ItemsSource = burger; 
        InitializeComponent();
    }
    //private void loadBurger(int id)
    //{
        //Mp_Models.MpBurger burgerSearch = new Mp_Models.MpBurger();
        //burgerSearch = App.BurgerRepo.getID(id);
        //aux = burgerSearch;
        //BindingContext = burgerSearch;
    //}
    private async void OnSaveClicked(object sender, EventArgs e)
    {
        //if (BindingContext == null)
        //{
        //  ItemN.Name = nameB.Text;
        //ItemN.Description = descB.Text;
        //ItemN.WithExtraCheese = _flag;
        //App.BurgerRepo.AddNewBurger(ItemN);
        //}
        //else
        //{
        //  App.BurgerRepo.updateData(aux.Id, aux.Name, aux.Description, aux.WithExtraCheese);
        // await Shell.Current.GoToAsync("..");
        //}
        App.BurgerRepo.AddNewBurger(Item);
        Shell.Current.GoToAsync("..");
    }
    private void OnDeleteClicked(object sender, EventArgs e)
    {
        if (Item.Id==0)
        {
            return;
        }
        App.BurgerRepo.deleteBurger(Item);
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