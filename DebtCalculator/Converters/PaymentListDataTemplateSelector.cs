using System;
using Xamarin.Forms;
using DebtCalculator.Library;
namespace DebtCalculator.Shared
{
  public class PaymentListDataTemplateSelector : Xamarin.Forms.DataTemplateSelector
  {
    public PaymentListDataTemplateSelector ()
    {
      // Retain instances!
      this.snowballTemplate = new DataTemplate (typeof (SnowballItemView));
      this.salaryTemplate = new DataTemplate (typeof (SalaryItemView));
      this.windfallTemplate = new DataTemplate (typeof (WindfallItemView));
    }

    protected override DataTemplate OnSelectTemplate (object item, BindableObject container)
    {
      if (item is SnowballEntry)
        return snowballTemplate;
      else if (item is SalaryEntry)
        return salaryTemplate;
      else if (item is WindfallEntry)
        return windfallTemplate;
      else
        return null;
    }

    private readonly DataTemplate snowballTemplate;
    private readonly DataTemplate salaryTemplate;
    private readonly DataTemplate windfallTemplate;
  }
}

