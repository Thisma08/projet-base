using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.EF.DbEntities;

public class DbQuizz
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int ThemeId { get; set; }
    public int UserId { get; set; }

    [ForeignKey("ThemeId")] public virtual DbTheme Theme { get; set; }

    [ForeignKey("UserId")] public virtual DbUser User { get; set; }

    // Navigation property to establish the relationship
    public virtual ICollection<DbQuestion> Questions { get; set; } = new List<DbQuestion>();
}