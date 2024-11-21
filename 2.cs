public class ActivityLogService
{
    private readonly ApplicationDbContext _context;

    public ActivityLogService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ActivityLog>> GetActivityLogsAsync(int page, int pageSize)
    {
        return await _context.ActivityLogs
            .OrderByDescending(x => x.ActivityOn)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
}
