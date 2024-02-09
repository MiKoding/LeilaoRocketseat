﻿using leilaoRocketseatAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace leilaoRocketseatAPI.Repositories
{
    public class RocketseatAuctionDbContext : DbContext
    {
        public DbSet<Auction> Auctions { get; set; }    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\\Users\\Mikaio Yamada\\source\\repos\\LeilaoRocketseat\\DB\\leilaoDbNLW.db");
        }
    }
}
