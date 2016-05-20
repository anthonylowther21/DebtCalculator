using System;
using CoreGraphics;
using Xamarin.Forms;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using Foundation;
using System.ComponentModel;
using XLabs.Forms.Controls;
using DebtCalculator.Shared;

[assembly: ExportRenderer(typeof(CustomDatePicker), typeof(DebtCalculator.iOS.CustomDatePickerRenderer))]
namespace DebtCalculator.iOS
{
  public class CustomDatePickerRenderer : ViewRenderer<CustomDatePicker, UITextField>
  {
    /// <summary>
    /// The _picker
    /// </summary>
    UIDatePicker _picker;
    /// <summary>
    /// The _pop over
    /// </summary>
    UIPopoverController _popOver;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExtendedDatePickerRenderer"/> class.
    /// </summary>
    public CustomDatePickerRenderer ()
    {
    }

    /// <summary>
    /// Sets the border.
    /// </summary>
    /// <param name="view">The view.</param>
    private void SetBorder(DatePicker view)
    {
      //Control.BorderStyle = view.HasBorder ? UITextBorderStyle.RoundedRect : UITextBorderStyle.None;
    }

    //
    // Methods
    //
    /// <summary>
    /// Handles the value changed.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    private void HandleValueChanged (object sender, EventArgs e)
    {
      Element.Date = _picker.Date.ToDateTime ();
    }

    /// <summary>
    /// Called when [element changed].
    /// </summary>
    /// <param name="e">The e.</param>
    protected override void OnElementChanged (ElementChangedEventArgs<CustomDatePicker> e)
    {
      base.OnElementChanged (e);
      UITextField entry = new NoCaretField {
        BorderStyle = UITextBorderStyle.RoundedRect
      };
      entry.Started += new EventHandler (OnStarted);
      entry.Ended += new EventHandler (OnEnded);
      _picker = new UIDatePicker {
        Mode = UIDatePickerMode.Date,
        TimeZone = new NSTimeZone ("UTC")
      };

      entry.InputView = _picker;
      entry.InputAccessoryView = KeyboardInputAccessoryHelper.CreateAccessoryToolbar (() => entry.ResignFirstResponder());

      SetNativeControl (entry);
      UpdateDateFromModel (false);
      UpdateMaximumDate ();
      UpdateMinimumDate ();
      _picker.ValueChanged += new EventHandler (HandleValueChanged);

      var view = (DatePicker)Element;

      SetBorder(view);
    }

    /// <summary>
    /// Handles the <see cref="E:ElementPropertyChanged" /> event.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
    protected override void OnElementPropertyChanged (object sender, PropertyChangedEventArgs e)
    {
      base.OnElementPropertyChanged (sender, e);
      if (e.PropertyName == DatePicker.DateProperty.PropertyName || e.PropertyName == DatePicker.FormatProperty.PropertyName) 
      {
        UpdateDateFromModel (true);
        return;
      }
      if (e.PropertyName == DatePicker.MinimumDateProperty.PropertyName) {
        UpdateMinimumDate ();
        return;
      }
      if (e.PropertyName == DatePicker.MaximumDateProperty.PropertyName) {
        UpdateMaximumDate ();
      }

      var view = (CustomDatePicker)Element;

      if (e.PropertyName == ExtendedTimePicker.HasBorderProperty.PropertyName)
        SetBorder(view);
    }

    /// <summary>
    /// Handles the <see cref="E:Ended" /> event.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="eventArgs">The <see cref="EventArgs"/> instance containing the event data.</param>
    private void OnEnded (object sender, EventArgs eventArgs)
    {
      //base.Element.IsFocused = false;
    }

    /// <summary>
    /// Handles the <see cref="E:Started" /> event.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="eventArgs">The <see cref="EventArgs"/> instance containing the event data.</param>
    private void OnStarted (object sender, EventArgs eventArgs)
    {
      //base.Element.IsFocused = true;

//      if (Device.Idiom != TargetIdiom.Phone) 
//      {
//        var vc = new UIViewController ();
//        vc.Add (_picker);
//        vc.View.Frame = new CGRect (0, 0, 320, 200);
//        vc.PreferredContentSize = new CGSize (320, 200);
//        _popOver = new UIPopoverController (vc);
//        _popOver.PresentFromRect(new CGRect(Control.Frame.Width/2,Control.Frame.Height-3,0,0), Control, UIPopoverArrowDirection.Any, true);
//        _popOver.DidDismiss += (object s, EventArgs e) => {
//          _popOver = null;
//          Control.ResignFirstResponder();
//        };
//      }
    }

    /// <summary>
    /// Updates the date from model.
    /// </summary>
    /// <param name="animate">if set to <c>true</c> [animate].</param>
    private void UpdateDateFromModel (bool animate)
    {
      _picker.SetDate (Element.Date.ToNSDate (), animate);
      //Control.SetDate (Element.Date, true);
      Control.Text = Element.Date.ToString (Element.Format);
    }

    /// <summary>
    /// Updates the maximum date.
    /// </summary>
    private void UpdateMaximumDate ()
    {
      _picker.MaximumDate = Element.MaximumDate.ToNSDate ();
    }

    /// <summary>
    /// Updates the minimum date.
    /// </summary>
    private void UpdateMinimumDate ()
    {
      _picker.MinimumDate = Element.MinimumDate.ToNSDate ();
    }
  }
}

