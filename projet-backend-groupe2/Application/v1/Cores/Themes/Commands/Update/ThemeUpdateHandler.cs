using Application.v1.Shared.Generic;
using Application.v1.Shared.Utils;
using Infrastructure.EF.DbEntities;
using Infrastructure.EF.interfaces;

namespace Application.v1.Cores.Themes.Commands.Update;

public class ThemeUpdateHandler : GenericHandler<IThemeRepository>, ICommandsHandler<ThemeUpdateCommand, bool>
{
    public ThemeUpdateHandler(IThemeRepository tRepository) : base(tRepository)
    {
    }

    public bool Handle(ThemeUpdateCommand command)
    {
        var dbTheme = _mapper.Map<DbTheme>(command);
        return _TRepository.Update(dbTheme);
    }
}