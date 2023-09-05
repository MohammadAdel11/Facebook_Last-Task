using System.Collections.Generic;
using System.Threading.Tasks;
using Facebook.Tables;
using Microsoft.EntityFrameworkCore;

namespace Facebook.Services.ActivityMetrics
{
    public class ActivityMetricsService : IActivityMetricsService
    {
        private readonly ApplicationDBContext _context;

        public ActivityMetricsService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<ActivityMetrice>> GetAllActivityMetrics()
        {
            return await _context.ActivityMetrics.ToListAsync();
        }

        public async Task<ActivityMetrice> GetActivityMetricsById(int id)
        {
            return await _context.ActivityMetrics.FirstOrDefaultAsync(metrics => metrics.ActivityMetricsId == id);
        }

        public async Task<ActivityMetrice> AddActivityMetrics(ActivityMetrice metrics)
        {
            await _context.ActivityMetrics.AddAsync(metrics);
            await _context.SaveChangesAsync();
            return metrics;
        }

        public async Task<ActivityMetrice> UpdateActivityMetrics(int id, ActivityMetrice metrics)
        {
            var existingMetrics = await _context.ActivityMetrics.FirstOrDefaultAsync(metrics => metrics.ActivityMetricsId == id);
            if (existingMetrics != null)
            {
                // Update properties of existingMetrics with data from metrics
                await _context.SaveChangesAsync();
            }
            return existingMetrics;
        }

        public async Task<ActivityMetrice> DeleteActivityMetrics(int id)
        {
            var existingMetrics = await _context.ActivityMetrics.FirstOrDefaultAsync(metrics => metrics.ActivityMetricsId == id);
            if (existingMetrics != null)
            {
                _context.ActivityMetrics.Remove(existingMetrics);
                await _context.SaveChangesAsync();
            }
            return existingMetrics;
        }
    }
}
