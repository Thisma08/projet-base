using Domain.exceptions.attemptedQuestion;
using Domain.models;
using Xunit;

namespace Domain.Tests;

public class TestAttemptedQuestion
{
    [Fact]
    public void Question_Constructor_ShouldThrowException_WhenInputsAreInvalid()
    {
        // Arrange
        var invalidText = "";
        var duplicateChoices = new[] { "wrong1", "wrong1", "wrong3" };

        // Act & Assert
        Assert.Throws<System.Exception>(() => new Question(invalidText, "correct", "wrong1", "wrong2", "wrong3"));
        Assert.Throws<System.Exception>(() => new Question("Question text", "correct", duplicateChoices[0], duplicateChoices[1], duplicateChoices[2]));
    }

    [Fact]
    public void Question_Contains_ShouldReturnTrue_ForExistingChoice()
    {
        // Arrange
        var question = new Question("Question text", "correct", "wrong1", "wrong2", "wrong3");
        var existingChoice = "correct";
        var anotherExistingChoice = "wrong1";
        var nonExistingChoice = "not_in_choices";

        // Act
        var containsCorrect = question.Contains(existingChoice);
        var containsWrong1 = question.Contains(anotherExistingChoice);
        var containsInvalid = question.Contains(nonExistingChoice);

        // Assert
        Assert.True(containsCorrect);
        Assert.True(containsWrong1);
        Assert.False(containsInvalid);
    }

    [Fact]
    public void Question_Answer_ShouldReturnTrue_ForCorrectChoice()
    {
        // Arrange
        var question = new Question("Question text", "correct", "wrong1", "wrong2", "wrong3");
        var correctChoice = "correct";
        var incorrectChoice = "wrong1";

        // Act
        var isCorrect = question.Answer(correctChoice);
        var isIncorrect = question.Answer(incorrectChoice);

        // Assert
        Assert.True(isCorrect);
        Assert.False(isIncorrect);
    }

    [Fact]
    public void AttemptedQuestion_Constructor_ShouldInitializeCorrectly_WithValidInputs()
    {
        // Arrange
        var question = new Question("Question text", "correct", "wrong1", "wrong2", "wrong3");
        var validAnswer = "correct";
        var validScore = 10;

        // Act
        var attemptedQuestion = new AttemptedQuestion(question, validAnswer, validScore);

        // Assert
        Assert.Equal(question.GetQuestionText(), attemptedQuestion.Question.GetQuestionText());
        Assert.Equal(validAnswer, attemptedQuestion.Answer);
        Assert.Equal(validScore, attemptedQuestion.Score);
    }

    [Fact]
    public void AttemptedQuestion_Constructor_ShouldThrowException_ForInvalidAnswer()
    {
        // Arrange
        var question = new Question("Question text", "correct", "wrong1", "wrong2", "wrong3");
        var invalidAnswer = "invalid";

        // Act & Assert
        Assert.Throws<QuestionNotContainingAnswerException>(() => new AttemptedQuestion(question, invalidAnswer, 10));
    }

    [Fact]
    public void AttemptedQuestion_Constructor_ShouldThrowException_ForIncorrectScore()
    {
        // Arrange
        var question = new Question("Question text", "correct", "wrong1", "wrong2", "wrong3");
        var correctAnswer = "correct";
        var invalidScores = new[] { 0, 5 };

        // Act & Assert
        Assert.Throws<NoPointsEarnedFromCorrectException>(() => new AttemptedQuestion(question, correctAnswer, invalidScores[0]));
        Assert.Throws<PointsEarnedFromIncorrectException>(() => new AttemptedQuestion(question, "wrong1", invalidScores[1]));
    }
    
    [Fact]
    public void AttemptedQuestion_Constructor_ShouldThrowException_ForNullQuestion()
    {
        // Act & Assert
        Assert.Throws<NullReferenceException>(() => new AttemptedQuestion(null!));
    }
    
    [Fact]
    public void AttemptedQuestion_Constructor_ShouldInitializeDefaults_WhenOnlyQuestionProvided()
    {
        // Arrange
        var question = new Question("Question text", "correct", "wrong1", "wrong2", "wrong3");

        // Act
        var attemptedQuestion = new AttemptedQuestion(question);

        // Assert
        Assert.Equal(question.GetQuestionText(), attemptedQuestion.Question.GetQuestionText());
        Assert.Null(attemptedQuestion.Answer);
        Assert.Equal(0, attemptedQuestion.Score);
    }
    
    [Fact]
    public void AttemptedQuestion_ShouldThrowExceptions_WithCorrectMessages()
    {
        // Arrange
        var question = new Question("Question text", "correct", "wrong1", "wrong2", "wrong3");

        // Act & Assert
        var exception1 = Assert.Throws<QuestionNotContainingAnswerException>(() => new AttemptedQuestion(question, "invalid", 10));
        Assert.Equal("The question doesn't contain the answer.", exception1.Message);

        var exception2 = Assert.Throws<NegativeEarnedPointsException>(() => new AttemptedQuestion(question, "correct", -5));
        Assert.Equal("The user has negative earned points.", exception2.Message);

        var exception3 = Assert.Throws<PointsEarnedFromNoAnswerException>(() => new AttemptedQuestion(question, null, 5));
        Assert.Equal("The user earned points even though they didn't answer.", exception3.Message);
    }

    [Fact]
    public void AttemptedQuestion_AnswerQuestions_ShouldCalculateScoreCorrectly()
    {
        // Arrange
        var question1 = new Question("Question text", "correct", "wrong1", "wrong2", "wrong3");
        var attemptedQuestion1 = new AttemptedQuestion(question1, "correct", 10);
        var validTime1 = 10; 
        var correctAnswer = "correct"; 
        
        var question2 = new Question("Question text", "correct", "wrong1", "wrong2", "wrong3");
        var attemptedQuestion2 = new AttemptedQuestion(question2, "correct", 10);
        var validTime2 = 10; 
        var incorrectAnswer = "wrong1"; 

        // Act
        var calculatedScoreCorrect = attemptedQuestion1.AnswerQuestions(validTime1, correctAnswer);
        var calculatedScoreIncorrect = attemptedQuestion2.AnswerQuestions(validTime2, incorrectAnswer);

        // Assert
        Assert.Equal(10, calculatedScoreCorrect);
        Assert.Equal(10, calculatedScoreIncorrect);
    }

    [Fact]
    public void AttemptedQuestion_AnswerQuestions_ShouldThrowException_ForInvalidTime()
    {
        // Arrange
        var question = new Question("Question text", "correct", "wrong1", "wrong2", "wrong3");
        var attemptedQuestion = new AttemptedQuestion(question);
        var invalidTimes = new[] { 0, -5 };

        // Act & Assert
        Assert.Throws<NegativeTimeException>(() => attemptedQuestion.AnswerQuestions(invalidTimes[0], "correct"));
        Assert.Throws<NegativeTimeException>(() => attemptedQuestion.AnswerQuestions(invalidTimes[1], "wrong1"));
    }
    
    [Fact]
    public void AttemptedQuestion_AnswerQuestions_ShouldNotModifyScore_IfAlreadyAnswered()
    {
        // Arrange
        var question = new Question("Question text", "correct", "wrong1", "wrong2", "wrong3");
        var attemptedQuestion = new AttemptedQuestion(question, "correct", 10);

        // Act
        var newScore = attemptedQuestion.AnswerQuestions(5, "wrong1");

        // Assert
        Assert.Equal(10, attemptedQuestion.Score);
        Assert.Equal("correct", attemptedQuestion.Answer);
        Assert.Equal(10, newScore);
    }
}
