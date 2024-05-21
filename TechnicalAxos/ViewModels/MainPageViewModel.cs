using System.ComponentModel;
using System.Windows.Input;

namespace TechnicalAxos.Core.ViewModels;

public class MainPageViewModel : INotifyPropertyChanged
{
    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged(string propertyName)
    {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion

    /// <summary>
    /// Url de la Imagen
    /// </summary>
    private string _imageUrl = "https://random.dog/af70ad75-24af-4518-bf03-fec4a997004c.jpg";
    public string ImageUrl
    {
        get => this._imageUrl;
        set
        {
            this._imageUrl = value;
            this.OnPropertyChanged(nameof(ImageUrl));
        }
    }

    /// <summary>
    /// Devuelve el nombre de la plataforma
    /// </summary>
    public string Title { get => this.appService.GetApplicationName(); }

    /// <summary>
    /// Devuelve el texto de descripción
    /// </summary>
    public string Description { get; set; } = "Soy un desarrollador Microsoft .NET especializado en MAUI, con una sólida experiencia en Xamarin, lo que me permite llevar aplicaciones móviles a la vanguardia tecnológica. Mi habilidad para combinar la estabilidad de .NET con las capacidades avanzadas de MAUI me permite crear aplicaciones eficientes y de alto rendimiento. Además, mi experiencia en el desarrollo cross-platform asegura que puedo optimizar y mantener aplicaciones en múltiples plataformas con una única base de código, ahorrando tiempo y recursos. Estoy comprometido con la excelencia en el desarrollo, la innovación continua y la entrega de soluciones de calidad que superen las expectativas del cliente.";

    private readonly AppService appService;
    public MainPageViewModel()
    {
        this.appService = new AppService();
        this.ChangeImage = new Command(async () => await this.SelectImage());
    }


    public ICommand ChangeImage { get; private set; }

    private async Task SelectImage()
    {
        try
        {
            var result = await MediaPicker.PickPhotoAsync();

            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                var filePath = result.FullPath;
                this.ImageUrl = filePath;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error picking file: {ex.Message}");
        }
    }
}