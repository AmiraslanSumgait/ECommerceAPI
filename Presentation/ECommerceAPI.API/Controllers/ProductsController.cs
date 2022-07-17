
using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

       
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly ICustomerWriteRepository _customerWriteRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, IOrderWriteRepository orderWriteRepository, ICustomerWriteRepository customerWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerWriteRepository = customerWriteRepository;
        }
        [HttpGet]
        public async Task Get()
        {
            var customerId = Guid.NewGuid();

            await _customerWriteRepository.AddAsync(new() { Id = customerId, Name = "Kamal" });
            await _orderWriteRepository.AddAsync(new() { Description = "bla bla bla", Address = "Sumgait",CustomerId=customerId });
            await _orderWriteRepository.AddAsync(new() { Description = "bla bla bla2", Address = "Ganja",CustomerId=customerId });
            await _orderWriteRepository.SaveAsync();
        }
      
    }
    
}
