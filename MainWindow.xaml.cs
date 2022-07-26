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
using System.Windows.Controls.Primitives;
using IronPython.Hosting;

namespace SEMApp
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        int i = 0;
        int x = 0;
        public MainWindow()
        {
            InitializeComponent();
            this.MouseLeftButtonDown += MainWindow_MouseLeftButtonDown;
        }

        public string RunPythonCode(string t)
        {
            // Run Python Engine
            var eng = Python.CreateEngine();
            var scope = eng.CreateScope();
            eng.Execute(@"
a = 'wow '
def greetings(name):
    return a + 'Hello ' + name.title() + '!'

            ", scope);
            //get python function to use for C#
            dynamic greetings = scope.GetVariable("greetings");
            return greetings(t);
        }

        public int RunIncreaseNum(int i)
        {
            var eng = Python.CreateEngine();
            var scope = eng.CreateScope();
            eng.Execute(@"
def increase(i):
    return i + 2
            ", scope);
            dynamic increase = scope.GetVariable("increase");
            x = increase(i);
            return x;
        }

        

        void MainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }


        private void Home_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_uc.PlacementTarget = Home;
            popup_uc.Placement = PlacementMode.Right;
            popup_uc.IsOpen = true;
            Header.PopupText.Text = "Home";
        }

        private void Home_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_uc.Visibility = Visibility.Collapsed;
            popup_uc.IsOpen = false;
        }

        private void Profile_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_uc.PlacementTarget = Profile;
            popup_uc.Placement = PlacementMode.Right;
            popup_uc.IsOpen = true;
            int j = x;
            Header.PopupText.Text = "Profile";
        }

        //private void Profile_MouseMove(object sender, MouseEventArgs e)
        //{
        //    popup_uc.PlacementTarget = Profile;
        //    popup_uc.Placement = PlacementMode.Right;
        //    popup_uc.IsOpen = true;
        //    int j = i;
        //    Header.PopupText.Text = RunIncreaseNum(j).ToString();
        //}

        //private void Profile_MouseDown(object sender, EventArgs e)
        //{
        //    popup_uc.PlacementTarget = Profile;
        //    popup_uc.Placement = PlacementMode.Right;
        //    popup_uc.IsOpen = true;
        //    int j = x;
        //    Header.PopupText.Text = "Profile";
        //}

        private void Profile_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_uc.Visibility = Visibility.Collapsed;
            popup_uc.IsOpen = false;
        }

        private void Settings_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_uc.PlacementTarget = Settings;
            popup_uc.Placement = PlacementMode.Right;
            popup_uc.IsOpen = true;
            Header.PopupText.Text = "Settings";
        }

        private void Settings_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_uc.Visibility = Visibility.Collapsed;
            popup_uc.IsOpen = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
