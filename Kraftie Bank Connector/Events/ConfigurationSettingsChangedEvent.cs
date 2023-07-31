using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Kraftie_Bank_Connector.Events;

public class ConfigurationSettingsChangedEvent<T> : ConfigurationSettingsChangedEvent
{
    public T? Setting { get; set; }
    public ConfigurationSettingsChangedEvent(DirectorySettings directory, T setting)
        :base(directory)
    {
        Setting = setting;
    }

    public ConfigurationSettingsChangedEvent(DirectorySettings directory)
        :base(directory)
    {
        Setting = default;
    }
}

public class ConfigurationSettingsChangedEvent
{
    public DirectorySettings Directory { get; set; }
    public ConfigurationSettingsChangedEvent(DirectorySettings directory)
    {
        Directory = directory;
    }
}
