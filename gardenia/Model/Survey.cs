using System;
using System.Collections.Generic;

namespace gardenia.Model;

public partial class Survey
{
    public int Id { get; }

    public DateTime SubmitTime { get; set; }

    public ICollection<SurveyAnswer> SurveyAnswers { get; set; }
}
