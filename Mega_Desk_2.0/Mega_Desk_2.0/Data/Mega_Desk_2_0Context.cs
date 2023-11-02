using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mega_Desk_2._0.Models;

namespace Mega_Desk_2._0.Data
{
    public class Mega_Desk_2_0Context : DbContext
    {
        public Mega_Desk_2_0Context (DbContextOptions<Mega_Desk_2_0Context> options)
            : base(options)
        {
        }

        public DbSet<Mega_Desk_2._0.Models.MegaDesk> MegaDesk { get; set; } = default!;
    }
}
