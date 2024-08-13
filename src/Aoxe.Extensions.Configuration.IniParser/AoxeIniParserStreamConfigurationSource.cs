namespace Aoxe.Extensions.Configuration.IniParser;

public class AoxeIniParserStreamConfigurationSource()
    : AoxeStreamConfigurationSource(new IniFlattener());
