﻿using System;

namespace Interfaces
{
    internal class OrderProcessor
    {
        private readonly ShippingCalculator _shippingCalculator;
        public OrderProcessor()
        {
            _shippingCalculator = new ShippingCalculator();
        }

        internal void Process(Order order)
        {
            if (order.IsShipped)
                throw new InvalidOperationException("This order is already processed");
            order.Shipment = new Shipment
            {
                Cost = _shippingCalculator.CalculateShipping(order),
                ShippingDate = DateTime.Today.AddDays(1)
            };
        }
    }
}