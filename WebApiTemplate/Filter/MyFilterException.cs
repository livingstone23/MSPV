using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApiTemplate.Filter
{
    public class MyFilterException: ExceptionFilterAttribute
    {
        private readonly ILogger<MyFilterException> _logger;
        public MyFilterException(ILogger<MyFilterException> logger)
        {
            _logger = logger;
        }


        public override void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, context.Exception.Message);

            base.OnException(context);
        }

    }
}
