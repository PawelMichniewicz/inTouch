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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .Navigation(m => m.Sender)
                .AutoInclude();

            modelBuilder.Entity<Message>()
                .Navigation(m => m.ChatRoom)
                .AutoInclude();

            modelBuilder.Entity<User>()
                .Navigation(m => m.ChatRooms)
                .AutoInclude();
        }

        public DbSet<User> Users => Set<User>();
        
        public DbSet<Message> Messages => Set<Message>();
        
        public DbSet<ChatRoom> ChatRooms => Set<ChatRoom>();

    }
}
