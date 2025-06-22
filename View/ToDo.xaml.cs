using Microsoft.Win32;
using System.Windows;
using ViewModel;

namespace View
{
    /// <summary>
    /// Логика взаимодействия для ToDo.xaml
    /// </summary>
    public partial class ToDo : Window
    {
        private readonly ToDoViewModel toDoViewModel = new();

        public ToDo()
        {
            InitializeComponent();
            DataContext = toDoViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                FileName = "tasks.txt",
                
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                toDoViewModel.SaveToFileCommandExecute(saveFileDialog.FileName);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            

            if (openFileDialog.ShowDialog() == true)
            {
                toDoViewModel.LoadFromFileCommandExecute(openFileDialog.FileName);
            }
        }
    }
}
