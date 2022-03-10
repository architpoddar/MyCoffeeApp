using MyCoffeeApp.Models;
using MyCoffeeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyCoffeeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoffeeEquipmentPage : ContentPage
    {
        public CoffeeEquipmentPage()
        {
            InitializeComponent();

            //BindingContext = new CoffeeEquipmentViewModel();
            //LabelCount.Text = "Text from code behind directly.";
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var listView = sender as ListView;

            var coffee = listView.SelectedItem as Coffee;

            if (coffee == null)
                return;

            var name = coffee.Name;

            await DisplayAlert("Selected", name, "OK");
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var listView = sender as ListView;

            listView.SelectedItem = null;
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;

            var coffee = menuItem.BindingContext as Coffee;

            if (coffee == null)
                return;

            var name = coffee.Name;

            await DisplayAlert("Favourited", name, "OK");

        }
    }
}