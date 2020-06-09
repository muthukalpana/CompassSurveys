using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompassSurveys.Models
{
    /// <summary>  
    /// This Interface is used to perform Database related activities
    /// </summary>  

    public interface IDatabaseManager
    {
        
        /// <summary>  
        /// Gets all Surveys from database.  
        /// </summary> 
        
        IEnumerable<Survey> GetSurveys();

        /// <summary>  
        /// Gets Questions and Options of the given Survey ID from the database.  
        /// </summary>  
        /// <param name="surveyID">Survey ID.</param> 

        Survey GetSurveysWithQuestions(long surveyID);
    }
}
