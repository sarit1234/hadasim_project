using System.Collections.Generic;
using Hadasim_2_part_1.Model;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models;

public class TodoContextPatient : DbContext
{
    public TodoContextPatient(DbContextOptions<TodoContextPatient> options)
    : base(options)
    {
    }

    public DbSet<Patient> TodoItems { get; set; } = null!;
}