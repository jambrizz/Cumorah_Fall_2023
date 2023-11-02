using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mega_Desk_2._0.Data;
using Mega_Desk_2._0.Models;

namespace Mega_Desk_2._0.Pages.view
{
    public class IndexModel : PageModel
    {
        private readonly Mega_Desk_2._0.Data.Mega_Desk_2_0Context _context;

        public IndexModel(Mega_Desk_2._0.Data.Mega_Desk_2_0Context context)
        {
            _context = context;
        }

        public IList<MegaDesk> MegaDesk { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.MegaDesk != null)
            {
                MegaDesk = await _context.MegaDesk.ToListAsync();
            }
        }
    }
}
