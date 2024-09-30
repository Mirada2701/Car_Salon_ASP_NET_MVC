﻿using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IOrderService
    {
        List<Order> GetOrders(string id);
        void Create(string id, ICartService cartService);
    }
}
