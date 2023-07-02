using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticalCURD_Application.IServices;
using PracticalCURD_Domain.Entities;

namespace PracticalCURDApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }


        [HttpGet]
        public async Task<IActionResult> GetDepartmentList()
        {
            try
            {
                var response = await _departmentService.GetAllDepartment();
                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }
        }

        
        [HttpGet("{DepartmentId}")]
        public async Task<IActionResult> GetDepartmentById(int DepartmentId)
        {
            try
            {
                var response = await _departmentService.GetDepartmentById(DepartmentId);

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
        public async Task<IActionResult> CreateDepartment([FromBody] Department entity)
        {
            try
            {
                var isDepartmentCreated = await _departmentService.CreateDepartment(entity);

                if (isDepartmentCreated)
                {
                    return Ok(isDepartmentCreated);
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
        public async Task<IActionResult> UpdateDepartment([FromBody] Department entity)
        {
            try
            {
                if (entity != null)
                {
                    var response = await _departmentService.UpdateDepartment(entity);
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

        
        [HttpDelete("{DepartmentId}")]
        public async Task<IActionResult> DeleteDepartment(int DepartmentId)
        {
            try
            {
                var response = await _departmentService.DeleteDepartment(DepartmentId);

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
