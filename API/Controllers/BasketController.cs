using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IBusketRepository _busketRepository;
        public BasketController(IBusketRepository busketRepository)
        {
            _busketRepository = busketRepository;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerBusket>> GetBusketById(string id){
            var busket = await _busketRepository.GetBusketAsync(id);
            return Ok( busket ?? new CustomerBusket(id));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBusket>> UpdateBusket(CustomerBusket busket){
            var updatedBusket = await _busketRepository.UpdateBusketAsync(busket);
            return Ok(updatedBusket);
        }

        [HttpDelete]
        public async Task DeleteBusket(string id){
            await _busketRepository.DeleteBusketAsync(id);
        }
    }
}