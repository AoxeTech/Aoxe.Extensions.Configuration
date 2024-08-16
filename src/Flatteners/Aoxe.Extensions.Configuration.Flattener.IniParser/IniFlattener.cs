namespace Aoxe.Extensions.Configuration.Flattener.IniParser;

public class IniFlattener : IFlattener
{
    public IDictionary<string, string?> Flatten(Stream stream)
    {
        var result = new Dictionary<string, string?>();
        if (stream.IsNullOrEmpty())
            return result;
        IniData iniData;
        using (var streamReader = new StreamReader(stream))
            iniData = new FileIniDataParser().ReadData(streamReader);

        foreach (var section in iniData.Sections)
        foreach (var keyData in section.Keys)
            result[$"{section.SectionName}:{keyData.KeyName}"] = keyData.Value;

        return result;
    }
}
