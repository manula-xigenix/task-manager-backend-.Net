namespace TaskManagementApp_Test.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TaskManagementApp_Test.Models;



public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<TaskItem> Tasks => Set<TaskItem>();
    public DbSet<User> Users => Set<User>(); 
}

