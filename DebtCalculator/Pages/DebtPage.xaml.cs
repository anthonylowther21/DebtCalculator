using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DebtCalculator.Pages
{
	public partial class DebtPage : MyBasePage
	{
		public DebtPage ()
		{
			InitializeComponent ();

      NavigationPage navPage = ((this as Page) as NavigationPage);
		}
	}
}

