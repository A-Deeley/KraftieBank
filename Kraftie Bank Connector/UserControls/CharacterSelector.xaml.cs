using Kraftie_Bank_Connector.Events;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Controls;

namespace Kraftie_Bank_Connector.UserControls
{
    /// <summary>
    /// Interaction logic for CharacterSelector.xaml
    /// </summary>
    public partial class CharacterSelector : UserControl
    {
        
        public CharacterSelector()
        {
            InitializeComponent();
        }

        internal void OnWowAccountSelectionChanged(object? sender, ConfigurationSettingsChangedEvent<string> e)
        {
            if (string.IsNullOrWhiteSpace(e.Setting))
                return;
            List<string> servers = Directory.GetDirectories(GetAccountServersDirectory()).ToList();

            foreach (string blacklistedDir in KraftieConfig.DirectoryBlacklist)
            {
                string? invalidEntry = servers.Find(acct => acct.EndsWith(blacklistedDir));
                if (invalidEntry is null)
                    continue;

                servers.Remove(invalidEntry);
            }

            List<CharacterLineItem> characters = new();

            foreach (string server in servers)
            {
                string[] characterFolderNames = Directory.GetDirectories(server);
                foreach(string characterFolderName in characterFolderNames)
                {
                    string serverNameOnly = server.Split(@"\").Last();
                    string characterNameOnly = characterFolderName.Split(@"\").Last();
                    CharacterLineItem character = new($"{characterNameOnly}-{serverNameOnly}");
                    characters.Add(character);
                }
            }

            CharacterListBox.ItemsSource = characters;
        }

        private string GetAccountServersDirectory() => Path.Combine(KraftieConfig.WowInstallDir, KraftieConfig.AccountsFolder, KraftieConfig.SelectedWowAccount);
    }
}
