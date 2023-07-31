using Kraftie_Bank_Connector.Events;
using Kraftie_Bank_Connector.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kraftie_Bank_Connector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ConfigMenu _config;
        private readonly KraftieBanking _banking;
        private readonly CharacterSelector _characterSelect;

        public MainWindow()
        {
            InitializeComponent();
            _config = new ConfigMenu();
            _characterSelect = new CharacterSelector();
            _banking = new KraftieBanking();
            CharSelectBtn.IsEnabled = KraftieConfig.IsConfigured;

            SubscribeEventListeners();
        }

        private void SubscribeEventListeners()
        {
            _config.WowAccountSelectionChanged += _characterSelect.OnWowAccountSelectionChanged;
            _config.WowAccountSelectionChanged += OnConfigurationChanged;
            _config.DirectoryPathChanged += OnConfigurationChanged;
        }

        private void OnConfigurationChanged(object? sender, ConfigurationSettingsChangedEvent e)
        {
            CharSelectBtn.IsEnabled = KraftieConfig.IsConfigured;
        }

        private void Config_Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = _config;
        }

        private void CharSelect_Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = _characterSelect;
        }

        private void Banking_Operations_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = _banking;
        }
    }
}
