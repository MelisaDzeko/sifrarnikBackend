using Microsoft.EntityFrameworkCore;
using optomŠifrarnik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace optomŠifrarnik.Context
{
    public class MojContext : DbContext
    {
        public MojContext(DbContextOptions<MojContext> options) : base(options) { }

        public DbSet<Sifrarnik> Sifrarnik { get; set; }
        public DbSet<StavkaSifrarnika> StavkaSifrarnika { get; set; }
        public DbSet<PodstavkaSifrarnika> PodstavkaSifrarnika { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Sifrarnik>().HasData(
                new Sifrarnik
                {
                    SifrarnikId = 1,
                    Oznaka = "IZVRSENJE_PROBLEMI",
                    Naziv = "Problemi tokom izvršavanja",
                    Opis = "Da li je prilikom izvršavanja...",
                    Programerski = false,
                    Kesiranje = false,
                    DatumKreiranja = DateTime.Now
                },
                  new Sifrarnik
                  {
                      SifrarnikId = 2,
                      Oznaka = "Kvalifikacija-ZALBE",
                      Naziv = "Kvalifikacija zalbi",
                      Opis = "Stablo za klasificiranje...",
                      Programerski = true,
                      Kesiranje = true,
                      DatumKreiranja = DateTime.Now
                  }
                );

            modelBuilder.Entity<StavkaSifrarnika>().HasData(
                  new StavkaSifrarnika
                  {
                      StavkaSifrarnikaId = 1,
                      Oznaka = "VODA",
                      Naziv = "Sa vodom i otpadnim vodama",
                      Preduzece = "KJKP Vodovod i kanali",
                      RedniBroj = 0,
                      DatumKreiranja = DateTime.Now,
                      SifrarnikId = 2
                  },
                    new StavkaSifrarnika
                    {
                        StavkaSifrarnikaId = 2,
                        Oznaka = "PARKING",
                        Naziv = "Sa parkingom",
                        Preduzece = "RAD",
                        RedniBroj = 1,
                        DatumKreiranja = DateTime.Now,
                        SifrarnikId = 2
                    },
                       new StavkaSifrarnika
                       {
                           StavkaSifrarnikaId = 3,
                           Oznaka = "VODA",
                           Naziv = "Sa vodom i otpadnim vodama",
                           Preduzece = "KJKP Vodovod i kanali",
                           RedniBroj = 0,
                           DatumKreiranja = DateTime.Now,
                           SifrarnikId = 1
                       }
                );
            modelBuilder.Entity<PodstavkaSifrarnika>().HasData(
                  new PodstavkaSifrarnika
                  {
                      PodstavkaSifrarnikaId = 1,
                      Oznaka = "NEPRAVILNO_PARKIRANJE",
                      Naziv = "Vozilo parkirano na nepropisno mjesto...",
                      Preduzece = "RAD",
                      RedniBroj = 0,
                      DatumKreiranja = DateTime.Now,
                      StavkaSifrarnikaId = 2
                  },
                      //samo za provjeru SS1, vratiti SS2
                      new PodstavkaSifrarnika
                      {
                          PodstavkaSifrarnikaId = 2,
                          Oznaka = "PAUK_ZA_ODVOZ_VOZILA",
                          Naziv = "Potreban pauz za odvoz vozila",
                          Preduzece = "RAD",
                          RedniBroj = 0,
                          DatumKreiranja = DateTime.Now,
                          StavkaSifrarnikaId = 1
                      },
                          new PodstavkaSifrarnika
                          {
                              PodstavkaSifrarnikaId = 3,
                              Oznaka = "PAUK_ZA_ODVOZ_VOZILA_1",
                              Naziv = "Potreban pauz za odvoz vozila",
                              Preduzece = "RAD",
                              RedniBroj = 0,
                              DatumKreiranja = DateTime.Now,
                              StavkaSifrarnikaId = 1
                          }

                );
        }




    }
}
