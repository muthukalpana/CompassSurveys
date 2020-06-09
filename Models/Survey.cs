using System;
using System.Collections.Generic;

namespace CompassSurveys.Models
{
    public partial class Survey
    {
        /// <summary>  
        /// Survey ID.  
        /// </summary>
        public long Id { get; set; }
        /// <summary>  
        /// Survey Name.  
        /// </summary>
        public string Name { get; set; }
        /// <summary>  
        /// List Of Questions  
        /// </summary>
        public List<Question> Questions { get; set; }
    }
}
