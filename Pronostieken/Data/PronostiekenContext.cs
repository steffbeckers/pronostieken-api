using Microsoft.EntityFrameworkCore;
using Pronostieken.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pronostieken.Data
{
  public class PronostiekenContext : DbContext
  {
    public DbSet<Match> Matches { get; set; }
    public DbSet<Player> Players { get; set; }

        public PronostiekenContext(DbContextOptions<PronostiekenContext> options)
        : base(options)
    {}
  }
}
