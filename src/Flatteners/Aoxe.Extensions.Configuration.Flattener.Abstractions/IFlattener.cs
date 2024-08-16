namespace Aoxe.Extensions.Configuration.Flattener.Abstractions;

public interface IFlattener
{
    IDictionary<string, string?> Flatten(Stream stream);
}
