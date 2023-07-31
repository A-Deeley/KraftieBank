using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kraftie_Bank_Connector.Events;

public class ConfigurationDirectorySettingChangedEvent : ConfigurationSettingsChangedEvent
{
    public string Path { get; set; } = "";

    public ConfigurationDirectorySettingChangedEvent(DirectorySettings directory, string path) : base(directory)
    {
        Path = path;
    }
}
