using System.Linq;
using System.Windows;
using RDev.ToolsSys.UserInterface.WPFApplication.Controles.Cadastro;
using WPF.MDI;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System;

namespace RDev.ToolsSys.UserInterface.WPFApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Menu_RefreshWindows();

            Container.Children.CollectionChanged += (o, e) => Menu_RefreshWindows();
            Aero.IsChecked = true;

            FuncionarioMenu.Icon = new BitmapImage(new Uri("OriginalLogo.png", UriKind.Relative));
        }

        #region Temas
        private void Luna_Click(object sender, RoutedEventArgs e)
        {
            Luna.IsChecked = true;
            Aero.IsChecked = false;

            Container.Theme = ThemeType.Luna;
        }

        private void Aero_Click(object sender, RoutedEventArgs e)
        {
            Luna.IsChecked = false;
            Aero.IsChecked = true;

            Container.Theme = ThemeType.Aero;
        }
        #endregion

        void Menu_RefreshWindows()
        {
            WindowsMenu.Items.Clear();
            MenuItem mi;
            for (int i = 0; i < Container.Children.Count; i++)
            {
                MdiChild child = Container.Children[i];
                mi = new MenuItem { Header = child.Title };
                mi.Click += (o, e) => child.Focus();
                WindowsMenu.Items.Add(mi);
            }
            WindowsMenu.Items.Add(new Separator());
            WindowsMenu.Items.Add(mi = new MenuItem { Header = "Cascata" });
            mi.Click += (o, e) => Container.MdiLayout = MdiLayout.Cascade;
            WindowsMenu.Items.Add(mi = new MenuItem { Header = "Horizontal" });
            mi.Click += (o, e) => Container.MdiLayout = MdiLayout.TileHorizontal;
            WindowsMenu.Items.Add(mi = new MenuItem { Header = "Vertical" });
            mi.Click += (o, e) => Container.MdiLayout = MdiLayout.TileVertical;

            WindowsMenu.Items.Add(new Separator());
            WindowsMenu.Items.Add(mi = new MenuItem { Header = "Fechar Todas" });
            mi.Click += (o, e) => Container.Children.Clear();
        }

        private void JanelaCliente_Click(object sender, RoutedEventArgs e)
        {
            if (Container.Children.Where(x => x.Name == "JanelaCadastroCliente").ToList().Count <= 0)
            {
                Container.Children.Add(new MdiChild
                {
                    Title = "Cadastro Cliente",
                    Content = new ControlCliente(),
                    Width = 360,
                    Height = 370,
                    Name = "JanelaCadastroCliente",
                    MinimizeBox = false,
                    MaximizeBox = false,
                    Resizable = false
                });
            }
        }
    }
}
