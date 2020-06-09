using System;
using System.Collections.Generic;

namespace CompassSurveys.Models
{
    public partial class Option
    {
        /// <summary>  
        /// Option ID.  
        /// </summary>
        public long Id { get; set; }
        /// <summary>  
        /// Option Name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>  
        /// Question ID.  
        /// </summary>
        public long QuestionId { get; set; }
    }
}
