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
    public partial class DrilldownTableView : ContentPage
    {
        public DrilldownTableView()
        {
            InitializeComponent();
        }

        private async void navigateToPage(object sender, EventArgs e)
        {
            string type = (string)((TextCell)sender).CommandParameter;
            Type pageType = Type.GetType("AppChapter7." + type + ",AppChapter7.Xaml");
            Page page = (Page)Activator.CreateInstance(pageType);
            await this.Navigation.PushAsync(page);
        }
    }
}