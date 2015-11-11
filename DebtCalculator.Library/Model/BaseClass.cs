using System;

namespace DebtCalculator.Library
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

