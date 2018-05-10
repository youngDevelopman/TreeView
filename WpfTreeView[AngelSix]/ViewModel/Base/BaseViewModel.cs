using PropertyChanged;
using System.ComponentModel;

namespace WpfTreeView_AngelSix_
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
}