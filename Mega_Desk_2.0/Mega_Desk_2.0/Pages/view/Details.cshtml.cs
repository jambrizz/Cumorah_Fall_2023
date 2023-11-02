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
    public class DetailsModel : PageModel
    {
        private readonly Mega_Desk_2._0.Data.Mega_Desk_2_0Context _context;

        public DetailsModel(Mega_Desk_2._0.Data.Mega_Desk_2_0Context context)
        {
            _context = context;
        }

      public MegaDesk MegaDesk { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MegaDesk == null)
            {
                return NotFound();
            }

            var megadesk = await _context.MegaDesk.FirstOrDefaultAsync(m => m.ID == id);
            if (megadesk == null)
            {
                return NotFound();
            }
            else 
            {
                MegaDesk = megadesk;
            }
            return Page();
        }
    }
}
