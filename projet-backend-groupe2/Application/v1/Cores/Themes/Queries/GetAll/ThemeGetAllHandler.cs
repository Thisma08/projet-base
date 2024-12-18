using Application.v1.Shared.Generic;
using Application.v1.Shared.Utils;
using Infrastructure.EF.interfaces;

namespace Application.v1.Cores.Themes.Queries.GetAll;

public class ThemeGetAllHandler : GenericHandler<IThemeRepository>, IQueryHandlerEmptyQuery<ThemeGetAllOutput>
{
    public ThemeGetAllHandler(IThemeRepository tRepository) : base(tRepository)
    {
    }

    public ThemeGetAllOutput Handle()
    {
        var output = new ThemeGetAllOutput();
        foreach (var dbTheme in _TRepository.FetchAll())
            output.Themes.Add(_mapper.Map<ThemeGetAllOutput.Theme>(dbTheme));
        return output;
    }
}