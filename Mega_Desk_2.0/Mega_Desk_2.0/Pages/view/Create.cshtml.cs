using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mega_Desk_2._0.Data;
using Mega_Desk_2._0.Models;

namespace Mega_Desk_2._0.Pages.view
{
    public class CreateModel : PageModel
    {
        private readonly Mega_Desk_2._0.Data.Mega_Desk_2_0Context _context;

        public CreateModel(Mega_Desk_2._0.Data.Mega_Desk_2_0Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MegaDesk MegaDesk { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.MegaDesk == null || MegaDesk == null)
            {
                return Page();
            }
            MegaDesk.Cost = MegaDesk.CalculateCost();
            MegaDesk.Date = DateTime.Now;
            _context.MegaDesk.Add(MegaDesk);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public async void OnChangeSurfaceMaterial(object sender, EventArgs e)
        { 
            Console.WriteLine(MegaDesk.SurfaceMaterial);
        }
    }
}
