namespace Aoxe.Extensions.Configuration.Flattener.IniParser;

public class IniFlattener : IFlattener
{
    public Dictionary<string, string?> Flatten(Stream stream)
    {
        IniData iniData;
        using (var streamReader = new StreamReader(stream))
            iniData = new FileIniDataParser().ReadData(streamReader);
        var result = new Dictionary<string, string?>();

        foreach (var section in iniData.Sections)
        foreach (var keyData in section.Keys)
            result[$"{section.SectionName}:{keyData.KeyName}"] = keyData.Value;

        return result;
    }
}
