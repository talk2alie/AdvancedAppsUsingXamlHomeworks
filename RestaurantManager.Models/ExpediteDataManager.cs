﻿using System.Collections.Generic;

namespace RestaurantManager.Models
{
    public class ExpediteDataManager : DataManager
    {
        protected override void OnDataLoaded()
        {
            OrderItems = base.Repository.Orders;
        }

        private List<Order> _orderItems;
        public List<Order> OrderItems
        {
            get
            {
                return _orderItems;
            }
            set
            {
                _orderItems = value;
                OnPropertyChanged();
            }
        }
    }
}
