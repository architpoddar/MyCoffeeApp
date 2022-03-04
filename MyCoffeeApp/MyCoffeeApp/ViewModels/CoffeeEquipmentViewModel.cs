using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
//using Xamarin.Forms;

namespace MyCoffeeApp.ViewModels
{
    public class CoffeeEquipmentViewModel : ViewModelBase /*BindableObject*/
    {
        public ObservableRangeCollection<string> Coffee { get; }
        public CoffeeEquipmentViewModel()
        {

            CallServerCommand = new AsyncCommand(DoCallServerCommand);
            IncreaseCountCommand = new Command(DoIncreaseCountCommand);
        }

        private async Task DoCallServerCommand()
        {
            var items = new List<string>();
            items.Add("Coffee 1");
            items.Add("Coffee 2");
            items.Add("Coffee 3");

            Coffee.AddRange(items);
        }

        private void DoIncreaseCountCommand()
        {
            count++;
            CountDisplay = "Click Count: " + count;
        }

        public ICommand CallServerCommand { get; }
        public ICommand IncreaseCountCommand { get; }

        int count = 0;

        string countDisplay = "Click Me!";
        public string CountDisplay
        {
            get
            {
                return countDisplay;
            }
            set
            {
                if (value == countDisplay)
                    return;

                countDisplay = value;

                //OnPropertyChanged("CountDisplay");
                //OnPropertyChanged(nameof(CountDisplay));
                //OnPropertyChanged();
                SetProperty(ref countDisplay, value);
            }
        }

    }
}
