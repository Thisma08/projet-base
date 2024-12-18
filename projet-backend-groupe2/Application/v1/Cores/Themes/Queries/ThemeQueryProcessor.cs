using Application.v1.Cores.Themes.Queries.GetAll;

namespace Application.v1.Cores.Themes.Queries;

public class ThemeQueryProcessor
{
    private readonly ThemeGetAllHandler _getAllHandler;

    public ThemeQueryProcessor(ThemeGetAllHandler getAllHandler)
    {
        _getAllHandler = getAllHandler;
    }

    public List<ThemeGetAllOutput.Theme> GetAll()
    {
        return _getAllHandler.Handle().Themes;
    }
}