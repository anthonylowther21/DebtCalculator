using System;

namespace DebtCalculator.Library
{
  public class BaseClass
  {
    public BaseClass()
    {
      Id = Guid.NewGuid();
    }

    public Guid Id { get; private set; }
  }
}

