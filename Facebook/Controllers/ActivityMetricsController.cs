using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Facebook.Services.ActivityMetrics;
using Facebook.Tables;
using Microsoft.AspNetCore.Authorization;

namespace Facebook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,User")]

    public class ActivityMetricsController : ControllerBase
    {
        private readonly IActivityMetricsService _activityMetricsService;

        public ActivityMetricsController(IActivityMetricsService activityMetricsService)
        {
            _activityMetricsService = activityMetricsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ActivityMetrice>>> GetAllActivityMetrics()
        {
            var activityMetrics = await _activityMetricsService.GetAllActivityMetrics();
            return Ok(activityMetrics);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityMetrice>> GetActivityMetricsById(int id)
        {
            var activityMetrics = await _activityMetricsService.GetActivityMetricsById(id);
            if (activityMetrics == null)
            {
                return NotFound();
            }
            return Ok(activityMetrics);
        }

        [HttpPost]
        public async Task<ActionResult<ActivityMetrice>> AddActivityMetrics(ActivityMetrice metrics)
        {
            var newMetrics = await _activityMetricsService.AddActivityMetrics(metrics);
            return CreatedAtAction(nameof(GetActivityMetricsById), new { id = newMetrics.ActivityMetricsId }, newMetrics);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ActivityMetrice>> UpdateActivityMetrics(int id, ActivityMetrice metrics)
        {
            var updatedMetrics = await _activityMetricsService.UpdateActivityMetrics(id, metrics);
            if (updatedMetrics == null)
            {
                return NotFound();
            }
            return Ok(updatedMetrics);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ActivityMetrice>> DeleteActivityMetrics(int id)
        {
            var deletedMetrics = await _activityMetricsService.DeleteActivityMetrics(id);
            if (deletedMetrics == null)
            {
                return NotFound();
            }
            return Ok(deletedMetrics);
        }
    }
}
