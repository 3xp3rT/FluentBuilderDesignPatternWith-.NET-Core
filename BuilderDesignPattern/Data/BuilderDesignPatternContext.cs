using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BuilderDesignPattern.Models;

namespace BuilderDesignPattern.Data
{
    public class BuilderDesignPatternContext : DbContext
    {
        public BuilderDesignPatternContext (DbContextOptions<BuilderDesignPatternContext> options)
            : base(options)
        {
        }

        public DbSet<BuilderDesignPattern.Models.Employee> Employee { get; set; }
    }
}
