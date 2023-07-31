using Kraftie_Bank_Connector.Models;
using System.Windows;
using System.Windows.Controls;
using NLua;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System;
using System.Linq;
using System.Text.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace Kraftie_Bank_Connector.UserControls
{
    /// <summary>
    /// Interaction logic for CharacterBankImport.xaml
    /// </summary>
    public partial class KraftieBanking : UserControl
    {
        public KraftieBanking()
        {
            InitializeComponent();
        }

        private async void Update_Website_Click(object sender, RoutedEventArgs e)
        {
            List<Item> items = new();
            foreach (Character character in KraftieConfig.EnabledCharacters)
            {
                string bankContentsFilePath = Path.Combine(KraftieConfig.WowInstallDir, KraftieConfig.AccountsFolder, KraftieConfig.SelectedWowAccount, character.Server, character.Name, KraftieConfig.CharacterSavedVariablesFolder, KraftieConfig.BankContentsFileName);
                Lua lua = new Lua();
                var result = lua.DoFile(bankContentsFilePath);
                LuaTable luaContents = lua.GetTable("KraftieBankContents");
                var contents = luaContents.Values;
                List<LuaTable> itemValues = new();
                foreach (LuaTable item in contents)
                {
                    itemValues.Add(item);
                }
                foreach(LuaTable itemValue in itemValues)
                {
                    Dictionary<string, object> kvPairResults = new();
                    foreach(KeyValuePair<object, object> kvPairs in itemValue)
                    {
                        string key = (string)kvPairs.Key;
                        object value = kvPairs.Value;
                        kvPairResults.Add(key, value);
                    }

                    Item item = new Item(kvPairResults["id"], kvPairResults["count"], kvPairResults["quality"], kvPairResults["link"], character);
                    items.Add(item);
                }
            }

            HttpClient client = new HttpClient();
            var response = await client.PostAsJsonAsync("https://localhost:44387/api/Item/update", items);
        }

        private void Fetch_Users_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
