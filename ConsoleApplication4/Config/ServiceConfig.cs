using System;
using System.Collections.Generic;
using System.Configuration;

namespace ConsoleApplication4.Config
{
    public class ServiceConfig : ConfigurationElement
    {
        [ConfigurationProperty("Name", DefaultValue = "", IsRequired = true, IsKey = true)]
        public string Name
        {
            get => (string)this["Name"];

            set => this["Name"] = value;
        }

        [ConfigurationProperty("Port", DefaultValue = 0, IsRequired = true, IsKey = false)]
        public int Port
        {
            get => (int)this["Port"];

            set => this["Port"] = value;
        }

        [ConfigurationProperty("Description", DefaultValue = "", IsRequired = true, IsKey = false)]
        public string Description
        {
            get => (string)this["Description"];

            set => this["Description"] = value;
        }

        [ConfigurationProperty("ServiceRecordRequests", DefaultValue = false, IsRequired = false, IsKey = false)]
        public bool ServiceRecordRequests
        {
            get => (bool)this["ServiceRecordRequests"];

            set => this["ServiceRecordRequests"] = value;
        }

        [ConfigurationProperty("Headers", DefaultValue = null, IsRequired = false, IsKey = false)]
        public string HeadersString
        {
            get => (string)this["Header"];

            set => this["Headers"] = value;
        }

        public Dictionary<string, string> Headers
        {
            get
            {
                var headers = new Dictionary<string, string>();
                
                if (HeadersString != null)
                {
                    var headerPairStrings = HeadersString.Split(';');
                
                    foreach (var headerPair in headerPairStrings)
                    {
                        var a = headerPair.Split(':');
                        headers.Add(a[0], a[1]);
                    }
                }
                
                return headers;
            }
        }

        public ServiceConfig() { }

        public ServiceConfig(int port, string name, string description, bool serviceRecordsRequests = false)
        {
            Port = port;
            Name = name;
            Description = description;
            ServiceRecordRequests = serviceRecordsRequests;
        }
    }
}