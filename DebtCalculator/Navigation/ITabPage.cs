using System;

namespace DebtCalculator
{
  public interface ITabPage
  {
    string TabIcon { get; }

    string SelectedTabIcon { get; }
  }
}

