using Domain.exceptions;
using Domain.exceptions.attemptedQuestion;

namespace Domain.models;

public class AttemptedQuestion
{
    public int? Score { get; private set; }
    public string? Answer { get; private set; }
    private Question _question;

    public Question Question
    {
        get => new Question(_question);
        private set => _question = value;
    }

    public AttemptedQuestion(Question question, string? answer = null, int? score = 0)
    {
        Question = question;

        // Verifies that the user has chosen an answer and that the score calculation is correct
        if (answer != null)
        {
            if (!question.Contains(answer))
                throw new QuestionNotContainingAnswerException();
            if (score < 0)
                throw new NegativeEarnedPointsException();
            if (question.Answer(answer) && score == 0)
                throw new NoPointsEarnedFromCorrectException();
            if (!question.Answer(answer) && score != 0)
                throw new PointsEarnedFromIncorrectException();

            Answer = answer;
            Score = score;
        }
        else
        {
            Score = score ?? 0;
            
            if (score != 0)
            {
                throw new PointsEarnedFromNoAnswerException();
            }
        }
    }

    public AttemptedQuestion(AttemptedQuestion attemptedQuestion) : this(new Question(attemptedQuestion.Question),
        attemptedQuestion.Answer, attemptedQuestion.Score)
    {
    }

    public int AnswerQuestions(int timeInSeconds, string answer)
    {
        if (timeInSeconds <= 0)
        {
            throw new NegativeTimeException();
        }

        if (Score == null)
        {
            Score = Question.Answer(answer) ? timeInSeconds : 0;
        }

        return Score ?? 0;
    }
}