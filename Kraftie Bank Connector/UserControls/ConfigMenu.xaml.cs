using Kraftie_Bank_Connector.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Forms = System.Windows.Forms;

namespace Kraftie_Bank_Connector.UserControls;

/// <summary>
/// Interaction logic for ConfigMenu.xaml
/// </summary>
public partial class ConfigMenu : UserControl
{
    

    public ConfigMenu()
    {
        InitializeComponent();
        DirectoryPathChanged += OnDirectoryPathChanged;
    }

    private void WowAccounts_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        string selectedAccount = (sender as ComboBox).SelectedItem as string;
        if (selectedAccount == KraftieConfig.SelectAccountText)
            return;

        KraftieConfig.SelectedWowAccount = selectedAccount;
        WowAccountSelectionChanged?.Invoke(this, new(DirectorySettings.WowAccountSelection, selectedAccount));
    }

    public event EventHandler<ConfigurationDirectorySettingChangedEvent>? DirectoryPathChanged;
    public event EventHandler<ConfigurationSettingsChangedEvent<string>>? WowAccountSelectionChanged;

    private void Locate_Wow_Directory_Button_Click(object sender, RoutedEventArgs e)
    {
        Forms.FolderBrowserDialog fileDialog = new();

        var result = fileDialog.ShowDialog();

        if (result != Forms.DialogResult.OK)
            return;

        string path = fileDialog.SelectedPath;

        WowDirectoryBox.Text = path;
        KraftieConfig.WowInstallDir = path;

        DirectoryPathChanged?.Invoke(this, new(DirectorySettings.WowInstallDir, path));
    }

    private void OnDirectoryPathChanged(object sender, ConfigurationDirectorySettingChangedEvent e)
    {
        // Update the accounts list
        List<string> accountFolders = Directory.GetDirectories(GetAccountsFolder()).ToList();

        foreach (string blacklistedDir in KraftieConfig.DirectoryBlacklist)
        {
            string? invalidEntry = accountFolders.Find(acct => acct.EndsWith(blacklistedDir));
            if (invalidEntry is null)
                continue;

            accountFolders.Remove(invalidEntry);
        }

        accountFolders = new(accountFolders.Prepend(KraftieConfig.SelectAccountText));

        WowAccounts.Items.Clear();
        WowAccounts.IsEnabled = true;
        WowAccounts.ItemsSource = accountFolders.Select(acct => acct.Split(@"\").Last());
        WowAccounts.SelectedIndex = 0;
    }

    private string GetAccountsFolder() => Path.Combine(WowDirectoryBox.Text, KraftieConfig.AccountsFolder);
}
