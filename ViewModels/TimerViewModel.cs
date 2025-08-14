using PlantCareApp.Support;
using System;
using System.Windows.Input;
using System.Windows.Threading;

namespace PlantCareApp
{
    public class TimerViewModel : ViewModelBase
    {
        private DispatcherTimer _timer;
        private DateTime _endTime;
        private string _timeRemaining;
        private string _daysInput;


        public DispatcherTimer Timer
        {
            get => _timer;
            set
            {
                _timer = value;
                OnPropertyChanged(nameof(Timer));
            }
        }

        public string DaysInput
        {
            get => _daysInput;
            set
            {
                _daysInput = value;
                OnPropertyChanged(nameof(DaysInput));
            }
        }

        public string TimeRemaining
        {
            get => _timeRemaining;
            set
            {
                _timeRemaining = value;
                OnPropertyChanged(nameof(TimeRemaining));
            }
        }

        public RelayCommand StartTimerCommand { get; }

        public TimerViewModel()
        {
            _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            _timer.Tick += Timer_Tick;
            StartTimerCommand = new RelayCommand(parameter => StartTimer(parameter));
        }

        public void StartTimer(object parameter)
        {
            if (int.TryParse(DaysInput, out int days))
            {
                _endTime = DateTime.Now.AddDays(days);
                _timer.Start();
                TimeRemaining = $"Time remaining: {days} days";
            }
            else
            {
                TimeRemaining = "Please enter a valid number of days.";
            }

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var remaining = _endTime - DateTime.Now;
            if (remaining.TotalSeconds <= 0)
            {
                _timer.Stop();
                TimeRemaining = "Time's up!";
            }
            else
            {
                TimeRemaining = $"Time remaining: {remaining.Days} days, {remaining.Hours} hours, {remaining.Minutes} minutes";
            }
        }
    }
}
