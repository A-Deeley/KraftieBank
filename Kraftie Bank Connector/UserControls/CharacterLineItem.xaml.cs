using Kraftie_Bank_Connector.Models;
using System.Windows;
using System.Windows.Controls;

namespace Kraftie_Bank_Connector.UserControls;

/// <summary>
/// Interaction logic for CharacterLineItem.xaml
/// </summary>
public partial class CharacterLineItem : UserControl
{
    public CharacterLineItem(string character)
    {
        InitializeComponent();
        CharName.Content = character;
        CharSelected.IsChecked = false;
    }

    private void CharSelected_Checked(object sender, RoutedEventArgs e)
    {
        string[] charNameDeconstructed = ((string)CharName.Content).Split('-');
        Character character = new(charNameDeconstructed[0], charNameDeconstructed[1]);
        KraftieConfig.EnabledCharacters.Add(character);
    }

    private void CharSelected_Unchecked(object sender, RoutedEventArgs e)
    {
        var character = KraftieConfig.EnabledCharacters.Find(_char => _char.Name == (string)CharName.Content);
        if (character is null)
            return;

        KraftieConfig.EnabledCharacters.Remove(character);
    }
}
