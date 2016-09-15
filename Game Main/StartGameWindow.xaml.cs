
using SnakeTest;
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
using System.Windows.Shapes;

namespace Game_Main
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Database db;
        public Window1()
        {
            try
            {
                db = new Database();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error");
            }
            InitializeComponent();
        }

        private void btStart_Click(object sender, RoutedEventArgs e)
        {
            string Name = tbName.Text;
            int Score = 0;

            if (Name.Length < 2)
            {
                MessageBox.Show("Invalid input. FirstName and lastName must be at least 2 characters long");
                return;
            }
            else
            {
                MainWindow win2 = new MainWindow();
                win2.Show();
                this.Close();

            }
            Person p = new Person() { Name = Name , Score = Score};
            db.AddPerson(p);
        }
        
    }
}