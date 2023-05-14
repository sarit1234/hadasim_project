using Hadasim_2_part_1.Model;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models;

public class TodoContextVaccination : DbContext
{
    public TodoContextVaccination(DbContextOptions<TodoContextVaccination> options)
    : base(options)
    {
    }

    public DbSet<Vaccination> TodoItems { get; set; } = null!;
}
