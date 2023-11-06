using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server_side_pagination.Models;
using System.Reflection;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace server_side_pagination.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        private readonly EmpwageContext _context;

        public SalaryController(EmpwageContext context)
        {
            _context = context;
        }
        // GET: api/<SalaryController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _context.Salaries.ToListAsync();
            return Ok(data);
        }

        // GET api/<SalaryController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _context.Salaries.FindAsync(id);
            return Ok(res);
        }

        [HttpGet("paginated")]
        public async Task<IActionResult> Getpaginated(int pagesize,int pageindex)
        {
           
               
                var res =await _context.Salaries.Skip((pageindex - 1) * pagesize).Take(pagesize).OrderBy(OBJ=>OBJ.Sid).ToListAsync();
                return Ok(res);
            

        }

        [HttpGet("paginate2")]
        public IActionResult GetPaginatedData(int pageNumber = 1, int pageSize = 10)
        {
            var totalCount = _context.Salaries.Count(); // Total number of records
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var data = _context.Salaries
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var response = new
            {
                TotalCount = totalCount,
                TotalPages = totalPages,
                Data = data
            };

            return Ok(response);
        }
        // POST api/<SalaryController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Salary value)
        {
            await _context.Salaries.AddAsync(value);
            await _context.SaveChangesAsync();
            return Ok("data added");

        }
    }
}
