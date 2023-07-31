using Kraftie_Bank_Connector.Models;
using System.Collections.Generic;

namespace Kraftie_Bank_Connector;

public static class KraftieConfig
{
    public static readonly string[] DirectoryBlacklist = { "SavedVariables" };
    public static readonly string CharacterSavedVariablesFolder = "SavedVariables";
    public static readonly string BankContentsFileName = "KraftieBank.lua";
    public static readonly string AccountsFolder = @"_classic_era_\WTF\Account";
    public static readonly string SelectAccountText = "Select account";
    public static string? WowInstallDir { get; set; }
    public static string? SelectedWowAccount { get; set; }
    public static bool IsConfigured { get => !string.IsNullOrWhiteSpace(WowInstallDir) && !string.IsNullOrWhiteSpace(SelectedWowAccount); }

    public static List<Character> EnabledCharacters { get; set; } = new();
}
