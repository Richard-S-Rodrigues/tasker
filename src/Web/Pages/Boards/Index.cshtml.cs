using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tasker.Domain.BoardAggregate.Commands;
using Tasker.Domain.BoardAggregate.Queries;
using Tasker.Web.Pages.Shared.ViewModels;
using Tasker.Web.Pages.Boards.ViewModels;
using Tasker.Domain.BoardAggregate.ValueObjects;
using Tasker.Domain.BoardAggregate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Tasker.Web.Pages.Boards;

[Authorize]
[IgnoreAntiforgeryToken]
public class Index : PageModel
{
    private readonly ISender _sender;
    private IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<IdentityUser> _userManager;

    public Index(ISender sender, IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager)
    {   
        _sender = sender;
        _httpContextAccessor = httpContextAccessor;
        _userManager = userManager;
    }

    public ErrorViewModel Error { get; private set; } = new();

    public List<BoardViewModel> BoardList { get; private set; } = new();

    public async Task OnGetAsync()
    {
        await GetBoards();
    }

    public async Task GetBoards()
    {
        var boards = await _sender.Send(new GetAllBoardsQuery());
        BoardList = boards.Select(board => BoardViewModel.ToViewModel(board)).ToList();
    }

    public async Task<IActionResult> OnGetSearchBoards(string? searchQuery)
    {
        await GetBoards();

        if (!string.IsNullOrEmpty(searchQuery))
        {
            BoardList = BoardList.Where(b => b.Name.StartsWith(searchQuery)).ToList();   
        }

        return Partial("_Result", this);
    }

    public async Task<IActionResult> OnPostSaveBoard(Guid? id, string name)
    {
        try 
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            if (id.HasValue)
            {
                var updateCommand = new UpdateBoardCommand(new BoardId(id.Value), name, new List<Member>());
                await _sender.Send(updateCommand);
            }
            else 
            {
                var createCommand = new CreateBoardCommand(name, Guid.Parse(user.Id), user.UserName);
                await _sender.Send(createCommand);
            }

            await GetBoards();

            return RedirectToPage("Index");
        }
        catch(Exception e)
        {
            Error.HasError = true;
            Error.ErrorMessage = e.Message;
            return Page();
        }   
    }

    public async Task<IActionResult> OnPostDeleteBoard(Guid id)
    {
        try 
        {
            var command = new DeleteBoardCommand(new BoardId(id));

            await _sender.Send(command);

            await GetBoards();

            return RedirectToPage("Index");
        }
        catch (Exception e)
        {
            Error.HasError = true;
            Error.ErrorMessage = e.Message;
            return Page();
        }
    }
}
