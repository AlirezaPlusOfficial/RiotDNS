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
using System.Threading;
using System.Reflection;
using System.Security.Principal;
using System.Management;
using System.IO;
using System.Security.Cryptography.X509Certificates;




namespace RiotDNS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Controller controller = new Controller();
        Settings settings = new Settings();
        DNSService DNS = new DNSService();
        string SetMyDNS = String.Empty;

        public MainWindow()
        {
            InitializeComponent();

            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                if (e.ExceptionObject is Exception ex)
                {
                    controller.LogWrite($"Unhandled Exception: {ex.Message}\n{ex.StackTrace}");
                }
                else
                {
                    controller.LogWrite($"Unhandled Exception: {e.ExceptionObject}");
                }
            };

            TaskScheduler.UnobservedTaskException += (sender, e) =>
            {
                foreach (var ex in e.Exception.InnerExceptions)
                {
                    controller.LogWrite($"Task Exception: {ex.Message}\n{ex.StackTrace}");
                }

                e.SetObserved();
            };

            controller.LogWrite("GLOBAL EXCEPTION HANDLERS INITIALIZIED.");




            try
            {
                controller.LogWrite("APP STARTED v" + settings.GetRDVersion());
            }
            catch (Exception)
            {
            }

            if (settings.CheckAdmin() == false)
            {
                //display message and exit
                MessageBoxResult result = MessageBox.Show("This application must be run as an administrator.", "ERROR CODE ( RD1 )", MessageBoxButton.OK, MessageBoxImage.Error);
                controller.LogWrite("APPLICATION ACCESS TO UPDATE ITSELF DENIED CAUSE OF ADMIN PRIVILAGES! ( RD1 )");
                if (result != MessageBoxResult.OK)
                {
                    System.Windows.Application.Current.Shutdown();             
                }
            }


            try
            {

                if (settings.devMode != true)
                {
                    controller.LogWrite("THE UPDATER WAS CALLED");
                    AutoUpdater updater = new AutoUpdater(tagLbl);
                    updater.DoUpdate();
                }
                else
                {
                    controller.LogWrite("DEV MODE IS NOT ENABLED!");
                }

            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the update process
                MessageBox.Show("Error checking for updates: " + ex.Message);
                controller.LogWrite("CRASH ON CHECKING DEV MODE : " + ex.Message + "( RD-1 )");
                Close();
            }

            //tagLbl.Text = settings.buildType + " " + "v" + settings.GetRDVersion();


            foreach (string item in settings.dnsServers)
            {
                dnsCombo.Items.Add(item);
            }
            dnsCombo.SelectedIndex = 0; // -1 Default | +1 Indexes...
            controller.LogWrite("SERVERS IMPORTED");


        }

        
        
        

        private void Close_App_Click(object sender, RoutedEventArgs e)
        {
            controller.LogWrite("APPLICATION CLOSED");
            Close();

        }

        private async void Tg_btn_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool) Tg_btn.IsChecked)
            {
                dnsCombo.IsEnabled = !dnsCombo.IsEnabled;
                if (dnsCombo.SelectedIndex == 0)
                {
                    SetMyDNS = DNS.SetDNS("Radar Game");
                    tagLbl.Text = "CONNECTING To Radar Game";
                    SetMyDNS += " " + await controller.GetServerPing("Radar Game");
                }
                else if (dnsCombo.SelectedIndex == 1)
                {
                    SetMyDNS = DNS.SetDNS("Electro");
                    tagLbl.Text = "CONNECTING To Electro";
                    SetMyDNS += " " + await controller.GetServerPing("Electro");
                }
                else if (dnsCombo.SelectedIndex == 2)
                {
                    SetMyDNS = DNS.SetDNS("Shecan");
                    tagLbl.Text = "CONNECTING To Shecan";
                    SetMyDNS += " " + await controller.GetServerPing("Shecan");
                }
                else if (dnsCombo.SelectedIndex == 3)
                {
                    SetMyDNS = DNS.SetDNS("Begzar");
                    tagLbl.Text = "CONNECTING To Begzar";
                    SetMyDNS += " " + await controller.GetServerPing("Begzar");
                }
                else if (dnsCombo.SelectedIndex == 4)
                {
                    SetMyDNS = DNS.SetDNS("Anti 403");
                    tagLbl.Text = "CONNECTING To Anti 403";
                    SetMyDNS += " " + await controller.GetServerPing("Anti 403");
                }
                else if (dnsCombo.SelectedIndex == 5)
                {
                    SetMyDNS = DNS.SetDNS("OpenDNS");
                    tagLbl.Text = "CONNECTING To OpenDNS";
                    SetMyDNS += " " + await controller.GetServerPing("OpenDNS");
                }
                else if (dnsCombo.SelectedIndex == 6)
                {
                    SetMyDNS = DNS.SetDNS("CloudFlare");
                    tagLbl.Text = "CONNECTING To CloudFlare";
                    SetMyDNS += " " + await controller.GetServerPing("CloudFlare");
                }
                else if (dnsCombo.SelectedIndex == 7)
                {
                    SetMyDNS = DNS.SetDNS("Google");
                    tagLbl.Text = "CONNECTING To Google";
                    SetMyDNS += " " + await controller.GetServerPing("Google");
                }
                else if (dnsCombo.SelectedIndex == 8)
                {
                    SetMyDNS = DNS.SetDNS("Quad 9");
                    tagLbl.Text = "CONNECTING To Quad 9";
                    SetMyDNS += " " + await controller.GetServerPing("Quad 9");
                }
                else if (dnsCombo.SelectedIndex == 9)
                {
                    SetMyDNS = DNS.SetDNS("KeepSolid");
                    tagLbl.Text = "CONNECTING To KeepSolid";
                    SetMyDNS += " " + await controller.GetServerPing("KeepSolid");
                }
                tagLbl.Text = SetMyDNS;
            } 
            else
            {
                dnsCombo.IsEnabled = !dnsCombo.IsEnabled;
                DNS.ClearDNS();
                tagLbl.Text = "DISCONNECTED";
            }
            controller.LogWrite("MAIN BUTTON TOGGLED!");
        }

    }
}
