﻿using System;
using System.Collections.Generic;

namespace gardenia.Model;

public partial class SurveyAnswer
{
    public int Id { get; }

    public int SurveyId { get; set; }

    public string Answer { get; set; } = null!;

    //public virtual Survey SurveysFkNavigation { get; set; } = null!;
}
