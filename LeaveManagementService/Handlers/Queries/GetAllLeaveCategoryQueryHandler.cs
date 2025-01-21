using LeaveManagementService.Data;
using LeaveManagementService.Models;
using LeaveManagementService.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace LeaveManagementService.Handlers.Queries
{
    public class GetAllLeaveCategoryQueryHandler : IRequestHandler<GetAllLeaveCategoryQuery, IEnumerable<LeaveCategory>>
    {
        private readonly LeaveDbContext _context; 
        private readonly IDistributedCache _cache;
        private readonly ILogger<GetAllLeaveCategoryQueryHandler> _logger;
        public GetAllLeaveCategoryQueryHandler(LeaveDbContext context, IDistributedCache  cache, 
                        ILogger<GetAllLeaveCategoryQueryHandler>  logger)
        {
            this._cache = cache;
            this._logger = logger;
            _context = context;
        }

        public async Task<IEnumerable<LeaveCategory>> Handle(GetAllLeaveCategoryQuery request, CancellationToken cancellationToken)
        {
            const string cacheKey = "leave_categories";
            IEnumerable<LeaveCategory> leaveCategories;

            // Try to fetch from Redis cache
            var cachedData = await _cache.GetStringAsync(cacheKey);
            if (!string.IsNullOrEmpty(cachedData))
            {
                _logger.LogInformation("Cache hit for leave categories.");
                leaveCategories = JsonConvert.DeserializeObject<IEnumerable<LeaveCategory>>(cachedData);
            }
            else
            {
                _logger.LogInformation("Cache miss. Fetching leave categories from database.");
                leaveCategories = await _context.LeaveCategories.ToListAsync(cancellationToken);

                if (leaveCategories != null && leaveCategories.Any())
                {
                    var cacheOptions = new DistributedCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(3600)
                    };

                    await _cache.SetStringAsync(cacheKey, JsonConvert.SerializeObject(leaveCategories), cacheOptions);
                }
            }

            return leaveCategories; 
        }
    }

}
