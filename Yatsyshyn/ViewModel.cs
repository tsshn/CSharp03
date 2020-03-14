using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Yatsyshyn.Loader;

namespace Yatsyshyn
{
    internal sealed class ViewModel : INotifyPropertyChanged
    {
        private readonly Model _person = new Model();

        public string FirstName
        {
            get => _person.FirstName;
            set => _person.FirstName = value;
        }

        public string LastName
        {
            get => _person.LastName;
            set => _person.LastName = value;
        }

        public string Email
        {
            get => _person.Email;
            set => _person.Email = value;
        }

        public DateTime Birthday
        {
            set => _person.Birthday = value;
            get => (DateTime) _person.Birthday;
        }

        public string Age => _person.AgeStringify();

        public string Adult => _person.IsAdultStringify();

        public string IsBirthday => _person.BirthdayStringify();

        public string ChineseSign
        {
            get => _person.ChineseSign;
            set => _person.ChineseSign = value;
        }

        public string WesternSign
        {
            get => _person.WesternSign;
            set => _person.WesternSign = value;
        }

        private async void Processor()
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() => Thread.Sleep(300));
            
            if (await Task.Run(() => _person.Calculator()))
            {
                OnPropertyChanged(nameof(FirstName));
                OnPropertyChanged(nameof(LastName));
                OnPropertyChanged(nameof(Age));
                OnPropertyChanged(nameof(Email));
                OnPropertyChanged(nameof(Birthday));
                OnPropertyChanged(nameof(IsBirthday));
                OnPropertyChanged(nameof(Adult));
                OnPropertyChanged(nameof(ChineseSign));
                OnPropertyChanged(nameof(WesternSign));
                if (_person.CheckBirthday())
                    MessageBox.Show("Happy Birthday");
            }
            LoaderManager.Instance.HideLoader();
        }

        private RelayCommand<object> _command;

        public RelayCommand<object> Command => _command ?? (_command = new RelayCommand<object>(o =>
            Processor(), o => CanExecute()));

        private bool CanExecute()
        {
            return !string.IsNullOrEmpty(_person.FirstName) &&
                   !string.IsNullOrEmpty(_person.LastName) &&
                   !string.IsNullOrEmpty(_person.Email) &&
                   !string.IsNullOrWhiteSpace(_person.Birthday.ToString());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}