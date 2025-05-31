using Microsoft.AspNetCore.Mvc;
using JobTrackerApi.Data;
using JobTrackerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JobTrackerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobsController : ControllerBase
{
    private readonly JobDbContext _context;

    public JobsController(JobDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<JobApplication>>> GetJobs() =>
        await _context.JobApplications.ToListAsync();

    [HttpPost]
    public async Task<ActionResult<JobApplication>> Create(JobApplication job)
    {
        _context.JobApplications.Add(job);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetJobs), new { id = job.Id }, job);
    }
}