using System.Collections.Generic;

namespace Avtotest.WPF.Models;

public class QuestionEntity
{
    public int Id { get; set; }
    public string Question { get; set; }
    public string Description { get; set; }
    public List<Choice> Choices { get; set; }
    public Media Media { get; set; }
}