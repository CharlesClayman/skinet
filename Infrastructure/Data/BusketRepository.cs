using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using StackExchange.Redis;
using System.Text.Json;

namespace Infrastructure.Data
{
    public class BusketRepository : IBusketRepository
    {
        private readonly IDatabase _database;
        public BusketRepository(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }
        public async Task<bool> DeleteBusketAsync(string busketId)
        {
            return await _database.KeyDeleteAsync(busketId);
        }

        public async Task<CustomerBusket> GetBusketAsync(string busketId)
        {
            var data = await _database.StringGetAsync(busketId);
            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBusket>(data);
        }

        public async Task<CustomerBusket> UpdateBusketAsync(CustomerBusket busket)
        {
           var created = await _database.StringSetAsync(busket.Id, JsonSerializer.Serialize(busket),TimeSpan.FromDays(30));

           if(!created) return null;

           return await GetBusketAsync(busket.Id);
        }
    }
}