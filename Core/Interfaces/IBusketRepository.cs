using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IBusketRepository
    {
        Task<CustomerBusket> GetBusketAsync(string busketId);
        Task<CustomerBusket> UpdateBusketAsync(CustomerBusket busket);
        Task<bool> DeleteBusketAsync(string busketId);
    }
}