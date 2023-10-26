using System;
using System.Collections.Generic;

namespace gardenia.Model;

public partial class SurveyQuestion
{
    public int Id { get; }
    public string Question { get; set; } = null!;
    public string? ValidationRule { get; set; }
}
