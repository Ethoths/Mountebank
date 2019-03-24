namespace ConsoleApplication4.Config
{
    public interface IConfigurationSection
    {
        ServiceCollection Services { get; }

        ServiceConfig GetServiceConfig(string name);
    }
}