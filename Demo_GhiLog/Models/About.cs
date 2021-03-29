using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_GhiLog.Models
{

    public class About : PageModel
    {
        private readonly ILogger _logger;
        public About(ILogger<About> logger)
        {
            _logger = logger;
        }
        public string Message { get; set; }
        public void OnGet()
        {
            Message = $"Log page visited at {DateTime.UtcNow.ToLongTimeString()}";
            _logger.LogInformation(Message);
        }
    }
}
