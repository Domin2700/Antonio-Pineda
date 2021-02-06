using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domingo_Ant._Pineda.Models;
using Microsoft.EntityFrameworkCore;

namespace Domingo_Ant._Pineda.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        :base(options)
        { 
        
        }

        //tables
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Departamento> Departamento { get; set; }

    }
}
