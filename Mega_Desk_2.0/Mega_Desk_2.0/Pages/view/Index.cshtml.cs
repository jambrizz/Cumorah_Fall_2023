using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mega_Desk_2._0.Data;
using Mega_Desk_2._0.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Drawing;

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

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; } = default!;
        public string? firstName { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString2 { get; set; } = default!;
        public string? lastName { get; set; } = default!;

        public SelectList? Dates { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? sortMethod { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var megadesk = from m in _context.MegaDesk
                           select m;


            
            if (_context.MegaDesk != null)
            {
                MegaDesk = await _context.MegaDesk.ToListAsync();
            }
            if (!string.IsNullOrEmpty(SearchString) || !string.IsNullOrEmpty(SearchString2))
            {
                megadesk = megadesk.Where(s => s.firstName.Contains(SearchString) || s.lastName.Contains(SearchString2));              
            }
            if (!string.IsNullOrEmpty(SearchString) && !string.IsNullOrEmpty(SearchString2))
            { 
                megadesk = megadesk.Where(s => s.firstName.Contains(SearchString) && s.lastName.Contains(SearchString2));                
            }
            if(sortMethod == "date" || sortMethod == null)
            {
                megadesk = megadesk.OrderByDescending(s => s.Date);
            }
            else
            {
                megadesk = megadesk.OrderBy(s => s.lastName).ThenBy(s => s.firstName).ThenByDescending(s => s.Date);
            }
            
            MegaDesk = await megadesk.ToListAsync();
        }

    }
}
