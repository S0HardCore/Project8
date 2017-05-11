using MahApps.Metro.Controls;

namespace WpfApplication2
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new AVM(productsGrid, new DefaultDialogService());
        }
    }
}