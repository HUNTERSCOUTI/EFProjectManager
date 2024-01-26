using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EFProjectManager;

public class Program
{
    static void Main(string[] args)
    {
        //seedTasks();

        using var db = new BloggingContext();

        var tasks = db.Tasks
            .Include(t => t.Todos)
            .ToList();

        foreach (var task in tasks)
        {
            Console.WriteLine($"Task: {task.Name}");
            foreach (var todo in task.Todos)
            {
                Console.WriteLine($"  Todo: {todo.Name}, Completed: {todo.IsCompleted}");
            }
        }

        printIncompleteTasksAndTodos();
    }

    static void seedTasks()
    {
        using var db = new BloggingContext();

        var tasks = new List<Task>
        {
            new()
            {
                TaskID = 1,
                Name = "Produce software",
                Todos = new List<Todo>
                {
                    new(1, "Write Code", true ),
                    new(2, "Compile source", true ),
                    new(3, "Test program", true )
                }
            },
            new()
            {
                TaskID = 2,
                Name = "Brew Coffee",
                Todos = new List<Todo>
                {
                    new(4, "Pour water", false ),
                    new(5, "Pour coffee", false ),
                    new(6, "Turn on", false )
                }
            }
        };

        db.Tasks.AddRange(tasks);
        db.SaveChanges();
    }

    static void printIncompleteTasksAndTodos()
    {
        using var db = new BloggingContext();

        var incompleteTasks = db.Tasks
                .Include(task => task.Todos)
                .Where(task => task.Todos.Any(todo => !todo.IsCompleted))
                .ToList();

        Console.WriteLine("\n\nIncompleted Tasks And Todos:");
        foreach (var task in incompleteTasks)
        {
            Console.WriteLine($"Task: {task.Name}");
            foreach (var todo in task.Todos.Where(todo => !todo.IsCompleted))
            {
                Console.WriteLine($" Todo: {todo.Name}");
            }
        }
    }
}

