using Infrastructure.EF.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EF;

public class QuizzDbContext : DbContext
{
    public QuizzDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<DbUser> Users { get; set; }
    public DbSet<DbQuizz> Quizzes { get; set; }
    public DbSet<DbQuestion> Questions { get; set; }
    public DbSet<DbTheme> Themes { get; set; }
    public DbSet<DbScore> Scores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DbUser>(entity =>
        {
            entity.ToTable("users");
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Id).HasColumnName("user_id");
            entity.Property(u => u.Username).HasColumnName("username");
            entity.Property(u => u.Email).HasColumnName("email");
            entity.Property(u => u.Password).HasColumnName("password");
            entity.Property(u => u.Role).HasColumnName("role");
        });

        modelBuilder.Entity<DbQuizz>(entity =>
        {
            entity.ToTable("quizzes");
            entity.HasKey(q => q.Id);
            entity.Property(q => q.Id).HasColumnName("quizz_id");
            entity.Property(q => q.Title).HasColumnName("title");
            entity.Property(q => q.Description).HasColumnName("description");
            entity.Property(q => q.ThemeId).HasColumnName("theme_id");
            entity.Property(q => q.UserId).HasColumnName("user_id");

            entity.HasMany(q => q.Questions)
                .WithOne(q => q.Quizz)
                .HasForeignKey(q => q.QuizzId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(q => q.Theme)
                .WithMany(t => t.Quizzes)
                .HasForeignKey(q => q.ThemeId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(q => q.User)
                .WithMany(u => u.Quizzes)
                .HasForeignKey(q => q.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<DbQuestion>(entity =>
        {
            entity.ToTable("questions");
            entity.HasKey(q => q.Id);
            entity.Property(q => q.Id).HasColumnName("question_id");
            entity.Property(q => q.QuestionText).HasColumnName("question");
            entity.Property(q => q.CorrectChoice).HasColumnName("correct_choice");
            entity.Property(q => q.IncorrectChoice1).HasColumnName("incorrect_choice_1");
            entity.Property(q => q.IncorrectChoice2).HasColumnName("incorrect_choice_2");
            entity.Property(q => q.IncorrectChoice3).HasColumnName("incorrect_choice_3");
            entity.Property(q => q.QuizzId).HasColumnName("quizz_id");

            entity.HasOne(q => q.Quizz)
                .WithMany(q => q.Questions)
                .HasForeignKey(q => q.QuizzId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<DbTheme>(entity =>
        {
            entity.ToTable("themes");
            entity.HasKey(t => t.Id);
            entity.Property(t => t.Id).HasColumnName("theme_id");
            entity.Property(t => t.Title).HasColumnName("title");
        });

        modelBuilder.Entity<DbScore>(entity =>
        {
            entity.ToTable("scores");
            entity.HasKey(s => s.Id);
            entity.Property(s => s.Id).HasColumnName("score_id");
            entity.Property(s => s.ScoreValue).HasColumnName("score");
            entity.Property(s => s.UserId).HasColumnName("user_id");
            entity.Property(s => s.QuizzId).HasColumnName("quizz_id");
        });

        base.OnModelCreating(modelBuilder);
    }
}