using System.Windows;
using ViewModel;

namespace View
{
    /// <summary>
    /// Логика взаимодействия для ToDo.xaml
    /// </summary>
    public partial class ToDo : Window
    {
        public ToDo()
        {
            InitializeComponent();
            DataContext = new ToDoViewModel();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{

        //}
    }
}
