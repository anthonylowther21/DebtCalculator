using System;

namespace DebtCalculatorLibrary.Library
{
  public class BaseClass
  {
    public BaseClass()
    {
      Id = new Guid();
    }

    public Guid Id { get; private set; }
  }
}

