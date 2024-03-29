﻿using System;
using System.Collections.Generic;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            StockManager stockManager = new StockManager();
            BuyStock buyStock = new BuyStock(stockManager);
            SellStock sellStock = new SellStock(stockManager);

            StockControll stockControll = new StockControll();
            stockControll.TakeOrder(buyStock);
            stockControll.TakeOrder(sellStock);
            stockControll.TakeOrder(buyStock);

            stockControll.PlaceOrder();

            Console.ReadLine();
        }
    }
    class StockManager
    {
        private string _name = "Laptop";
        private int _quantity = 10;
        public void Buy()
        {
            Console.WriteLine("Stock : {0},{1} bought!", _name, _quantity);
        }
        public void Sell()
        {
            Console.WriteLine("Stock : {0},{1} Sold", _name, _quantity);
        }
    }
    interface IOrder
    {
        void Execute();
    }
    class BuyStock : IOrder
    {
        StockManager _stockManager;

        public BuyStock(StockManager stockManager)
        {
            _stockManager = stockManager;
        }

        public void Execute()
        {
            _stockManager.Buy();
        }
    }
    class SellStock : IOrder
    {
        StockManager _stockManager;

        public SellStock(StockManager stokManager)
        {
            _stockManager = stokManager;
        }

        public void Execute()
        {
            _stockManager.Sell();
        }
    }
    class StockControll
    {
        List<IOrder> _orders = new List<IOrder>();

        public void TakeOrder(IOrder order)
        {
            _orders.Add(order);
        }
        public void PlaceOrder()
        {
            foreach (var order in _orders)
            {
                order.Execute();
            }
            _orders.Clear();
        }
    }
}
