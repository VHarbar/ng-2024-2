using Application.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;
        private readonly IMemoryCache _cache;
        private const string CacheKey = "WelcomeMessage";
        private static int _counter = 0;

        public HomeController(ILogger<HomeController> logger, IMediator mediator,
            IMemoryCache memoryCache)
        {
            _logger = logger;
            _mediator = mediator;
            _cache = memoryCache;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Creates a new user with the provided information.
        /// </summary>
        /// <param name="command">The command containing the user details to create.</param>
        /// <returns>The unique identifier (<see cref="Guid"/>) of the newly created user.</returns>

        [HttpPost]
        [Route("users")]
        public async Task<Guid> CreateUser([FromBody] CreateUserCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet("message")]
        public string GetMessage()
        {
            if (!_cache.TryGetValue(CacheKey, out string message))
            {
                _counter++;
                message = $"Hello from cacheable endpoint! Call #{_counter}";

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(15));

                _cache.Set(CacheKey, message, cacheEntryOptions);
            }

            return message;
        }

        [HttpGet("AnotherCacheMessage")]
        [ResponseCache(Duration = 15, Location = ResponseCacheLocation.Any, NoStore = false)]
        public string GetAnotherMessage()
        {
            _counter++;
            return $"Hello from cacheable endpoint! Call #{_counter}";
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
