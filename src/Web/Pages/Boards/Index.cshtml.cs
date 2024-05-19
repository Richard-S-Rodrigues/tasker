using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tasker.Domain.BoardAggregate.Commands;
using Tasker.Domain.BoardAggregate.Queries;
using Htmx;
using Tasker.Web.Pages.Shared.ViewModels;
using Tasker.Web.Pages.Boards.ViewModels;
using Tasker.Domain.BoardAggregate.ValueObjects;
using Tasker.Domain.BoardAggregate;

namespace Tasker.Web.Pages.Boards;

[IgnoreAntiforgeryToken]
public class Index : PageModel
{
    private readonly ISender _sender;
    public Index(ISender sender)
    {   
        _sender = sender;
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

    public async Task<IActionResult> OnGetSaveBoardModal(Guid? id)
    {
        var board = new BoardViewModel();

        if (id.HasValue)
        {
            await GetBoards();
            board = BoardList.FirstOrDefault(b => b.Id == id.Value);
        }
        
        return Partial("_SaveBoardModal", board);
    }

    public async Task<IActionResult> OnGetDeleteBoardModal(Guid id)
    {
        await GetBoards();
        
        var board = BoardList.FirstOrDefault(b => b.Id == id);
        
        return Partial("_DeleteBoardModal", board);
    }

    public async Task<IActionResult> OnPostSaveBoard(Guid? id, string name)
    {
        try 
        {
            if (id.HasValue)
            {
                var updateCommand = new UpdateBoardCommand(new BoardId(id.Value), name, new List<Member>());
                await _sender.Send(updateCommand);
            }
            else 
            {
                var createCommand = new CreateBoardCommand(name);
                await _sender.Send(createCommand);
            }

            await GetBoards();

            if (HttpContext.Request.IsHtmx())
            {
                return Partial("_Result", this);
            }
    
            return Page();
        }
        catch(Exception e)
        {
            Error.HasError = true;
            Error.ErrorMessage = e.Message;
            return Partial("_Result", this);
        }   
    }

    public async Task<IActionResult> OnDeleteBoard(Guid id)
    {
        try 
        {
            var command = new DeleteBoardCommand(new BoardId(id));

            await _sender.Send(command);

            await GetBoards();

            if (HttpContext.Request.IsHtmx())
            {
                return Partial("_Result", this);
            }
    
            return Page();
        }
        catch (Exception e)
        {
            Error.HasError = true;
            Error.ErrorMessage = e.Message;
            return Partial("_Result", this);
        }
    }
}
