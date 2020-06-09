using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompassSurveys.Models
{
    /// <summary>  
    /// This class is used to perform Database related activities
    /// </summary>  

    public class DatabaseManager : IDatabaseManager
    {
        private readonly CompassSurveysContext _surveysContext;

        /// <summary>  
        /// Initializes a new instance of the <see cref="DatabaseManager" /> class.  
        /// </summary>  
        /// <param name="surveysContext">The context.</param> 

        public DatabaseManager(CompassSurveysContext surveysContext)
        {
            _surveysContext = surveysContext;
        }

        /// <summary>  
        /// Gets all Surveys from database.  
        /// </summary>  

        public IEnumerable<Survey> GetSurveys()
        {
            try
            {
                return _surveysContext.Survey;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>  
        /// Gets Questions and Options of the given Survey ID from the database.  
        /// </summary>  
        /// <param name="surveyID">Survey ID.</param> 

        public Survey GetSurveysWithQuestions(long surveyID)
        {
            try
            {
                Survey survey = _surveysContext.Survey.Where(x => x.Id == surveyID).FirstOrDefault();
                if (survey != null)
                {
                    IEnumerable<Question> questions = _surveysContext.Question.Where(x => x.SurveyId == surveyID);
                    foreach (Question question in questions)
                    {
                        IEnumerable<Option> options = GetOptions(question.Id);
                        question.Options = options.ToList();
                    }
                }
                return survey;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>  
        /// Gets Options of the given Question ID from the database.  
        /// </summary>  
        /// <param name="QuestionID">Question ID.</param> 

        private IEnumerable<Option> GetOptions(long QuestionID)
        {
            try
            {
                return _surveysContext.Option.Where(x => x.QuestionId == QuestionID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
