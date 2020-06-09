using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompassSurveys.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CompassSurveys.Controllers
{
    /// <summary>  
    /// This Controller performs Survey related actions.    
    /// </summary>  

    [ApiController]
    [Route("[controller]")]
    public class SurveyController : Controller
    {
        private ILogger<SurveyController> _logger;
        private IDatabaseManager _databaseManager;

        /// <summary>  
        /// Initializes a new instance of the <see cref="SurveyController" /> class.  
        /// </summary>  
        /// <param name="logger">The logger.</param> 
        /// <param name="databaseManager">The Database Manager.</param> 

        public SurveyController(ILogger<SurveyController> logger, IDatabaseManager databaseManager)
        {
            _logger = logger;
            _databaseManager = databaseManager;
        }

        /// <summary>  
        /// Gets all Surveys.  
        /// </summary>  
        
        [HttpGet]
        public IActionResult GetSurveys()
        {
            try
            {
                IEnumerable<Survey> surveys = _databaseManager.GetSurveys();
                if(surveys.Count<Survey>() > 0)
                    return Ok(surveys);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured");
                return BadRequest();
            }
        }

        /// <summary>  
        /// Gets Questions and Options of the given Survey ID.  
        /// </summary>  
        /// <param name="surveyID">Survey ID.</param> 

        [HttpGet("{surveyID}")]
        public IActionResult GetQuestions(long surveyID)
        {
            try
            {
                Survey survey = _databaseManager.GetSurveysWithQuestions(surveyID);
                if (survey != null)
                    return Ok(survey);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured");
                return BadRequest();
            }
        }
    }
}