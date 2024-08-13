namespace Aoxe.Extensions.Configuration.Parser.Abstractions;

public interface IFlatten
{
    Dictionary<string, string?> Flatten(Stream stream);
}
