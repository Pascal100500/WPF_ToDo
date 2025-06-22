using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    public class TaskManager
    {
        private readonly string _filePath = "C:\\Academy\\tasks.txt";

        public void Write(List<TaskModel> tasks)
        {
            //Сериализовать
            //Сохранить в файл
            foreach (var task in tasks)
            {
                string line = $"{task.Name};{task.IsComplete}";
                File.AppendAllText(_filePath, line + "\n");
            }
        }

        public List<TaskModel> Read()
        {
            //Десериализация
            //Чтение из файла

            var tasks = new List<TaskModel>();

            if (!File.Exists(_filePath))
                return tasks;

            var content = File.ReadAllText(_filePath);
            var lines = content.Split('\n');

            foreach (var line in lines)
            {
                var parts = line.Split(';');
                if (parts.Length == 2)
                {
                    tasks.Add(new TaskModel
                    {
                        Name = parts[0],
                        IsComplete = bool.TryParse(parts[1], out var result) && result
                    });
                }
            }

            return tasks;

        }
     }
   
}
