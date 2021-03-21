using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models;
using WebApi.Data;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IssuesController : ControllerBase
    {
        private readonly SqlDbContext _context;

        public IssuesController(SqlDbContext context)
        {
            _context = context;
        }

        //GET: api/Issues
        [HttpGet]
        public async Task<IActionResult> GetIssues()
        {
            return new OkObjectResult(await _context.Issues.ToListAsync());
        }

        // GET: api/Issues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Issue>> GetIssue(int id)
        {
            var issue = await _context.Issues.FindAsync(id);

            if (issue == null)
            {
                return NotFound();
            }

            return issue;
        }

        //Get api/issues/[GetStatus]/{issuestatus}
        [Route("[action]/{status}")] // för att kunna ha flera Gets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Issue>>> GetStatus(string status)
        {
            var issue = await _context.Issues.Where(i => i.IssueStatus.Contains(status)).ToListAsync();

            if (issue == null)
                return NotFound();


            return issue;
        }

        // Get api/issues/[GetCustomers]
        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetAllCustomers()
        {
            var issue = await _context.Issues.Select(i => i.Customer).ToListAsync();

            if (issue == null)
                return NotFound();

            return issue;
        }

        [HttpPost("create")]
        
        public async Task<IActionResult> CreateIssue([FromBody] CreateIssue model)
        {
            try
            {
                var issue = new Issue { 

                    HandlerId = model.HandlerId, 
                    Customer = model.Customer, 
                    CreatedDate = DateTime.Now, 
                    ChangedDate = model.ChangedDate,
                    IssueStatus = model.IssueStatus,
                    IssueDescription = model.IssueDescription
                };


                _context.Issues.Add(issue);
                await _context.SaveChangesAsync();

                return new OkResult();
            }
            catch { }
            return new BadRequestResult();
        }

        // PUT: api/Issues/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIssue(int id, Issue issue)
        {
            if (id != issue.Id)
            {
                return BadRequest();
            }

            _context.Entry(issue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IssueExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

       

        private bool IssueExists(int id)
        {
            return _context.Issues.Any(e => e.Id == id);
        }
    }
}
