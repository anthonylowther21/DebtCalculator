using Xamarin.Forms;
using Acr.UserDialogs;

namespace DebtCalculator.Shared
{
  /// <summary>
  /// Each ContentPage is required to align with a corresponding ViewModel
  /// ViewModels will be the BindingContext by default
  /// </summary>
  public class BaseContentPage<T> : ContentPage where T : BaseViewModel, new()
  {
    protected T _viewModel;

    public T ViewModel 
    {
      get 
      {
        return _viewModel ?? (_viewModel = new T ());
      }
    }

    public void ApplyTheme (NavigationPage nav)
    {
      nav.BarBackgroundColor = BarBackgroundColor;
      nav.BarTextColor = BarTextColor;
    }

    async public void ShowModalMessage (string title, string text)
    {
      await UserDialogs.Instance.AlertAsync (new AlertConfig 
      {
        Title = title,
        Message = text
      });
    }

    public BaseContentPage ()
    {
      BindingContext = ViewModel;
    }

    public Color BarTextColor 
    {
      get;
      set;
    }

    public Color BarBackgroundColor 
    {
      get;
      set;
    }

    ~BaseContentPage ()
    {
      _viewModel = null;
    }
  }
}