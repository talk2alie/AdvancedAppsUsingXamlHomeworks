using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RestaurantManager.Models
{
    public abstract class DataManager : INotifyPropertyChanged
    {
        private RestaurantContext _repository;
        protected RestaurantContext Repository
        {
            get
            {
                return _repository;
            }

            private set
            {
                if (value != _repository)
                {
                    _repository = value;
                    OnPropertyChanged();
                }
            }
        }

        public DataManager()
        {
            LoadData();
        }

        private async void LoadData()
        {
            this.Repository = new RestaurantContext();
            await this.Repository.InitializeContextAsync();
            OnDataLoaded();
        }

        protected abstract void OnDataLoaded();

        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
