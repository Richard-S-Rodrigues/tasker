using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tasker.Domain.BoardAggregate.Commands;

namespace Web.Pages;

public class IndexModel : PageModel
{
    private readonly ISender _sender;
    public IndexModel(ISender sender)
    {   
        _sender = sender;
    }

    public void OnGet()
    {

    }

    public async Task<IActionResult> OnPostCreateBoard()
    {
        var name = "test";
        var command = new CreateBoardCommand(name);
        var result = await _sender.Send(command);
        
        return result.IsError ? 
            BadRequest() 
            : Partial("Boards_list", result.Value);
    }
}
