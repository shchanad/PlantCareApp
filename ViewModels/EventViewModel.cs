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

using System.Threading.Tasks;


namespace PlantCareApp.ViewModels
{
    public class EventViewModel : ViewModelBase
    {

        public EventViewModel(MainViewModel mainViewModel, PlantCardViewModel plantCard)
        {
            _plantCard = plantCard;
            CommonName = plantCard.CommonName;
            RequiredWatering= plantCard.RequiredWatering;
            _myTimerViewModel = plantCard.MyTimerViewModel;
            _mainViewModelReference = mainViewModel;

        }


        private PlantCardViewModel _plantCard;

        private MainViewModel _mainViewModelReference;

        private TimerViewModel _myTimerViewModel;

        private string _commonName;
        public string _requiredWatering;
        public string _timeRemaining;

        private RelayCommand _removeEventCommand;

        private RelayCommand _pressedDoneCommand;
        private RelayCommand _pressedCancelCommand;

        public PlantCardViewModel PlantCard
        {
            get => _plantCard;
            set => SetProperty(ref _plantCard, value);
        }
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

        public string RequiredWatering
        {
            get => _requiredWatering;
            set => SetProperty(ref _requiredWatering, value);
        }

        public string TimeRemaining
        {
            get => _timeRemaining;
            set => SetProperty(ref _timeRemaining, value);
        }

        public RelayCommand RemoveEventCommand
        {
            get { return _removeEventCommand ?? (_removeEventCommand = new RelayCommand(RemoveEvent, RemoveEventCanExecute)); }
        }

        private void RemoveEvent(object obj)
        {
            _mainViewModelReference.Events.Remove(this);
        }

        private bool RemoveEventCanExecute(object obj)
        {
            return true;
        }


        public RelayCommand PressedDoneCommand
        {
            get { return _pressedDoneCommand ?? (_pressedDoneCommand = new RelayCommand(PressedDone, PressedDoneCanExecute)); }
        }


        private void PressedDone(object obj)
        {
           
            if (this.MyTimerViewModel.DaysInput != "")
            {
                this.MyTimerViewModel.StartTimer(obj);
            }
        }

        private bool PressedDoneCanExecute(object obj)
        {
            return true;
        }



        public RelayCommand PressedCancelCommand
        {
            get { return _pressedCancelCommand ?? (_pressedCancelCommand = new RelayCommand(PressedCancel, PressedCancelCanExecute)); }
        }
        private void PressedCancel(object obj)
        {
            
            _mainViewModelReference.Events.Remove(this);
            if (this.MyTimerViewModel.DaysInput != "")
            {
                this.MyTimerViewModel.DaysInput="";
                this.MyTimerViewModel.TimeRemaining = "";
                this.MyTimerViewModel.Timer.Stop();


            }
        }

        private bool PressedCancelCanExecute(object obj)
        {
            return true;
        }

    }


}
