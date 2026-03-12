using EstudiantesAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EstudiantesAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Estudiante> Estudiantes { get; set; }
    }
}