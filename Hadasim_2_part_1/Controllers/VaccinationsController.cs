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
    public class VaccinationsController : ControllerBase
    {
        private readonly TodoContextVaccination _context;

        public VaccinationsController(TodoContextVaccination context)
        {
            _context = context;
        }

        // GET: api/Vaccinations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vaccination>>> GetTodoItems()
        {
          if (_context.TodoItems == null)
          {
              return NotFound();
          }
            return await _context.TodoItems.ToListAsync();
        }

        // GET: api/Vaccinations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vaccination>> GetVaccination(int id)
        {
          if (_context.TodoItems == null)
          {
              return NotFound();
          }
            //var vaccination = await _context.TodoItems.FindAsync(id);
            List<Vaccination> vaccinations = GetAccess.GetVaccination(id);

            if (vaccinations.Count() == 0)
            {
                return NotFound();
            }

            return vaccinations[0];
        }


        // POST: api/Vaccinations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vaccination>> PostVaccination(Vaccination vaccination)
        {
            bool flag = true;
            string my_message = " ";
            try
            {
                AddAccess.AddVaccination(vaccination);
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
            _context.TodoItems.Add(vaccination);
            await _context.SaveChangesAsync();
            if (flag)
                return CreatedAtAction(nameof(GetVaccination), new { id = vaccination.Id }, vaccination);
            else
                return BadRequest("Failed to add Vaccination - " + my_message);
        
            

        }

        private bool VaccinationExists(int id)
        {
            return (_context.TodoItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        /*
         * [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
         */
    }
}
