using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace EFProjectManager;

public class BloggingContext : DbContext
{
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Todo> Todos { get; set; }

    public string DbPath { get; }

    public BloggingContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "blogging.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}
