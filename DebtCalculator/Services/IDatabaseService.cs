using System;
using System.Collections.Generic;
using DebtCalculator.Library;

namespace DebtCalculator
{
  public interface IDatabaseService
  {
    List<DebtEntry> GetDebts ();

    void UpdateDebt (DebtEntry contact);

    List<SalaryEntry> GetSalaries ();

    void UpdateSalary (SalaryEntry quote);
  }
}

