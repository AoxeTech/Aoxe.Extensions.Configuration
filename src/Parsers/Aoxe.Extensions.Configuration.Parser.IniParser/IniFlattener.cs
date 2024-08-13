namespace Aoxe.Extensions.Configuration.Parser.IniParser;

public class IniFlattener : IFlattener
{
    public Dictionary<string, string?> Flatten(Stream stream)
    {
        var iniData = new FileIniDataParser().ReadData(new StreamReader(stream));
        var result = new Dictionary<string, string?>();
        foreach (var section in iniData.Sections)
        {
            foreach (var key in section.Keys)
            {
                var flatKey = $"{section.SectionName}:{key.KeyName}";
                result[flatKey] = key.Value;
            }
        }

        return result;
    }
}
