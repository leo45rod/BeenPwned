using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TweetMVVM.Helpers;
using TweetMVVM.Models;

namespace TweetMVVM.ViewModels
{
    public class PostsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Post> Posts { get; set; }

        private bool isBusy, isError, dataAvailable;
        private string errorMessage = "";
        
        public PostsViewModel ()
        {

        }


        /// <summary>
        /// Gets or sets if the View Model is busy
        /// </summary>
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnPropertyChanged("IsBusy"); }
        }

        /// <summary>
        /// Gets or sets if the View Model generated an error
        /// </summary>
        public bool IsError
        {
            get { return isError; }
            set { isError = value; OnPropertyChanged("IsError"); }
        }

        /// <summary>
        /// Gets or sets if the View Model data is available
        /// </summary>
        public bool DataAvailable
        {
            get { return dataAvailable; }
            set { dataAvailable = value; OnPropertyChanged("DataAvailable"); }
        }

        /// <summary>
        /// Gets or sets if the View Model data is available
        /// </summary>
        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; OnPropertyChanged("ErrorMessage"); }
        }


        private RelayCommand refreshItemsCommand;
        public ICommand RefreshCommand
        {
            get
            {
                return refreshItemsCommand ?? (refreshItemsCommand = new RelayCommand(async () => await ExecuteLoadItemsCommand()));
            }
        }

        public async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy) return;
            IsBusy = true;

            Posts = new ObservableCollection<Post>();

            try
            {
                var client = new RestClient(GlobalConstants.EndPointURL);
                var request = new RestRequest
                {
                    Timeout = GlobalConstants.RequestTimeout
                };
                request.Resource = GlobalConstants.SocialEndPointRequestURL;

                var response = await client.ExecuteTaskAsync(request);

                if (response.IsSuccessful)
                {
                    IsError = false;
                    var items = JsonConvert.DeserializeObject<List<Post>>(response.Content) ?? new List<Post>();

                    foreach (var item in items)
                    {
                        if (!item.Description.Contains("a href"))
                        {
                            item.Description = item.Description.ParseURL().ParseHashtag().ParseUsername();
                        }

                        bool addItem = true;
                        if (item.ShowImage && item.Image.Length > 0 && item.Image.Contains("tweet_video_thumb"))
                        {
                            addItem = false;
                        }

                        if (addItem)
                        {
                            Posts.Add(item);
                        }
                    }

                    DataAvailable = true;
                }
                else
                {
                    // An error occurred that is stored in response.ErrorMessage
                    ErrorMessage = response.ErrorMessage ?? response.StatusCode.ToString();
                    DataAvailable = false;
                    IsError = true;
                }
            }
            catch (Exception e)
            {
                // An exception occurred
                DataAvailable = false;
            }

            IsBusy = false;
            OnPropertyChanged("Posts");
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
