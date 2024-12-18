using Domain.exceptions.user;
using Domain.models;
using Xunit;

namespace Domain.Tests;

public class TestUser
{
    [Fact]
    public void Register_ShouldSucceed_WithValidInputs()
    {
        // Arrange
        string username = "ValidUser";
        string password = "Valid@1234";
        string email = "test@example.com";
        string role = "ROLES_USER";

        // Act
        var user = User.Register(username, password, email, role);

        // Assert
        Assert.Equal(username, user.GetUsername());
        Assert.Equal(email, user.GetEmail());
        Assert.True(BCrypt.Net.BCrypt.Verify(password, user.GetHashedPassword()));
        Assert.Equal(role, user.GetRole());
    }

    [Fact]
    public void Register_ShouldThrowException_ForInvalidUsername()
    {
        // Arrange
        var user = new User("dummy", "hashedPassword");
        string username = "ab";
        string password = "Valid@1234";
        string email = "test@example.com";

        // Act & Assert
        var ex = Assert.Throws<InvalidUsernameLengthException>(() =>
            User.Register(username, password, email));

        Assert.Equal("Username must be between 3 and 50 characters.", ex.Message);
    }

    [Fact]
    public void Register_ShouldThrowException_ForInvalidPassword()
    {
        // Arrange
        var user = new User("dummy", "hashedPassword");
        string username = "ValidUser";
        string password = "12345";
        string email = "test@example.com";

        // Act & Assert
        var ex = Assert.Throws<InvalidPasswordFormatException>(() =>
            User.Register(username, password, email));

        Assert.Equal("The format of the password is invalid.", ex.Message);
    }

    [Fact]
    public void Register_ShouldThrowException_ForInvalidEmail()
    {
        // Arrange
        var user = new User("dummy", "hashedPassword");
        string username = "ValidUser";
        string password = "Valid@1234";
        string email = "invalidemail.com";

        // Act & Assert
        var ex = Assert.Throws<InvalidEmailFormatException>(() =>
            User.Register(username, password, email));

        Assert.Equal("The format of the email is invalid.", ex.Message);
    }

    [Fact]
    public void Register_ShouldThrowException_ForInvalidRole()
    {
        // Arrange
        var user = new User("dummy", "hashedPassword");
        string username = "ValidUser";
        string password = "Valid@1234";
        string email = "test@example.com";
        string role = "INVALID_ROLE";

        // Act & Assert
        var ex = Assert.Throws<InvalidRoleFormatException>(() =>
            User.Register(username, password, email, role));

        Assert.Equal("The format of the role is invalid.", ex.Message);
    }
    
    [Fact]
    public void Login_ShouldReturnTrue_WhenPasswordMatches()
    {
        // Arrange
        var password = "Valid@1234";
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
        var user = new User("ValidUser", hashedPassword);

        // Act
        var result = user.Login(password);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Login_ShouldReturnFalse_WhenPasswordDoesNotMatch()
    {
        // Arrange
        var password = "Valid@1234";
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
        var user = new User("ValidUser", hashedPassword);

        // Act
        var result = user.Login("WrongPassword");

        // Assert
        Assert.False(result);
    }
    
    // [Fact]
    // public void User_ShouldThrowExceptions_WithCorrectMessages()
    // {
    //     // Arrange
    //     const string validUsername = "ValidUser";
    //     const string validPassword = "Password1!";
    //     const string validEmail = "user@example.com";
    //     const string validRole = "ROLES_USER";
    //
    //     // Act & Assert
    //     var exception1 = Assert.Throws<InvalidUsernameLengthException>(() => User.Register("Us", validPassword, validEmail, validRole));
    //     Assert.Equal("Username must be between 3 and 50 characters.", exception1.Message);
    //
    //     var exception2 = Assert.Throws<InvalidUsernameLengthException>(() => User.Register(new string('U', 51), validPassword, validEmail, validRole));
    //     Assert.Equal("Username must be between 3 and 50 characters.", exception2.Message);
    //
    //     var exception3 = Assert.Throws<InvalidPasswordFormatException>(() => User.Register(validUsername, "pass", validEmail, validRole));
    //     Assert.Equal("The format of the password is invalid.", exception3.Message);
    //
    //     var exception4 = Assert.Throws<InvalidEmailFormatException>(() => User.Register(validUsername, validPassword, "invalid-email", validRole));
    //     Assert.Equal("The format of the email is invalid.", exception4.Message);
    //
    //     var exception5 = Assert.Throws<InvalidRoleFormatException>(() => User.Register(validUsername, validPassword, validEmail, "INVALID_ROLE"));
    //     Assert.Equal("The format of the role is invalid.", exception5.Message);
    //
    //     var user = User.Register(validUsername, validPassword, validEmail, validRole);
    //     Assert.Equal(validUsername, user.GetUsername());
    //     Assert.Equal(validEmail, user.GetEmail());
    //     Assert.Equal(validRole, user.GetRole());
    // }
}