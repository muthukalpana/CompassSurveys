using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompassSurveys.Filters
{
    /// <summary>  
    /// This class is used to log every action activity  
    /// </summary>  
    
    public class InformationLogger : ActionFilterAttribute
    {
        private ILogger<InformationLogger> _logger;

        /// <summary>  
        /// Initializes a new instance of the <see cref="InformationLogger" /> class.  
        /// </summary>  
        /// <param name="logger">The logger.</param> 
        
        public InformationLogger(ILogger<InformationLogger> logger)
        {
            _logger = logger;
        }

        /// <summary>  
        /// Called when [action executing].  
        /// </summary>  
        /// <param name="context">The filter context.</param>  
        
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            this.Log("OnActionExecuting", context.RouteData);
            base.OnActionExecuting(context);
        }

        /// <summary>  
        /// Called when [action executed].  
        /// </summary>  
        /// <param name="context"></param>  
        
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            this.Log("OnActionExecuted", context.RouteData);
            base.OnActionExecuted(context);
        }

        /// <summary>  
        /// Logs the specified method name.  
        /// </summary>  
        /// <param name="methodName">Name of the method.</param>  
        /// <param name="routeData">The route data.</param>  
        
        private void Log(string methodName, RouteData routeData)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            string message = $"controller:{controllerName} , action:{actionName} , MethodName :{methodName} ";
            this._logger.LogInformation(message);
        }
    }
}
