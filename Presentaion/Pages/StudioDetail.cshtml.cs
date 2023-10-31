using BusinessLogic.IService;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages;

public class StudioDetail : PageModel
{
    private readonly IStudioService _studioService;

    public StudioDetail(IStudioService studioService)
    {
        _studioService = studioService;
    }

    public Studio studio { get; set; } = default!;


    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        studio = _studioService.GetById(id);
        return Page();
    }
}