using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YegnaGebiyaSystem.Models;

namespace YegnaGebiyaSystem.Interfaces
{
   public interface IOrderRepository
    {
        Order CreateOrder(Order order,int buyerId);
    }
}
