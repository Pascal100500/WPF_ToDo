

using System.Collections.ObjectModel;
using System.ComponentModel;
using Model;

namespace ViewModel
{
    public class ToDoViewModel : INotifyPropertyChanged
    {
        private string _textTask;
        private TaskViewModel? _selectedTask;

        public ObservableCollection<TaskViewModel> Tasks { get; set; }

        public TaskViewModel? SelectedTask
        {
            get => _selectedTask;
            set
            {
                _selectedTask = value;
                OnPropertyChanged(nameof(SelectedTask));
            }
        }

        public string TextTask
        {
            get => _textTask;
            set
            {
                _textTask = value;
                OnPropertyChanged(nameof(TextTask));
            }
        }

        public RelayCommand SaveTasksToFileCommand { get; set; }
        public RelayCommand LoadTasksFromFileCommand { get; set; }
        public RelayCommand AddTaskCommand { get; set; }
        public RelayCommand ToggleTaskCompletionCommand { get; set; }

        // **********************************************************
        // Сохранение в файл
        //***********************************************************

        public void SaveToFileCommandExecute(object? parameter)
        {
            string filePath = "C:\\Academy\\tasks.txt";
            var taskModels = new List<TaskModel>();

            foreach (var task in Tasks)
            {
                taskModels.Add(new TaskModel
                {
                    Name = task.Name,
                    IsComplete = task.IsCompleted
                });
            }

            new TaskManager().Write(taskModels);
        }


        // **********************************************************
        // Загрузка из файла
        //***********************************************************
        public void LoadFromFileCommandExecute(object? parameter)
        {
            string filePath = "C:\\Academy\\tasks.txt";
            var taskModels = new TaskManager().Read();

            Tasks.Clear();
            foreach (var taskModel in taskModels)
            {
                Tasks.Add(new TaskViewModel
                {
                    Name = taskModel.Name,
                    IsCompleted = taskModel.IsComplete
                });
            }
        }


        

        // **********************************************************
        // Добавление task'ов
        //***********************************************************
        public ToDoViewModel()
    {
                       

            Tasks = new ObservableCollection<TaskViewModel>
        {
            new() 
            { 
                Name = "Сделать ДЗ по WPF",
                IsCompleted = false 
            },
            new()
            { 
                Name = "Пройти курс по С#",
                IsCompleted = true 
            }
        };

        AddTaskCommand = new(AddTask);
        ToggleTaskCompletionCommand = new(ToggleTaskCompletion);
            SaveTasksToFileCommand = new(SaveToFileCommandExecute);
            LoadTasksFromFileCommand = new(LoadFromFileCommandExecute);
        
    }

        public void ToggleTaskCompletion(object? parameter)
        {
            if (parameter is TaskViewModel taskViewModel)
            {
                taskViewModel.IsCompleted = !taskViewModel.IsCompleted;
            }
        }
        
        public void AddTask(object? parameter)
        {
            var taskViewModel = new TaskViewModel
            {
                Name = TextTask,
                IsCompleted = false,
            };
            TextTask = string.Empty;
            Tasks.Add(taskViewModel);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
