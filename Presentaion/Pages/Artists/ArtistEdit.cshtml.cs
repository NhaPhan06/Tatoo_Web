using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using DataAccess.DataAccess;
using BusinessLogic.IService;
using BusinessLogic.Service;

namespace Presentaion.Pages.Artists
{
    public class ArtistEditModel : PageModel
    {
        private readonly IArtistService _artistService;

        public ArtistEditModel(IArtistService artistService)
        {
            _artistService = artistService;
        }

        [BindProperty]
        public Artist Artist { get; set; } = default;

        public IActionResult OnGet(Guid id)
        {

            Artist = _artistService.GetArtistById(id);
            return Page();
        }

        public IActionResult OnPost()
        {

            try
            {
                _artistService.UdpateArtist(Artist.Id, Artist);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return Page();
        }
    }
}
