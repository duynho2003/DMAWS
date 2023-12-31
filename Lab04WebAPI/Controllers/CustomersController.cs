﻿using Lab04;
using Lab04WebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab04WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomersController(ICustomerRepository customerRepository) 
        {
            _customerRepository = customerRepository;
        }
            
        [HttpGet]
        public Task<List<Customers>> Get()
        {
            return _customerRepository.GetCustomersAsync();
        }

        [HttpPost]
        public async Task<bool> Post(Customers customers)
        {
            return await _customerRepository.PostCustomersAsync(customers);
        }
    }
}
