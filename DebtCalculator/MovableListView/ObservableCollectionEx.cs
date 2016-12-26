using System;
using System.Collections.ObjectModel;

namespace DebtCalculator.Shared
{
    public class ObservableCollectionEx<T> : ObservableCollection<T>, IObservableCollectionEx
    {
        public void Add(int index, object item)
        {
            if (Items.IsReadOnly)
                throw new NotSupportedException("NotSupported_ReadOnlyCollection");

            InsertItem(index, (T)item);
        }
    }
}
