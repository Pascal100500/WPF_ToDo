using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TaskModel
    {
        public required string Name { get; set; }
        public bool IsComplete { get; set; }

        public override string ToString()
        {
            return $"Название: {Name}, Статус: {(IsComplete ? "Выполнено" : "Не выполнено")}";
        }

        public string GetStatus()
        {
            return IsComplete ? "Выполнено" : "Не выполнено";
        }
    }

}
