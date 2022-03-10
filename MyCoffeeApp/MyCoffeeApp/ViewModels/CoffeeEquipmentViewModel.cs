using MvvmHelpers;
using MvvmHelpers.Commands;
using MyCoffeeApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
//using Xamarin.Forms;

namespace MyCoffeeApp.ViewModels
{
    public class CoffeeEquipmentViewModel : ViewModelBase /*BindableObject*/
    {
        public ObservableRangeCollection<Coffee> Coffee { get; set; }
        public ObservableRangeCollection<Grouping<string, Coffee>> CoffeeGroups { get; }

        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand<Coffee> FavoriteCommand { get; }

        public CoffeeEquipmentViewModel()
        {
            Title = "Coffee Equipment";
;
            Coffee = new ObservableRangeCollection<Coffee>();
            CoffeeGroups = new ObservableRangeCollection<Grouping<string, Coffee>>();

            var image = "https://www.yesplz.coffee/app/uploads/2020/11/emptybag-min.png";

            Coffee.Add(new Coffee { Roaster = "Yes Plz", Name = "Sip of Sunshine", Image = image });
            Coffee.Add(new Coffee { Roaster = "Yes Plz", Name = "Potent Potable", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Kenya Kiambu Handege", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Kenya Kiambu Handege", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Kenya Kiambu Handege", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Kenya Kiambu Handege", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Kenya Kiambu Handege", Image = image });

            CoffeeGroups.Add(new Grouping<string, Coffee>("Blue Bottle", new[] { Coffee[2] }));
            CoffeeGroups.Add(new Grouping<string, Coffee>("Yes Plz", Coffee.Take(2)));

            CallServerCommand = new AsyncCommand(DoCallServerCommand);
            IncreaseCountCommand = new Command(DoIncreaseCountCommand);
            RefreshCommand = new AsyncCommand(DoRefreshCommand);
            FavoriteCommand = new AsyncCommand<Coffee>(DoFavoriteCommand);
        }

        private async Task DoFavoriteCommand(Coffee coffee)
        {
            
        }

        private async Task DoRefreshCommand()
        {
            IsBusy = true;

            await Task.Delay(2000);

            IsBusy = false;
        }

        private async Task DoCallServerCommand()
        {
            //var items = new List<string>();
            //items.Add("Coffee 1");
            //items.Add("Coffee 2");
            //items.Add("Coffee 3");

            //Coffee.AddRange(items);
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

        //protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        //{
        //    if (!Equals(field, newValue))
        //    {
        //        field = newValue;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //        return true;
        //    }

        //    return false;
        //}
    }
}
