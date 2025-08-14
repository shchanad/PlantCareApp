using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PlantCareApp
{
    /// <summary>
    /// Interaction logic for PlantUserControl.xaml
    /// </summary>
    public partial class PlantUserControl : UserControl
    {

        public static readonly DependencyProperty CommonNameProperty =
        DependencyProperty.Register("CommonName", typeof(string), typeof(PlantUserControl), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty PlantImageProperty=
        DependencyProperty.Register("PlantImage", typeof(Brush), typeof(PlantUserControl), new PropertyMetadata(Brushes.Transparent));

        public string CommonName
        {
            get { return (string)GetValue(CommonNameProperty); }
            set { SetValue(CommonNameProperty, value); }
        }

        public Brush PlantImage
        {
            get { return (Brush)GetValue(PlantImageProperty); }
            set { SetValue(PlantImageProperty, value); }
        }

        public PlantUserControl()
        {
            InitializeComponent();
            
        }

    }
}
