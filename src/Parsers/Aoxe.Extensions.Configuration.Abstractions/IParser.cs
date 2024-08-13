namespace Aoxe.Extensions.Configuration.Abstractions;

public interface IParser
{
    Dictionary<string, string?> Flatten(Stream stream);
}
