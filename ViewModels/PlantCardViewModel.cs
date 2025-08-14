using PlantCareApp.ViewModels;
using PlantCareApp.Support;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Input;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Numerics;
using System.Collections.ObjectModel;
using System;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace PlantCareApp.ViewModels
{
    public class PlantCardViewModel : ViewModelBase
    {
      
        public PlantCardViewModel(MainViewModel mainViewModelReference, string commonName)
        {
            _mainViewModelReference = mainViewModelReference;
          
            CommonName = commonName;
            IconPath = "../../../Images/daisy.png";
            MyTimerViewModel = new TimerViewModel();
          
        }

        public PlantCardViewModel( string commonName, string scientificName, string requiredLighting, string watering, string imagePath, string description)
        {
            CommonName = commonName;
            ScientificName = scientificName;
            RequiredLighting = requiredLighting;
            RequiredWatering = watering;
            IconPath = imagePath;
            Description = description;
            MyTimerViewModel = new TimerViewModel();

        }

        private MainViewModel _mainViewModelReference;

        private TimerViewModel _myTimerViewModel;
        private string _commonName;
        private string _scientificName;
        public string _requiredLighting;
        public string _requiredWatering;
        public string _description;

        
        private string _iconPath;
        private Brush _plantImageBrush;
        private RelayCommand _selectImageCommand;
        private RelayCommand _removePlantCommand;
        private RelayCommand _updateEventCommand;


        public string CommonName
        {
            get => _commonName;
            set => SetProperty(ref _commonName, value);
        }
        public TimerViewModel MyTimerViewModel
        {
            get => _myTimerViewModel;
            set => SetProperty(ref _myTimerViewModel, value);
        }

        public string ScientificName
        {
            get => _scientificName;
            set => SetProperty(ref _scientificName, value);
        }

        public string RequiredLighting
        {
            get => _requiredLighting;
            set => SetProperty(ref _requiredLighting, value);
        }
        public string RequiredWatering
        {
            get => _requiredWatering;
            set => SetProperty(ref _requiredWatering, value);
        }

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public string IconPath
        {
            get => _iconPath;
            set => SetProperty(ref _iconPath, value);
        }

        public Brush PlantImageBrush
        {
            get
            {
                if (string.IsNullOrEmpty(IconPath))
                    return Brushes.Transparent;

                return new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(IconPath, UriKind.RelativeOrAbsolute))
                };
            }
            set
            {
                if (_plantImageBrush != value)
                {
                    _plantImageBrush = value;
                    OnPropertyChanged(nameof(PlantImageBrush));
                }
            }
        }

        public RelayCommand SelectImageCommand
        {
            get { return _selectImageCommand ?? (_selectImageCommand = new RelayCommand(SelectImage, SelectImageCanExecute)); }
        }

        private void SelectImage(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                Title = "Select an Image"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                IconPath = openFileDialog.FileName;
                PlantImageBrush = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(IconPath))
                };
            }
        }

        private bool SelectImageCanExecute(object obj)
        {
            return true;
        }

        public RelayCommand UpdateEventCommand
        {
            get { return _updateEventCommand ?? (_updateEventCommand = new RelayCommand(UpdateEvent, UpdateEventCanExecute)); }
        }
        public void UpdateEvent(object obj)
        {
            _mainViewModelReference.UpdateEvents(obj, this);
        }

        private bool UpdateEventCanExecute(object obj)
        {
            return true;
        }


     

        public RelayCommand RemovePlantCommand
        {
            get { return _removePlantCommand ?? (_removePlantCommand = new RelayCommand(RemovePlant, RemovePlantCanExecute)); }
        }
        private void RemovePlant(object obj)
        {
            _mainViewModelReference.PlantCards.Remove(this);
            _mainViewModelReference.RemoveInvalidEvents();
        }
        private bool RemovePlantCanExecute(object obj)
        {
            return true;
        }
    }


}
