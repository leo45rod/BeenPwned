using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetMVVM.ViewModels;
using TweetMVVM.Models;
using Xamarin.Forms;
using System.ComponentModel;

namespace TweetMVVM
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();

            this.BindingContext = new AccountsViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            // Load the posts
            AccountsViewModel vm = (AccountsViewModel)BindingContext;
            //await vm.ExecuteLoadItemsCommand();
            vm.RefreshCommand.Execute(null);
        }
        
        private async void Button_Clicked(object sender, EventArgs e)
        {
            AccountsViewModel AVM = new AccountsViewModel();
            AVM = (AccountsViewModel)BindingContext;
            AVM.Input = Email.Text; 
            
            AVM.RefreshCommand.Execute(true);
        }

        

    }
}
