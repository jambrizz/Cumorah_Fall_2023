using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mega_Desk_2._0.Data;
using Mega_Desk_2._0.Models;

namespace Mega_Desk_2._0.Pages.view
{
    public class EditModel : PageModel
    {
        private readonly Mega_Desk_2._0.Data.Mega_Desk_2_0Context _context;

        public EditModel(Mega_Desk_2._0.Data.Mega_Desk_2_0Context context)
        {
            _context = context;
        }

        [BindProperty]
        public MegaDesk MegaDesk { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MegaDesk == null)
            {
                return NotFound();
            }

            var megadesk =  await _context.MegaDesk.FirstOrDefaultAsync(m => m.ID == id);
            if (megadesk == null)
            {
                return NotFound();
            }
            MegaDesk = megadesk;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MegaDesk).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MegaDeskExists(MegaDesk.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MegaDeskExists(int id)
        {
          return (_context.MegaDesk?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
