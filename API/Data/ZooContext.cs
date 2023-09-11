using System;
using API.Model.Entities;
using Microsoft.EntityFrameworkCore;

public class ZooContext : DbContext
{
	public ZooContext(DbContextOptions options) : base(options)
	{
    }

	public DbSet<Animal> Animals { get; set; }
}
