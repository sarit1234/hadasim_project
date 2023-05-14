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
    public class PatientsController : ControllerBase
    {
        private readonly TodoContextPatient _context;

        public PatientsController(TodoContextPatient context)
        {
            _context = context;
        }

        // GET: api/Patients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetTodoItems()
        {
          if (_context.TodoItems == null)
          {
              return NotFound();
          }
            return await _context.TodoItems.ToListAsync();
        }

        // GET: api/Patients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
          if (_context.TodoItems == null)
          {
              return NotFound();
          }
            //var patient = await _context.TodoItems.FindAsync(id);
            Patient patient = GetAccess.GetPatient(id);

            if (patient == null)
            {
                return NotFound();
            }

            return patient;
        }

     

        // POST: api/Patients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Patient>> PostPatient(Patient patient)
        {
            bool flag = true;
            string my_message = " ";
            try
            {
                AddAccess.AddPatient(patient);
            }
            catch (Exception ex)
            {
                flag = false;
                my_message = ex.Message;
            }
            if (_context.TodoItems == null)
            {
                return Problem("Entity set 'TodoContextCompany_Vaccine.TodoItems'  is null.");
            }
            _context.TodoItems.Add(patient);
            await _context.SaveChangesAsync();
            if (flag)
                return CreatedAtAction(nameof(GetPatient), new { id = patient.Id }, patient);
            else
                return BadRequest("Failed to add Patient - " + my_message);
    
        }

    

        private bool PatientExists(int id)
        {
            return (_context.TodoItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
