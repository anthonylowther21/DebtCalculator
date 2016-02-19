﻿using System;
using FreshMvvm;
using Xamarin.Forms;

namespace DebtCalculator.PageModels
{
  public class SaveModalPageModel : FreshBasePageModel
    {
        public SaveModalPageModel ()
        {
        }

        public Command CloseCommand {
            get {
                return new Command (() => {
                    CoreMethods.PopPageModel (true);
                });
            }
        }
    }
}

