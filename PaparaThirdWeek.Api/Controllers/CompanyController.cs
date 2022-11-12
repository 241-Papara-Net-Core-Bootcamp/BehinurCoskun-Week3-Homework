using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaparaThirdWeek.Domain.Entities;
using PaparaThirdWeek.Services.Abstracts;
using PaparaThirdWeek.Services.DTOs;

namespace PaparaThirdWeek.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            this._companyService = companyService;
        }

        [HttpGet("Companies")]
        public IActionResult Get()
        {
            var result = _companyService.GetAll();
            return Ok(result);
        }

        [HttpGet("Id")]
        public IActionResult Get(int id)
        {
            var result = _companyService.Get(id);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update(Company company)
        {
            _companyService.Update(company);
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(CompanyDto company)
        {
            var companyDto = new Company
            {
                Name = company.Name,
                Adress = company.Adress,
                City = company.City,
                CreatedBy = "Samet",
                CreatedDate = System.DateTime.Now,
                Email = company.Email,
                IsDeleted = false,
                TaxNumber = company.TaxNumber
            };
            _companyService.Add(companyDto);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _companyService.Delete(id);
            return Ok();
        }
        
    }
}
