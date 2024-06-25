
using Tasker.Domain.BoardAggregate.ValueObjects;
using Tasker.Domain.TaskAggregate;
using Tasker.Domain.TaskAggregate.Queries;
using Tasker.Domain.TaskAggregate.ValueObjects;

namespace Tasker.Web.Pages.Tasks.ViewModels;

public class CommentViewModel 
{
  public Guid? Id { get; set; }
  public Guid TaskId { get; set; }
  public string Text { get; set; }
  public MemberViewModel Member { get; set; }
  public DateTime Date { get; set; }

  public static CommentViewModel ToViewModel(CommentDTO comment)
  {
    return new()
    {
      Id = comment.Id!.Value,
      TaskId = comment.TaskId,
      Text = comment.Text,
      Member = new MemberViewModel { Id = comment.MemberId, Name = comment.MemberName },
      Date = comment.Date
    };
  }

  public static IEnumerable<CommentViewModel> ToEnumerableViewModel(IEnumerable<CommentDTO> comments)
  {
    return comments.Select(comment => ToViewModel(comment));
  }

  public static Comment ToEntity(CommentViewModel comment)
  {
    if (!comment.Id.HasValue)
    {
      return Comment.Create(
        comment.Text,
        new MemberId(comment.Member.Id),
        new TaskId(comment.TaskId)
      );
    }
    
    return new Comment(
      new CommentId(comment.Id.Value),
      comment.Text,
      new MemberId(comment.Member.Id),
      new TaskId(comment.TaskId)
    );
  }

  public static IEnumerable<Comment> ToEnumerableEntity(IEnumerable<CommentViewModel> comments)
  {
    return comments.Select(comment => ToEntity(comment));
  }
}