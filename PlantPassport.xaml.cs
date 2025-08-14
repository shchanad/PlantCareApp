using PlantCareApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace PlantCareApp
{
    /// <summary>
    /// Interaction logic for PlantPassport.xaml
    /// </summary>
    public partial class PlantPassport : Window
    {
        public PlantPassport(PlantCardViewModel selectedPlant)
        {
            InitializeComponent();
            DataContext = new { SelectedPlant = selectedPlant };
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            dynamic context = DataContext;
            if (context?.SelectedPlant is PlantCardViewModel selectedPlant)
            {
                selectedPlant.UpdateEvent(sender);
            }
        }
        private void ClickDeleteButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
