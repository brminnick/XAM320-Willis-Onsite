using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;

namespace XAM320
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        readonly PersonModel _defaultPerson = new PersonModel
        {
            FirstName = "John",
            LastName = "Doe"
        };

        bool _isBusy;
        string _firstName, _lastName, _firstNameCharacterCount;
        ICommand _defaultNameButtonCommand, _doSomethingCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand DefaultNameButtonCommand => _defaultNameButtonCommand ??
            (_defaultNameButtonCommand = new Command<string>(ExecuteDefaultNameButtonCommand));

        public ICommand DoSomethingCommand => _doSomethingCommand ??
            (_doSomethingCommand= new Command(DoSomething));

        public string FirstName
        {
            get => _firstName;
            set => SetProperty(value, ref _firstName, async () => await UpdateFirstNameCharacterCount());
        }

        public string LastName
        {
            get => _lastName;
            set => SetProperty(value, ref _lastName);
        }

        public string FirstNameCharacterCount
        {
            get => _firstNameCharacterCount;
            set => SetProperty(value, ref _firstNameCharacterCount);
        }

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(value, ref _isBusy);
        }

        void SetProperty<T>(T propertyValue, ref T backingStore, Action onChanged = null, [CallerMemberName]string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, propertyValue))
                return;

            backingStore = propertyValue;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            onChanged?.Invoke();
        }

        void DoSomething()
        {
            //Todo
        }

        async Task UpdateFirstNameCharacterCount()
        {
            IsBusy = true;

            var numberOfCharacters = FirstName.Length;
            FirstNameCharacterCount = numberOfCharacters.ToString();

            await Task.Delay(5000);

            IsBusy = false;
        }

        void ExecuteDefaultNameButtonCommand(string defaultFirstName)
        {
            FirstName = defaultFirstName;
            LastName = _defaultPerson.LastName;
        }
    }
}
