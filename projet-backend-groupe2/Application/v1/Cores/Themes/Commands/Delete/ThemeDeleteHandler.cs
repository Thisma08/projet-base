using Application.v1.Shared.Generic;
using Application.v1.Shared.Utils;
using Infrastructure.EF.interfaces;

namespace Application.v1.Cores.Themes.Commands.Delete;

public class ThemeDeleteHandler : GenericHandler<IThemeRepository>, ICommandsHandler<int, bool>
{
    public ThemeDeleteHandler(IThemeRepository tRepository) : base(tRepository)
    {
    }

    public bool Handle(int command)
    {
        return _TRepository.Delete(command);
    }
}