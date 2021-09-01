using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesCG.Data;
using RazorPagesCG.Models;

namespace RazorPagesCG.Pages.Characters
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesCG.Data.RazorPagesCGContext _context;

        public DetailsModel(RazorPagesCG.Data.RazorPagesCGContext context)
        {
            _context = context;
        }

        public Character Character { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Character = await _context.Character.FirstOrDefaultAsync(m => m.ID == id);

            if (Character == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
