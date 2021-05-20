using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TuneEsportIFv2.Areas.Identity.Data;
using TuneEsportIFv2.Models;

namespace TuneEsportIFv2.Data
{
    public class ApplicationDbContext : IdentityDbContext<TuneEsportIfv2User>
    {
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public virtual DbSet<Info> Infos { get; set; }

        public virtual DbSet<Game> Games { get; set; }

        public virtual DbSet<Map> Maps { get; set; }

        public virtual DbSet<ScoreBoard> ScoreBoards { get; set; }

        public virtual DbSet<TuneEsportIfv2User> TuneEsportIfv2Users { get; set; }

    }
}
