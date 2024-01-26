using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFProjectManager;

public class Task
{
    public int TaskID { get; set; }

    public string Name { get; set; }

    public List<Todo> Todos { get; set; }
}
