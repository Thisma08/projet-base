using Domain.models;
using Xunit;

namespace Domain.Tests;

public class TestAttemptedQuizz
{
    [Fact]
    public void AttemptedQuizz_Constructor_ShouldCalculateScoreCorrectly()
    {
        // Arrange
        var question = new Question("What is 2+2?", "4", "3", "5", "6");
        var attemptedQuestion1 = new AttemptedQuestion(question, "4", 10);
        var attemptedQuestion2 = new AttemptedQuestion(question, "3", 0);
        var attemptedQuestions = new List<AttemptedQuestion> { attemptedQuestion1, attemptedQuestion2 };

        // Act
        var attemptedQuizz = new AttemptedQuizz(attemptedQuestions);

        // Assert
        Assert.Equal(10, attemptedQuizz.Score);
    }

    [Fact]
    public void AttemptedQuizz_CopyConstructor_ShouldCopyPropertiesCorrectly()
    {
        // Arrange
        var question = new Question("What is 2+2?", "4", "3", "5", "6");
        var attemptedQuestion1 = new AttemptedQuestion(question, "4", 10);
        var attemptedQuestions = new List<AttemptedQuestion> { attemptedQuestion1 };
        var originalQuizz = new AttemptedQuizz(attemptedQuestions);

        // Act
        var copiedQuizz = new AttemptedQuizz(originalQuizz);

        // Assert
        Assert.NotSame(originalQuizz, copiedQuizz);
        Assert.NotSame(originalQuizz.AttemptedQuestions, copiedQuizz.AttemptedQuestions);
        Assert.Equal(originalQuizz.Score, copiedQuizz.Score);
        Assert.Equal(originalQuizz.AttemptedQuestions.Count, copiedQuizz.AttemptedQuestions.Count);
    }

    [Fact]
    public void AttemptedQuizz_Constructor_ShouldHandleEmptyList()
    {
        // Arrange
        var attemptedQuestions = new List<AttemptedQuestion>();

        // Act
        var attemptedQuizz = new AttemptedQuizz(attemptedQuestions);

        // Assert
        Assert.Equal(0, attemptedQuizz.Score);
    }
}