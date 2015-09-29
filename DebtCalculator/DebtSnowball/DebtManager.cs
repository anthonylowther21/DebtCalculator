using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace DebtCalculator
{
	public class DebtManager
	{
        private Collection<DebtEntry> _debtEntries;

        static public DebtManager CreateDebtManager()
        {
            return new DebtManager();
        }

        protected DebtManager ()
		{
            _debtEntries = new Collection<DebtEntry>();
		}

        public IEnumerable<DebtEntry> DebtEntries 
        { 
			get { return _debtEntries.ToArray(); } 
        }

        public bool AddDebtEntry(DebtEntry debtEntry)
        {
            _debtEntries.Add(debtEntry);
            return true;
        }
	}
}

