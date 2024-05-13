﻿using DashBoard.API.Models.DTO;
using DashBoard.API.Repositories.Inteface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DashBoard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditController : ControllerBase
    {
        private readonly IEditRepository editRepository;
        public EditController(IEditRepository editRepository)
        {
            this.editRepository = editRepository;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditEmployee(int id, [FromBody] EditEmployeeDto employeeDto)
        {
            if (id != employeeDto.IdEmployee)
            {
                return BadRequest("ID mismatch in the URL and the body.");
            }

            try
            {
                await editRepository.EditEmployeeAsync(employeeDto);
                return Ok("Employee updated successfully.");
            }
            catch (Exception ex)
            {
                // Log the exception details here to investigate further
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
