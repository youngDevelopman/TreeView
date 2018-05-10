﻿
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using WpfTreeView_AngelSix_.ViewModel;

namespace WpfTreeView_AngelSix_
{
    public class DirectoryItemViewModel : BaseViewModel
    {
        public DirectoryItemType Type { get; set; }

        public string FullPath { get; set; }

        public string Name { get { return this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(this.FullPath); } }

        public string ImageName => Type == DirectoryItemType.Drive ? "drive" : (Type == DirectoryItemType.File ? "file" : (IsExpanded ? "folder-open" : "folder-closed"));

        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }

        public bool CanExpand { get { return this.Type != DirectoryItemType.File; } }

        public bool IsExpanded
        {
            get
            {
                return this.Children?.Count(f => f != null) > 0;
            }
            set
            {
                if(value == true)
                {
                    Expand();
                }
                else
                {
                    this.ClearChildren();

                    if(this.Type != DirectoryItemType.File)
                    {
                        this.Children.Add(null);
                    }
                }
            }
        }

        public ICommand ExpandCommand { get; set; }

        public DirectoryItemViewModel(string fullPath, DirectoryItemType type)
        {
            this.ExpandCommand = new RelayCommand(Expand);

            this.FullPath = fullPath;
            this.Type = type;

            this.ClearChildren();
        }

        private void Expand()
        {
            if (this.Type == DirectoryItemType.File)
                return;

            var children = DirectoryStructure.GetDirectoryContents(this.FullPath);

            this.Children = new ObservableCollection<DirectoryItemViewModel>(children.Select
                (content => new DirectoryItemViewModel(content.FullPath,content.Type)));
        }

        private void ClearChildren()
        {
            this.Children = new ObservableCollection<DirectoryItemViewModel>();
        }
    }
}
