using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Pages.Platforms
{
    public class DeleteModel : PageModel
    {
        private readonly FinalProject.Data.FinalProjectContext _context;

        public DeleteModel(FinalProject.Data.FinalProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Platform Platform { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var platform = await _context.Platform.FirstOrDefaultAsync(m => m.Id == id);

            if (platform is not null)
            {
                Platform = platform;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var platform = await _context.Platform.FindAsync(id);
            if (platform != null)
            {
                Platform = platform;
                _context.Platform.Remove(Platform);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
