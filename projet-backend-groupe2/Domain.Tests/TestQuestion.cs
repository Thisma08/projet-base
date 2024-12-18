using Domain.models;
using Xunit;

namespace Domain.Tests;

public class TestQuestion
{
    [Fact]
        public void Constructor_ShouldCreateInstance_WithValidInputs()
        {
            // Arrange
            string questionText = "What is the capital of France?";
            string correctChoice = "Paris";
            string incorrectChoice1 = "London";
            string incorrectChoice2 = "Berlin";
            string incorrectChoice3 = "Madrid";

            // Act
            var question = new Question(questionText, correctChoice, incorrectChoice1, incorrectChoice2, incorrectChoice3);

            // Assert
            Assert.NotNull(question);
            Assert.Equal(questionText, question.GetQuestionText());
        }

    [Theory]
    [InlineData("", "Paris", "London", "Berlin", "Madrid", "Question text or correct choices are required")]
    [InlineData("What is the capital of France?", "", "London", "Berlin", "Madrid", "Question text or correct choices are required")]
    [InlineData("What is the capital of France?", "Paris", "Paris", "Berlin", "Madrid", "There's a repeated answer")]
    [InlineData("What is the capital of France?", "Paris", "London", "Paris", "Madrid", "There's a repeated answer")]
    public void Constructor_ShouldThrowException_ForInvalidInputs(
        string questionText, string correctChoice, string incorrectChoice1, string incorrectChoice2, string incorrectChoice3, string expectedMessage)
    {
        // Act & Assert
        var exception = Assert.Throws<System.Exception>(() => 
            new Question(questionText, correctChoice, incorrectChoice1, incorrectChoice2, incorrectChoice3));
    
        // Assert
        Assert.Contains(expectedMessage, exception.Message);
    }

        [Fact]
        public void Contains_ShouldReturnTrue_WhenChoiceExists()
        {
            // Arrange
            var question = new Question("What is 2+2?", "4", "3", "5", "6");

            // Act & Assert
            Assert.True(question.Contains("4"));
            Assert.True(question.Contains("3"));
            Assert.True(question.Contains("5"));
            Assert.True(question.Contains("6"));
        }

        [Fact]
        public void Contains_ShouldReturnFalse_WhenChoiceDoesNotExist()
        {
            // Arrange
            var question = new Question("What is 2+2?", "4", "3", "5", "6");

            // Act & Assert
            Assert.False(question.Contains("7"));
        }

        [Fact]
        public void Answer_ShouldReturnTrue_ForCorrectChoice()
        {
            // Arrange
            var question = new Question("What is 2+2?", "4", "3", "5", "6");

            // Act
            var isCorrect = question.Answer("4");

            // Assert
            Assert.True(isCorrect);
        }

        [Fact]
        public void Answer_ShouldReturnFalse_ForIncorrectChoice()
        {
            // Arrange
            var question = new Question("What is 2+2?", "4", "3", "5", "6");

            // Act
            var isCorrect = question.Answer("5");

            // Assert
            Assert.False(isCorrect);
        }

        [Fact]
        public void GetQuestionText_ShouldReturnCorrectText()
        {
            // Arrange
            string questionText = "What is the capital of France?";
            var question = new Question(questionText, "Paris", "London", "Berlin", "Madrid");

            // Act
            var result = question.GetQuestionText();

            // Assert
            Assert.Equal(questionText, result);
        }
}