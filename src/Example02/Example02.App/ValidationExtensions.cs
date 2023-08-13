using FluentValidation;

namespace Example02.App;

public static class ValidationExtensions
{
    public static Settings ValidateAndThrow(this Settings obj)
    {
        return obj.ValidateAndThrow(new SettingsValidator());
    }
    
    public static T ValidateAndThrow<T>(this T obj, IValidator<T> validator)
    {
        validator.ValidateAndThrow(obj);
        return obj;
    }
    
    public static IRuleBuilderOptions<T, string> DirectoryExists<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .Must<T, string>((Func<T, string, bool>) ((x, val) => Directory.Exists(val)))
            .WithMessage("Directory '{PropertyValue}' does not exist.");
    }
}