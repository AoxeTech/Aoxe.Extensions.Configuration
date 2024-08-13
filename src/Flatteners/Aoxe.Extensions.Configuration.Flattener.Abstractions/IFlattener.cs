namespace Aoxe.Extensions.Configuration.Flattener.Abstractions;

public interface IFlattener
{
    Dictionary<string, string?> Flatten(Stream stream);
}
