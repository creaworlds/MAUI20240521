using TechnicalAxos.Core.ViewModels;
namespace TechnicalAxos;

public partial class ListViewPage : ContentPage
{
    public ListViewPage()
    {
        InitializeComponent();
        this.BindingContext = new ListViewPageViewModel(this);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (this.BindingContext is ListViewPageViewModel vm)
        {
            vm.RefreshData.Execute(null);
        }
    }
}