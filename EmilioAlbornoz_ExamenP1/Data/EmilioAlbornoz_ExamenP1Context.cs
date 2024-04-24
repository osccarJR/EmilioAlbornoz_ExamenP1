using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmilioAlbornoz_ExamenP1.Models;

namespace EmilioAlbornoz_ExamenP1.Data
{
    public class EmilioAlbornoz_ExamenP1Context : DbContext
    {
        public EmilioAlbornoz_ExamenP1Context (DbContextOptions<EmilioAlbornoz_ExamenP1Context> options)
            : base(options)
        {
        }

        public DbSet<EmilioAlbornoz_ExamenP1.Models.EAPollo> EAPollo { get; set; } = default!;
    }
}
