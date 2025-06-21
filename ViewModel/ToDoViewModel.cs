

using System.Collections.ObjectModel;
using System.ComponentModel;

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

    public RelayCommand AddTaskCommand { get; set; }
    public RelayCommand ToggleTaskCompletionCommand { get; set; }

    public ToDoViewModel()
    {
        Tasks = new ObservableCollection<TaskViewModel>
        {
            new() 
            { 
                Name = "Сделать ЛЗ по WPF",
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
    }

        public void ToggleTaskCompletion(object? parameter)
        {
            if (parameter is TaskViewModel taskViewModel)
            {
                taskViewModel.IsCompleted = !taskViewModel.IsCompleted;
            }
        }
        //public void ChangeIsComplite (TaskViewModel taskViewModel)
        //{
        //    taskViewModel.IsComplete = !taskViewModel.IsComplete;
        //}

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
