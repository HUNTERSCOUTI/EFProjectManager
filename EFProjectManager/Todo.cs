using System;
using Microsoft.EntityFrameworkCore;

public class Todo
{
    public int TodoID { get; set; }

    public string Name { get; set; }

    public bool IsCompleted { get; set; }

    public Todo(int todoID, string name, bool isCompleted)
    {
        TodoID = todoID;
        Name = name;
        IsCompleted = isCompleted;
    }
}