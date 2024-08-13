namespace Aoxe.Extensions.Configuration.Parser.Abstractions;

public interface IFlattener
{
    Dictionary<string, string?> Flatten(Stream stream);
}
