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
    public class PositivesController : ControllerBase
    {
        private readonly TodoContextPositive _context;

        public PositivesController(TodoContextPositive context)
        {
            _context = context;
        }

        // GET: api/Positives
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Positive>>> GetTodoItems()
        {
          if (_context.TodoItems == null)
          {
              return NotFound();
          }
            return await _context.TodoItems.ToListAsync();
        }

        // GET: api/Positives/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Positive>> GetPositive(int id)
        {
          if (_context.TodoItems == null)
          {
              return NotFound();
          }
            //var positive = await _context.TodoItems.FindAsync(id);
            Positive positive = GetAccess.GetPositive(id);

            if (positive == null)
            {
                return NotFound();
            }

            return positive;
        }

        // POST: api/Positives
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Positive>> PostPositive(Positive positive)
        {
            bool flag = true;
            string my_message = " ";
            try
            {
                AddAccess.AddPositive(positive);
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
            _context.TodoItems.Add(positive);
            await _context.SaveChangesAsync();
            if (flag)
                return CreatedAtAction(nameof(GetPositive), new { id = positive.Id }, positive);
            else
                return BadRequest("Failed to add Positive - " + my_message);
  
        }

    
        private bool PositiveExists(int id)
        {
            return (_context.TodoItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
