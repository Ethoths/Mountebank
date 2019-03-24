using System.Configuration;

namespace ConsoleApplication4.Config
{
    public class ServiceConfigurationSection : ConfigurationSection, IConfigurationSection
    {
        [ConfigurationProperty("Services", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(ServiceCollection), AddItemName = "add", ClearItemsName = "clear", RemoveItemName = "remove")]
        public ServiceCollection Services
        {
            get { return (ServiceCollection) base["Services"]; }
        }

        public ServiceConfig GetServiceConfig(string name)
        {
            foreach (var service in Services)
            {
                var serviceConfig = (ServiceConfig)service;

                if (serviceConfig.Name == name)
                {
                    return serviceConfig;
                }
            }

            return null;
        }
    }
}