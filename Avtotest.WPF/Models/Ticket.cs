using System.Collections.Generic;

namespace Avtotest.WPF.Models;

public class Ticket
{
    public long ChatId { get; set; }
    public int Index { get; set; }
    public int QuestionsCount { get; set; }
    public int CorrectAnswersCount { get; set; }
    public Queue<QuestionEntity> Questions { get; set; }

    public bool IsCompleted
    {
        get
        {
            return QuestionsCount == CorrectAnswersCount;
        }
    }

    public int CurrentQuestion
    {
        get
        {
            return QuestionsCount - Questions.Count;
        }
    }

    public Ticket(long chatId, Queue<QuestionEntity> questions)
    {
        ChatId = chatId;
        QuestionsCount = questions.Count;
        CorrectAnswersCount = 0;
        Questions = questions;
    }

    public Ticket(long chatId, int index, Queue<QuestionEntity> questions)
    {
        ChatId = chatId;
        QuestionsCount = questions.Count;
        CorrectAnswersCount = 0;
        Questions = questions;
        Index = index;
    }
}