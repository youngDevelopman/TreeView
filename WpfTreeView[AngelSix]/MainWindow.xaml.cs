
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using WpfTreeView_AngelSix_.ViewModel;

namespace WpfTreeView_AngelSix_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new DirectoryStructureViewModel();
        }
        
    }
}
