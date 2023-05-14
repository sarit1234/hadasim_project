using Hadasim_2_part_1.Model;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models;

public class TodoContextPositive: DbContext
{
    public TodoContextPositive(DbContextOptions<TodoContextPositive> options)
    : base(options)
    {
    }

    public DbSet<Positive> TodoItems { get; set; } = null!;
}
