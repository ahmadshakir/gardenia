using System;
using System.Collections.Generic;

namespace gardenia.Model;

public partial class SurveyQuestion
{
    public int Id { get; set; }

    public string Question { get; set; } = null!;
}
