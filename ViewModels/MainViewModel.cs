using PlantCareApp.Support;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media;

namespace PlantCareApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<PlantCardViewModel> PlantCards { get; set; } = new ObservableCollection<PlantCardViewModel>();

        public ObservableCollection<EventViewModel> Events { get; set; } = new ObservableCollection<EventViewModel>();
        public ObservableCollection<string> Advice { get; }

        private PlantDatabase plantDatabase = new PlantDatabase();
        private RelayCommand _addPlantCommand;
        private RelayCommand _addEventCommand;
        private RelayCommand _showPlantPassportCommand;
        private string _plantNameToBeAdded = "";
        private string _plantIconPathToBeAdded = "";

        private EventViewModel _eventToBeAdded;
        private PlantCardViewModel _selectedPlant;
        private EventViewModel _selectedEvent;

        private int _currentIndex;
        public RelayCommand NextAdviceCommand { get; }
        public RelayCommand PreviousAdviceCommand { get; }

  //--------------ADD-PLANT-COMMAND-------------------//
        public RelayCommand AddPlantCommand
        {
            get { return _addPlantCommand ?? (_addPlantCommand = new RelayCommand(AddPlant, AddPlantCanExecute)); }
        }

        private void AddPlant(object obj)
        {
            if (string.IsNullOrEmpty(PlantNameToBeAdded))
            {
                PlantCards.Add(new PlantCardViewModel(this, "NEW PLANT!!!"));
            }
            else
            {
                var newPlantCard = new PlantCardViewModel(this, PlantNameToBeAdded);
                PlantCards.Add(newPlantCard);
                newPlantCard.CommonName = PlantNameToBeAdded;
            }
            PlantNameToBeAdded = "";
        }

        private bool AddPlantCanExecute(object obj)
        {
            return true;
        }
        public string PlantNameToBeAdded
        {
            get => _plantNameToBeAdded;
            set => SetProperty(ref _plantNameToBeAdded, value);
        }

//--------------ADD-EVENT-COMMAND-------------------//
        public RelayCommand AddEventCommand
        {
            get { return _addEventCommand ?? (_addEventCommand = new RelayCommand(AddEvent, AddEventCanExecute)); }
        }

        private void AddEvent(object obj)
        {
            Events.Add(_eventToBeAdded);
            _eventToBeAdded = null;
            Debug.WriteLine(Events.Count.ToString());
        }

        private bool AddEventCanExecute(object obj)
        {
            return true;
        }
        public EventViewModel EventToBeAdded
        {
            get => _eventToBeAdded;
            set => SetProperty(ref _eventToBeAdded, value);
        }
