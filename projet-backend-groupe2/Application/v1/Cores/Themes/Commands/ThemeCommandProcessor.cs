using Application.v1.Cores.Themes.Commands.Create;
using Application.v1.Cores.Themes.Commands.Delete;
using Application.v1.Cores.Themes.Commands.Update;

namespace Application.v1.Cores.Themes.Commands;

public class ThemeCommandProcessor
{
    private readonly ThemeCreateHandler _themeCreateHandler;
    private readonly ThemeDeleteHandler _themeDeleteHandler;
    private readonly ThemeUpdateHandler _themeUpdateHandler;


    public ThemeCommandProcessor(ThemeCreateHandler themeCreateHandler, ThemeUpdateHandler themeUpdateHandler,
        ThemeDeleteHandler themeDeleteHandler)
    {
        _themeCreateHandler = themeCreateHandler;
        _themeUpdateHandler = themeUpdateHandler;
        _themeDeleteHandler = themeDeleteHandler;
    }

    public ThemeCreateOutput Create(ThemeCreateCommand command)
    {
        return _themeCreateHandler.Handle(command);
    }

    public bool Update(ThemeUpdateCommand command)
    {
        return _themeUpdateHandler.Handle(command);
    }

    public bool Delete(int query)
    {
        return _themeDeleteHandler.Handle(query);
    }
}