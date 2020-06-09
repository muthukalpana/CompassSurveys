using System;
using System.Collections.Generic;

namespace CompassSurveys.Models
{
    public partial class Question
    {
        /// <summary>  
        /// Question ID.  
        /// </summary>
        public long Id { get; set; }
        /// <summary>  
        /// Created By.
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>  
        /// Created Date.  
        /// </summary>
        public string CreatedDate { get; set; }
        /// <summary>  
        /// Title
        /// </summary>
        public string Title { get; set; }
        /// <summary>  
        /// Sub Title
        /// </summary>
        public string SubTitle { get; set; }
        /// <summary>  
        /// Question Type.  
        /// </summary>
        public long Type { get; set; }
        /// <summary>  
        /// Survey ID 
        /// </summary>
        public long SurveyId { get; set; }
        /// <summary>  
        /// List Of Options 
        /// </summary>
        public List<Option> Options { get; set; }
    }
}
