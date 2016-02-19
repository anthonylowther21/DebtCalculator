using Xamarin.Forms;

internal class PickerCell : ViewCell
{

  private Label _label { get; set; }
  private View _picker { get; set; }
  private StackLayout _layout { get; set; }

  internal string Label
  {
    get
    {
      return _label.Text;
    }
    set
    {
      _label.Text = value;
    }
  }

  internal View Picker
  {
    set
    {
      //Remove picker if it exists
      if (_picker != null)
      {
        _layout.Children.Remove(_picker);
      }

      //Set its value
      _picker = value;
      //Add to layout
      _layout.Children.Add(_picker);

    }
  }

  internal PickerCell()
  {

    _label = new Label()
      {
        VerticalOptions = LayoutOptions.Center,
        Font = Font.SystemFontOfSize(15)
      };
    _layout = new StackLayout()
      {
        Orientation = StackOrientation.Horizontal,
        HorizontalOptions = LayoutOptions.CenterAndExpand,
        Padding = new Thickness(15, 5),
        Children =
          {
            _label
          }
        };

    this.View = _layout;

  }

}