﻿using DashBoard.API.Models;
using DashBoard.API.Models.DTO;
using DashBoard.API.Repositories.Inteface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace DashBoard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceRepository serviceRepository;
        public ServicesController(IServiceRepository serviceRepository)
        {
            this.serviceRepository = serviceRepository;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] uint id)
        {
            var existing = await serviceRepository.GetBenefitPlanById(id);
            if (existing == null)
            {
                return NotFound();
            }
            return Ok(existing);
        }

        [HttpGet("GetAllBenifit")]
        public async Task<IActionResult> GetAll()
        {
            var result = await serviceRepository.GetByAll();
            return Ok(result);
        }

        [HttpGet("GetAllEmployee")]
        public async Task<IActionResult> GetAllEmployee()
        {
            var result = await serviceRepository.GetByAllEmployee();
            return Ok(result);
        }

        [HttpPost("filter/employees")]
        //[Route("{filter}")]
        //<IEnumerable<EmployeeSalaryDto>>
        public async Task<ActionResult> GetEmployeeSalary([FromBody] EmployeeFilterDto filter)
        {
            List<ViewTotal> view = new List<ViewTotal>();
            try
            {
                var employees = await serviceRepository.GetEmployeesSalary(filter);
                foreach (var employee in employees)
                {
                    view.Add(new ViewTotal
                    {
                        FullName = employee.FullName,
                        Gender = employee.Gender,
                        Ethnicity = employee.Ethnicity,
                        Category = employee.Category,
                        Department = employee.JobHistories?.FirstOrDefault()?.Department,
                        Total = employee.TotalSalary,
                    });
                }
                return Ok(view);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("filter/number-vacation-days")]
        //<IEnumerable<NumberOfVacationDay>>
        public async Task<ActionResult> GetNumberVacationDay([FromBody] EmployeeFilterDto filter)
        {
            List<ViewTotal> view = new List<ViewTotal>();
            try
            {
                var employees = await serviceRepository.GetNumberOfVacationDays(filter);
                foreach (var employee in employees)
                {
                    view.Add(new ViewTotal
                    {
                        FullName = employee.FullName,
                        Gender = employee.Gender,
                        Ethnicity = employee.Ethnicity,
                        Category = employee.Category,
                        Department = employee.JobHistories?.FirstOrDefault()?.Department,
                        Total = employee.TotalDaysOff,
                    });
                }
                return Ok(view);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi

                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetEmployeeAnniversary")]
        public async Task<ActionResult<IEnumerable<EmployeeAnniversaryDto>>> GetEmployeeAnniversary([FromQuery] int daysLimit = 55)
        {
            var result = await serviceRepository.GetEmployeesAnniversaryInfo(daysLimit);
            return Ok(result);
        }

        //[HttpGet("GetEmployeeBirthday")]
        //public async Task<ActionResult<IEnumerable<EmployeeAnniversaryDto>>> GetEmployeeBirthday()
        //{
        //    try
        //    {
        //        var result = await serviceRepository.GetEmployeesWithBirthdaysThisMonth();
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}
        //[HttpGet("CountVacationEmployee")]
        //public async Task<ActionResult<IEnumerable<EmployeeVacationDto>>> GetVacationEmployeeThisYear([FromQuery] int minimumDays = 12)
        //{
        //    try
        //    {
        //        var result = await serviceRepository.GetEmployeesWithAccumulatedVacationDays(minimumDays);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}
    }
}
