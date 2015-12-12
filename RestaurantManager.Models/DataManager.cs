using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RestaurantManager.Models
{
    public abstract class DataManager : INotifyPropertyChanged
    {
        protected RestaurantContext Repository
        {
            get; private set;
        }

        public DataManager()
        {
            LoadData();
        }

        private async void LoadData()
        {
            this.Repository = new RestaurantContext();
            await this.Repository.InitializeContextAsync();
            OnPropertyChanged("Repository");
            OnDataLoaded();
        }

        protected abstract void OnDataLoaded();

        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
