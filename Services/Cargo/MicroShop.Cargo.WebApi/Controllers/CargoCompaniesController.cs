using MicroShop.Cargo.BusinessLayer.Abstract;
using MicroShop.Cargo.BusinessLayer.Concrete;
using MicroShop.Cargo.DTOLayer.DTOs.CargoCompanyDTOs;
using MicroShop.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompaniesController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoService;

        public CargoCompaniesController(ICargoCompanyService cargoService)
        {
            _cargoService = cargoService;
        }

        [HttpGet]
        public IActionResult CargoCompanyList()
        {
            var values = _cargoService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCargoCompany(CreateCargoCompanyDTO dto)
        {
            CargoCompany cargoCompany = new CargoCompany
            {
                CargoCompanyName = dto.CargoCompanyName
            };
            _cargoService.TInsert(cargoCompany);
            return Ok("Cargo Company Created.");
        }

        [HttpDelete]
        public IActionResult RemoveCargoCompany(int id)
        {
            _cargoService.TDelete(id);
            return Ok("Cargo Company Deleted.");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCompanyById(int id)
        {
            var value = _cargoService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateCargoCompany(UpdateCargoCompanyDTO dto)
        {
            CargoCompany cargoCompany = new CargoCompany
            {
                CargoCompanyId = dto.CargoCompanyId,
                CargoCompanyName = dto.CargoCompanyName
            };
            _cargoService.TUpdate(cargoCompany);
            return Ok("Cargo Company Updated.");
        }
    }
}
