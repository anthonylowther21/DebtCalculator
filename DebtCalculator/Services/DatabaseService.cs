using System;
using System.Collections.Generic;
using DebtCalculator.Library;

namespace DebtCalculator
{
  public class DatabaseService : IDatabaseService
  {
    private List<DebtEntry> _debts;
    private List<SalaryEntry> _salaries;

    public DatabaseService ()
    {
      _debts = InitDebts();
      _salaries = InitSalaries();
    }

    public void UpdateDebt (DebtEntry newDebt)
    {
      var oldDebt = null;

      foreach (var debt in _debts)
      {
        if (debt.Id = newDebt.Id)
        {
          oldDebt = debt;
          break;
        }
      }

      if (oldDebt != null)
      {
        oldDebt.Name = newDebt.Name;
      }
      else
      {
        _debts.Add(newDebt);
      }
    }

    public void UpdateSalary (SalaryEntry newItem)
    {
      var oldItem = null;

      foreach (var item in _salaries)
      {
        if (item.Id = newItem.Id)
        {
          oldItem = item;
          break;
        }
      }

      if (oldItem != null)
      {
        oldItem.Name = newItem.Name;
      }
      else
      {
        _salaries.Add(newItem);
      }
    }

    public List<DebtEntry> GetDebts ()
    {
      return _debts;
    }

    public List<SalaryEntry> GetSalaries ()
    {
      return _salaries;
    }

    private List<DebtEntry> InitDebts ()
    {
      return new List<DebtEntry> {
        new Contact { Id = 1, Name = "Xam Consulting", Phone = "0404 865 350" },
        new Contact { Id = 2, Name = "Michael Ridland", Phone = "0404 865 350" },
        new Contact { Id = 3, Name = "Thunder Apps", Phone = "0404 865 350" },
      };
    }

    private List<Quote> InitQuotes ()
    {
      return new List<Quote> {
        new Quote { Id = 1, CustomerName = "Xam Consulting", Total = "$350.00" },
        new Quote { Id = 2, CustomerName = "Michael Ridland", Total = "$3503.00" },
        new Quote { Id = 3, CustomerName = "Thunder Apps", Total = "$3504.00" },
      };
    }
  }
}

