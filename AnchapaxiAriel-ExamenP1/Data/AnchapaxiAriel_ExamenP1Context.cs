using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AnchapaxiAriel_ExamenP1.Models;

namespace AnchapaxiAriel_ExamenP1.Data
{
    public class AnchapaxiAriel_ExamenP1Context : DbContext
    {
        public AnchapaxiAriel_ExamenP1Context (DbContextOptions<AnchapaxiAriel_ExamenP1Context> options)
            : base(options)
        {
        }

        public DbSet<AnchapaxiAriel_ExamenP1.Models.AnchapaxiModel> AnchapaxiModel { get; set; } = default!;
        public DbSet<AnchapaxiAriel_ExamenP1.Models.PhoneModel> PhoneModel { get; set; } = default!;
    }
}
