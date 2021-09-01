using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesCG.Data;
using RazorPagesCG.Models;

namespace RazorPagesCG.Pages.Characters
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesCG.Data.RazorPagesCGContext _context;

        public IndexModel(RazorPagesCG.Data.RazorPagesCGContext context)
        {
            _context = context;
        }

        public IList<Character> Character { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Professions { get; set; }
        [BindProperty(SupportsGet = true)]
        public string CharacterProfession { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> professionQuery = from c in _context.Character
                                                 orderby c.Profession
                                                 select c.Profession;
            
            var characters = from c in _context.Character
                             select c;
            
            if (!string.IsNullOrEmpty(SearchString))
            {
                characters = characters.Where(s => s.Name.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(CharacterProfession))
            {
                characters = characters.Where(x => x.Profession == CharacterProfession);
            }

            Professions = new SelectList(await professionQuery.Distinct().ToListAsync());
            Character = await characters.ToListAsync();
        }
    }
}
