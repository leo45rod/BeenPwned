using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetMVVM.ViewModels;
using Xamarin.Forms;

namespace TweetMVVM
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            this.BindingContext = new PostsViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            // Load the posts
            PostsViewModel vm = (PostsViewModel)BindingContext;
            //await vm.ExecuteLoadItemsCommand();
            vm.RefreshCommand.Execute(null);
        }
    }
}
