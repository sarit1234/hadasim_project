using Hadasim_2_part_1.Model;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models;

public class TodoContextNegative : DbContext
{
    public TodoContextNegative(DbContextOptions<TodoContextNegative> options)
    : base(options)
    {
    }

    public DbSet<Negative> TodoItems { get; set; } = null!;
}
