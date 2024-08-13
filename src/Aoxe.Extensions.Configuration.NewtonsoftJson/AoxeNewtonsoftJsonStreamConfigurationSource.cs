namespace Aoxe.Extensions.Configuration.NewtonsoftJson;

public class AoxeNewtonsoftJsonStreamConfigurationSource()
    : AoxeStreamConfigurationSource(new JsonFlattener());
