using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hadasim_2_part_1.Model;
using TodoApi.Models;
using Hadasim_2_part_1.AccessDataBase;

namespace Hadasim_2_part_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Company_VaccineController : ControllerBase
    {
        private readonly TodoContextCompany_Vaccine _context;

        public Company_VaccineController(TodoContextCompany_Vaccine context)
        {
            _context = context;
        }

        // GET: api/Company_Vaccine
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company_Vaccine>>> GetTodoItems()
        {
          if (_context.TodoItems == null)
          {
              return NotFound();
          }
            return await _context.TodoItems.ToListAsync();
        }

        // GET: api/Company_Vaccine/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Company_Vaccine>> GetCompany_Vaccine(int id)
        {

          if (_context.TodoItems == null)
          {
              return NotFound();
          }
            //var company_Vaccine = await _context.TodoItems.FindAsync(id);
            Company_Vaccine company_Vaccine = GetAccess.GetCompany_Vaccine(id);
            if (company_Vaccine == null)
            {
                return NotFound();
            }

            return company_Vaccine;
        }

        

        // POST: api/Company_Vaccine
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Company_Vaccine>> PostCompany_Vaccine(Company_Vaccine company_Vaccine)
        {
            bool flag = true;
            string my_message = " ";
            try
            {
                AddAccess.AddCompany_Vaccine(company_Vaccine);
            }
            catch(Exception ex)
            {
                flag = false;
                my_message = ex.Message;
            }
          if (_context.TodoItems == null)
          {
              return Problem("Entity set 'TodoContextCompany_Vaccine.TodoItems'  is null.");
          }
            _context.TodoItems.Add(company_Vaccine);
            await _context.SaveChangesAsync();
            if (flag)
                return CreatedAtAction(nameof(GetCompany_Vaccine), new { id = company_Vaccine.Id }, company_Vaccine);
            else
                return BadRequest("Failed to add Company_Vaccine - " + my_message);
         
        }

        private bool Company_VaccineExists(int id)
        {
            return (_context.TodoItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
