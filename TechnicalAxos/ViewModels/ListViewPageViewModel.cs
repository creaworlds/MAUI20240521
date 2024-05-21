using System.ComponentModel;
using System.Windows.Input;
using TechnicalAxosModels.Countries;
using TechnicalAxosServices;

namespace TechnicalAxos.Core.ViewModels;

public class ListViewPageViewModel : INotifyPropertyChanged
{
    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged(string propertyName)
    {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion

    #region CountriesList
    private CountryData[]? _countriesList;
    public CountryData[]? CountriesList
    {
        get => this._countriesList;
        set
        {
            this._countriesList = value;
            this.OnPropertyChanged(nameof(this.CountriesList));
        }
    }
    #endregion

    #region IsLoading
    private bool _isLoading = false;
    public bool IsLoading
    {
        get => this._isLoading;
        private set
        {
            this._isLoading = value;
            this.OnPropertyChanged(nameof(this.IsLoading));
        }
    }
    #endregion

    public Page Parent { get; private set; }
    public ICommand RefreshData { get; private set; }

    public ListViewPageViewModel(Page parent)
    {
        this.Parent = parent;
        this.RefreshData = new Command(async () => await this.LoadData());
    }

    private async Task LoadData()
    {
        if (this.CountriesList == null || this.CountriesList.Length == 0)
        {
            this.IsLoading = true;
            var response = await Country.List();
            this.IsLoading = false;

            if (response.Success)
            {
                this.CountriesList = response.Result;
            }
            else
            {
                await this.Parent.DisplayAlert("Error", response.Message, "Aceptar");
            }
        }
        this.IsLoading = false;
    }
}