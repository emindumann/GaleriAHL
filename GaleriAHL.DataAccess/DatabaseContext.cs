﻿using GaleriAHL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GaleriAHL.DataAccess
{
    public class DatabaseContext : DbContext //DbContext sınıfından miras alındı.
    {
        public DbSet<Arac> Araclar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Marka> Markalar { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<Satis> Satislar { get; set; }
        public DbSet<Servis> Servisler { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=EMIN;Initial Catalog=DbGaleriAHL;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API
            modelBuilder.Entity<Marka>().Property(m => m.Ad).IsRequired().HasColumnType("varchar(50)");
            modelBuilder.Entity<Rol>().Property(m=>m.Ad).IsRequired().HasColumnType("varchar(50)");
            modelBuilder.Entity<Rol>().HasData(new Rol
            {
                Id = 1,
                Ad ="Admin"
            });
            modelBuilder.Entity<Kullanici>().HasData(new Kullanici
            {
                Id = 1,
                Ad ="Admin",
                AktifMi = true,
                EklenmeTarihi = DateTime.Now,
                Email="admin@galeriahl.com",
                KullaniciAdi="admin",
                Sifre = "123456",
                //Rol = new Rol { Id = 1},
                RolId = 1,
                Soyad = "admin",
                Telefon="0536",

            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
