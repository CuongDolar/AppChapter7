using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppChapter7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DrilldownListViewByPage : ContentPage
    {
        public DrilldownListViewByPage()
        {
            InitializeComponent();
            itemList.ItemsSource = new ListItemPage[] {
            new ListItemPage {Title = "First", PageType = typeof(FirstPage)},
            new ListItemPage {Title = "Second", PageType = typeof(SecondPage)},
            new ListItemPage {Title = "Third", PageType = typeof(ThirdPage)}
            };
        }
        protected async void ItemTapped(object sender, ItemTappedEventArgs args)
        {
            var item = args.Item as ListItemPage;
            if (item == null) return;
            Page page = (Page)Activator.CreateInstance(item.PageType);
            await Navigation.PushAsync(page);
            itemList.SelectedItem = null;
        }
    }
    public class ListItemPage
    {
        public string Title { get; set; }
        public Type PageType { get; set; }
    }
}