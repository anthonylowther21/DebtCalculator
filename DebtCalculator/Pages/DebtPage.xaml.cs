using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DebtCalculator.Shared
{
	public partial class DebtPage : MyBasePage
	{
		public DebtPage ()
		{
      this.BindingContext = new DebtPageModel();

			InitializeComponent ();
		}
	}
}

