using System;
using System.Collections.Generic;

namespace gardenia.Model;

public partial class SurveyAnswer
{
    public int Id { get; set; }

    public int SurveysFk { get; set; }

    public string Answer { get; set; } = null!;

    public virtual Survey SurveysFkNavigation { get; set; } = null!;
}
