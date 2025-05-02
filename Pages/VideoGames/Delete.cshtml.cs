using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Pages.VideoGames
{
    public class DeleteModel : PageModel
    {
        private readonly FinalProject.Data.FinalProjectContext _context;

        public DeleteModel(FinalProject.Data.FinalProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public VideoGame VideoGame { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videogame = await _context.VideoGame.FirstOrDefaultAsync(m => m.Id == id);

            if (videogame is not null)
            {
                VideoGame = videogame;

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

            var videogame = await _context.VideoGame.FindAsync(id);
            if (videogame != null)
            {
                VideoGame = videogame;
                _context.VideoGame.Remove(VideoGame);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