//-------------------------------------------------//

        public string CurrentAdvice => Advice.Count > 0 ? Advice[CurrentIndex] : string.Empty;
        public int CurrentIndex
        {
            get => _currentIndex;
            set
            {
                if (_currentIndex != value)
                {
                    _currentIndex = value;
                    OnPropertyChanged(nameof(CurrentIndex));
                    OnPropertyChanged(nameof(CurrentAdvice));
                }
            }
        }

        public PlantCardViewModel SelectedPlant
        {
            get => _selectedPlant;
            set
            {
                if (SetProperty(ref _selectedPlant, value))
                {
                    ShowPlantPassportCommand?.Execute(_selectedPlant);

                }

            }
        }

        public EventViewModel SelectedEvent
        {
            get => _selectedEvent;
            set
            {
                if (SetProperty(ref _selectedEvent, value))
                {
                    ShowPlantPassportCommand?.Execute(_selectedEvent);

                }
            }
        }
        private void NextAdvice()
        {
            if (CurrentIndex < Advice.Count - 1)
            {
                CurrentIndex++;
            }
        }
        private void PreviousAdvice()
        {
            if (CurrentIndex > 0)
            {
                CurrentIndex--;
            }
        }
        private RelayCommand<PlantCardViewModel> _setSelectedPlantCommand;

        public RelayCommand<PlantCardViewModel> SetSelectedPlantCommand
        {
            get { return _setSelectedPlantCommand ?? (_setSelectedPlantCommand = new RelayCommand<PlantCardViewModel>(SetSelectedPlant, SetSelectedPlantCanExecute)); }

        }
        
        private void SetSelectedPlant(PlantCardViewModel plantCard)
        {
            SelectedPlant = plantCard;
        }
        private bool SetSelectedPlantCanExecute(object obj)
        {
            return true;
        }
        public RelayCommand ShowPlantPassportCommand
        {   
            get { return _showPlantPassportCommand ?? (_showPlantPassportCommand = new RelayCommand(ShowPlantPassport, AddPlantCanExecute)); } 
        }
        private void ShowPlantPassport(object parameter)
        {
            if (parameter is PlantCardViewModel selectedPlant && selectedPlant != null)
            {
                var detailsWindow = new PlantPassport(selectedPlant);
                detailsWindow.ShowDialog();
                SelectedPlant = null;
               
            }
            else if (parameter is EventViewModel selectedEvent && selectedEvent != null)
            {
                var detailsWindow = new PlantPassport(selectedEvent.PlantCard);
                detailsWindow.ShowDialog();



            }


        }


        public void UpdateEvents(object obj, PlantCardViewModel pl)
        {

            if (pl == null)
            {
                return;
            }

            if (pl.MyTimerViewModel.TimeRemaining != null)
            {
                var sameEvents = Events.Where(evt => evt.PlantCard == pl).ToList();
                if (!sameEvents.Any())
                {
                    var newEvent = new EventViewModel(this, pl);
                    _eventToBeAdded = newEvent;
                    AddEvent(obj);
                }

            }
        }


        public void RemoveInvalidEvents()
        {
            PlantCards.CollectionChanged += (sender, e) =>
            {
                var invalidEvents = Events.Where(evt => evt.PlantCard == null || !PlantCards.Contains(evt.PlantCard)).ToList();

                foreach (var eventItem in invalidEvents)
                {
                    Events.Remove(eventItem);
                    
                }
            };
        }

        public MainViewModel()
        {
            plantDatabase.FillDatabase();

            for (int i = 0; i < 5; i++)
            {
                PlantCardViewModel pl = new PlantCardViewModel(this, plantDatabase.Plants[i].CommonName);
                pl.ScientificName = plantDatabase.Plants[i].ScientificName;
                pl.RequiredLighting = plantDatabase.Plants[i].RequiredLighting;
                pl.RequiredWatering = plantDatabase.Plants[i].RequiredWatering;
                pl.IconPath=plantDatabase.Plants[i].IconPath;
                pl.Description=plantDatabase.Plants[i].Description;
                

                PlantCards.Add(pl);
            }

            PlantCards.Add(new PlantCardViewModel(this, "Cactus"));
            PlantCards.Add(new PlantCardViewModel(this, "European ash"));
            PlantCards.Add(new PlantCardViewModel(this, "Evergreen oak"));

           

            Advice = new ObservableCollection<string>
            {
                "Know your plants: research the specific care requirements for each plant species you own, including light, water, and temperature preferences.",
                "Water properly: overwatering and underwatering can both harm plants. Check the soil moisture before watering, and ensure proper drainage in pots.",
                "Use the right soil: different plants have different soil needs. Use soil tailored to your plant’s needs (e.g., cacti need well-draining, sandy soil, while ferns prefer moisture-retaining soil).",
                "Provide adequate lighting: place your plants where they receive the right amount of light—some need direct sunlight, while others thrive in low-light conditions.",
                "Avoid direct heat: keep plants away from heat sources like radiators, heating vents, or stoves to prevent dehydration.",
                "Humidity is key: many plants, especially tropical ones, prefer high humidity. Consider using a humidifier or misting the leaves occasionally.",
                "Fertilize regularly: plants need nutrients to grow. Use appropriate fertilizers for the growing season (usually during spring and summer) and follow instructions on the packaging.",
                "Repot when necessary: if a plant’s roots are growing out of the pot or the plant appears stunted, it’s time to repot it into a larger container.",
                "Trim dead leaves: regularly prune dead or damaged leaves to encourage healthy growth and improve the plant’s appearance.",
                "Check for pests: inspect your plants regularly for pests, like aphids or spider mites. Treat any infestations promptly to avoid damage.",
                "Rotate plants: rotate your plants occasionally so they grow evenly and don’t lean toward the light source.",
                "Ensure proper drainage: always use pots with drainage holes to prevent water from accumulating in the bottom and causing root rot.",
                "Choose the right pot: select a pot that fits the plant’s size and offers enough room for root growth.",
                "Support tall plants: for taller plants, provide support using stakes or trellises to help them grow upright.",
                "Monitor temperature: most plants prefer a consistent temperature. Avoid sudden temperature changes, and keep them away from drafts or air conditioners.",
                "Maintain clean leaves: dust can block sunlight. Wipe the leaves gently with a damp cloth to keep them clean and allow for proper photosynthesis.",
                "Acclimate new plants: when bringing new plants home, give them time to adjust to their new environment gradually, especially if the light or temperature is different.",
                "Watch for signs of stress: pay attention to yellowing leaves, wilting, or stunted growth, which could indicate a problem with watering, light, or pests.",
                "Avoid overcrowding: don’t place too many plants in a small space. Plants need airflow to thrive, so give them enough room to grow.",
                "Enjoy the process: caring for plants is a rewarding experience. Take time to appreciate their growth and the sense of calm they bring into your environment."
            };
            CurrentIndex = 0;

            NextAdviceCommand = new RelayCommand(_ => NextAdvice(), _ => Advice.Count > 0);
            PreviousAdviceCommand = new RelayCommand(_ => PreviousAdvice(), _ => Advice.Count > 0);
         

        }
    }
}
