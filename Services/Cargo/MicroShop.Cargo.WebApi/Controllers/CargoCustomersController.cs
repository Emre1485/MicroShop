using MicroShop.Cargo.BusinessLayer.Abstract;
using MicroShop.Cargo.DTOLayer.DTOs.CargoCustomerDTOs;
using MicroShop.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomersController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }

        [HttpGet]
        public IActionResult CargoCustomerList()
        {
            var values = _cargoCustomerService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCustomerById(int id)
        {
            var value = _cargoCustomerService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDTO dto)
        {
            CargoCustomer carCustomer = new CargoCustomer
            {
                Address = dto.Address,
                City = dto.City,
                District = dto.District,
                Email = dto.Email,
                Name = dto.Name,
                Surname = dto.Surname,
                Phone = dto.Phone
            };

            _cargoCustomerService.TInsert(carCustomer);
            return Ok("Cargo_Customer Created.");
        }

        [HttpDelete]
        public IActionResult RemoveCargoCustomer(int id)
        {
            _cargoCustomerService.TDelete(id);
            return Ok("Cargo_Customer Deleted.");
        }

        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDTO dto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer
            {
                CargoCustomerId = dto.CargoCustomerId,
                Address = dto.Address,
                City = dto.City,
                District = dto.District,
                Email = dto.Email,
                Name = dto.Name,
                Surname = dto.Surname,
                Phone = dto.Phone
            };
            _cargoCustomerService.TUpdate(cargoCustomer);
            return Ok("Cargo_Customer Updated.");
        }

    }
}
