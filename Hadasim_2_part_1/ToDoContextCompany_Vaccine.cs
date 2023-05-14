using Hadasim_2_part_1.Model;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models;

public class TodoContextCompany_Vaccine : DbContext
{
    public TodoContextCompany_Vaccine(DbContextOptions<TodoContextCompany_Vaccine> options)
    : base(options)
    {
    }

    public DbSet<Company_Vaccine> TodoItems { get; set; } = null!;
}