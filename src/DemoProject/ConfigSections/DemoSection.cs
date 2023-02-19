using System.Configuration;

namespace DemoProject.ConfigSections
{
    public class DemoSection : ConfigurationSection
    {
        [ConfigurationProperty("remoteOnly", DefaultValue = false, IsRequired = false)]
        public bool RemoteOnly
        {
            get
            {
                return (bool)this["remoteOnly"];
            }
            set
            {
                this["remoteOnly"] = value;
            }
        }

        [ConfigurationProperty("filePath", IsRequired = true)]
        public string FilePath
        {
            get
            {
                return (string)this["filePath"];
            }
            set
            {
                this["filePath"] = value;
            }
        }

        [ConfigurationProperty("SearchOptions", IsRequired = true)]
        public DemoSearchOptionsElement SearchOptions
        {
            get
            {
                return (DemoSearchOptionsElement)this["SearchOptions"];
            }
            set
            {
                this["SearchOptions"] = value;
            }
        }
    }

    public class DemoSearchOptionsElement : ConfigurationElement
    {
        [ConfigurationProperty("searchInAllChildren", DefaultValue = false, IsRequired = false)]
        public bool SearchInAllChildren
        {
            get
            {
                return (bool)this["searchInAllChildren"];
            }
            set
            {
                this["searchInAllChildren"] = value;
            }
        }

        [ConfigurationProperty("fileLimit", DefaultValue = 100,  IsRequired = true)]
        [IntegerValidator(ExcludeRange = false, MaxValue = 1_000_000, MinValue = 1)]
        public int FileLimit
        {
            get
            {
                return (int)this["fileLimit"];
            }
            set
            {
                this["fileLimit"] = value;
            }
        }
    }
}