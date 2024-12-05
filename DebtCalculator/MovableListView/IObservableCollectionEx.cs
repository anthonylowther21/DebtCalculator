using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;

namespace DebtCalculator.Shared
{
    public interface IObservableCollectionEx : INotifyCollectionChanged, INotifyPropertyChanged, IList
    {
        void Add(int index, object item);
        void Move(int oldIndex, int newIndex);
    }
}
