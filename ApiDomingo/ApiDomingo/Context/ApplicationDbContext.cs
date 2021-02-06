using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDomingo.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiDomingo.Context
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
