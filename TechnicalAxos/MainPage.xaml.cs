using TechnicalAxos.Core.ViewModels;
namespace TechnicalAxos;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        this.BindingContext = new MainPageViewModel();
    }
}