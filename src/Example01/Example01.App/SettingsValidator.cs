using FluentValidation;

namespace Example01.App;

public class SettingsValidator : AbstractValidator<Settings>
{
    public SettingsValidator()
    {
        RuleFor(x => x.PluginsPath)
            .NotEmpty()
            .DirectoryExists();

        RuleFor(x => x.PluginsPattern)
            .NotEmpty();
    }
}