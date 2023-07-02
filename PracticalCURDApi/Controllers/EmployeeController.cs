using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticalCURD_Application.IServices;
using PracticalCURD_Application.Responses;
using PracticalCURD_Domain.Entities;
using PracticalCURD_Infrastructure.Services;


namespace PracticalCURDApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeeList([FromQuery] PaginationList pagination)
        {
            try
            {

                var result = await _employeeService.GetAllEmployee(pagination);

                var resp = result.OrderBy(on => on.EmployeeId)
          .Skip((pagination.PageNumber - 1) * pagination.PageSize)
          .Take(pagination.PageSize)
          .ToList();

                if (result == null)
                {
                    return NotFound();
                }
                return Ok(new PagedResponse<IEnumerable<Employee>>(resp, pagination.PageNumber, pagination.PageSize, result.Count()));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("SearchEmployee")]
        public async Task<IActionResult> SearchEmployee([FromQuery] PaginationList pagination)
        {
            try
            {

                if (pagination.searchParameters != null)
                {
                    var result = await _employeeService.SearchEmployee(pagination);

                    var resp = result.OrderBy(on => on.EmployeeId)
              .Skip((pagination.PageNumber - 1) * pagination.PageSize)
              .Take(pagination.PageSize)
              .ToList();
                    if (result == null)
                    {
                        return NotFound();
                    }
                    return Ok(new PagedResponse<IEnumerable<Employee>>(resp, pagination.PageNumber, pagination.PageSize, result.Count()));
                }
                else
                {
                    return NotFound();
                }


            }
            catch (Exception)
            {

                throw;
            }
        }




        [HttpGet("{EmployeeId}")]
        public async Task<IActionResult> GetEmployeeById(int EmployeeId)
        {
            try
            {
                var response = await _employeeService.GetEmployeeById(EmployeeId);

                if (response != null)
                {
                    return Ok(response);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] Employee entity)
        {
            try
            {
                var isEmployeeCreated = await _employeeService.CreateEmployee(entity);

                if (isEmployeeCreated)
                {
                    return Ok(isEmployeeCreated);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employee entity)
        {
            try
            {
                if (entity != null)
                {
                    var response = await _employeeService.UpdateEmployee(entity);
                    if (response)
                    {
                        return Ok(response);
                    }
                    return BadRequest();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpDelete("{EmployeeId}")]
        public async Task<IActionResult> DeleteEmployee(int EmployeeId)
        {
            try
            {
                var response = await _employeeService.DeleteEmployee(EmployeeId);

                if (response)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
