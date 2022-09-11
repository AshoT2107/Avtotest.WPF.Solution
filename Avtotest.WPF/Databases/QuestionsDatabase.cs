using System.Collections.Generic;
using System.Linq;
using Avtotest.WPF.Models;

namespace Avtotest.WPF.Databases;

public class QuestionsDatabase
{
    public List<QuestionEntity> Questions { get; set; }

    public QuestionsDatabase(List<QuestionEntity> questions)
    {
        Questions = questions;
    }

    public List<QuestionEntity> CreateTicket(int from = 0, int questionsCount = 20)
    {
        return Questions.Skip(from).Take(questionsCount).ToList();
    }
}