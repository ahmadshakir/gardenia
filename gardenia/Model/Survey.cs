using System;
using System.Collections.Generic;

namespace gardenia.Model;

public partial class Survey
{
    public int Id { get; set; }

    public DateTime SubmitTime { get; set; }

    public virtual ICollection<SurveyAnswer> SurveyAnswers { get; set; } = new List<SurveyAnswer>();
}
