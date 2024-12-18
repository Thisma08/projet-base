namespace Domain.models;

public class Question
{
    private string QuestionText { get; set; }
    private string CorrectChoice { get; set; }
    private string IncorrectChoice1 { get; set; }
    private string IncorrectChoice2 { get; set; }
    private string IncorrectChoice3 { get; set; }

    public Question(string questionText, string correctChoice, string incorrectChoice1, string incorrectChoice2,
        string incorrectChoice3)
    {
        if (string.IsNullOrWhiteSpace(questionText) ||
            string.IsNullOrWhiteSpace(correctChoice) ||
            string.IsNullOrWhiteSpace(incorrectChoice1) ||
            string.IsNullOrWhiteSpace(incorrectChoice2) ||
            string.IsNullOrWhiteSpace(incorrectChoice3))
            throw new System.Exception("Question text or correct choices are required");

        if (new HashSet<string>(StringComparer.OrdinalIgnoreCase)
                // La logique pour chequer les duplicates était incorrecte
                { correctChoice, incorrectChoice1, incorrectChoice2, incorrectChoice3 }.Count != 4)
            throw new System.Exception("There's a repeated answer");

        QuestionText = questionText;
        CorrectChoice = correctChoice;
        IncorrectChoice1 = incorrectChoice1;
        IncorrectChoice2 = incorrectChoice2;
        IncorrectChoice3 = incorrectChoice3;
    }

    public Question(Question q) : this(q.QuestionText, q.CorrectChoice, q.IncorrectChoice1, q.IncorrectChoice2,
        q.IncorrectChoice3)
    {
    }

    public bool Contains(string choice)
    {
        return CorrectChoice.Equals(choice) || IncorrectChoice1.Equals(choice) || IncorrectChoice2.Equals(choice) ||
               IncorrectChoice3.Equals(choice);
    }

    public bool Answer(string choice)
    {
        return CorrectChoice.Equals(choice);
    }

    public string GetQuestionText()
    {
        return QuestionText;
    }
}