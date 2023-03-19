using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApiTemplate.Filter
{

    /// <summary>
    /// Servicio que permite insertarse en las acciones de los controladores
    /// Se debe agregar en la clase startup
    /// </summary>
    public class MyFilterAction : IActionFilter
    {

        private readonly ILogger<MyFilterAction> _logger;
        
        public MyFilterAction(ILogger<MyFilterAction> logger)
        {
            _logger = logger;
        }

        //Executando accion 
        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("Antes de ejecutar la acción");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("Despues de ejecutar la acción");
        }

        
    }

}
