using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CommunicationWebApi.Models;

namespace CommunicationWebApi.Data
{
    public class CommunicationDbContext : DbContext
    {
        public CommunicationDbContext(DbContextOptions<CommunicationDbContext> options)
            : base(options)
        { }

        //public DbSet<Message> Message { get; set; } = default!;
        public DbSet<Message> Messages => Set<Message>();
    }
}
