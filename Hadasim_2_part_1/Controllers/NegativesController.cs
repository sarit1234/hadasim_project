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
    public class NegativesController : ControllerBase
    {
        private readonly TodoContextNegative _context;

        public NegativesController(TodoContextNegative context)
        {
            _context = context;
        }

        // GET: api/Negatives
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Negative>>> GetTodoItems()
        {
          if (_context.TodoItems == null)
          {
              return NotFound();
          }
            return await _context.TodoItems.ToListAsync();
        }

        // GET: api/Negatives/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Negative>> GetNegative(int id)
        {
          if (_context.TodoItems == null)
          {
              return NotFound();
          }
            //var negative = await _context.TodoItems.FindAsync(id);
            Negative negative = GetAccess.GetNegative(id);
            if (negative == null)
            {
                return NotFound();
            }

            return negative;
        }

       

        // POST: api/Negatives
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Negative>> PostNegative(Negative negative)
        {
            bool flag = true;
            string my_message = " ";
            try
            {
                AddAccess.AddNegative(negative);
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
            _context.TodoItems.Add(negative);
            await _context.SaveChangesAsync();
            if (flag)
                return CreatedAtAction(nameof(GetNegative), new { id = negative.Id }, negative);
            else
                return BadRequest("Failed to add Negative - " + my_message);


        }


        private bool NegativeExists(int id)
        {
            return (_context.TodoItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
