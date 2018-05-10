
using System.Collections.ObjectModel;
using System.Linq;

namespace WpfTreeView_AngelSix_.ViewModel
{
    public class DirectoryStructureViewModel : BaseViewModel
    {
        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }

        public DirectoryStructureViewModel()
        {
            var children = DirectoryStructure.GetLogicalDrives();
            this.Items = new ObservableCollection<DirectoryItemViewModel>(
                children.Select(drive => new DirectoryItemViewModel(drive.FullPath,drive.Type)));
        }
    }


}
