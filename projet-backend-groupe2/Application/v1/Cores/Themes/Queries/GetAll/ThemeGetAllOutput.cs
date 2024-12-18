namespace Application.v1.Cores.Themes.Queries.GetAll;

public class ThemeGetAllOutput
{
    public List<Theme> Themes { get; set; } = new();

    public class Theme
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}