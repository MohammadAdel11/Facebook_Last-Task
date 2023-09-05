using System.Collections.Generic;
using System.Threading.Tasks;
using Facebook.Tables;

public interface IActivityMetricsService 
{
    Task<List<Facebook.Tables.ActivityMetrice>> GetAllActivityMetrics();
    Task<Facebook.Tables.ActivityMetrice> GetActivityMetricsById(int id);
    Task<Facebook.Tables.ActivityMetrice> AddActivityMetrics(ActivityMetrice metrics);
    Task<Facebook.Tables.ActivityMetrice> UpdateActivityMetrics(int id, ActivityMetrice metrics);
    Task<Facebook.Tables.ActivityMetrice> DeleteActivityMetrics(int id);
}
