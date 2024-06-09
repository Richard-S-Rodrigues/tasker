using Tasker.Domain.TaskAggregate.Enums;

namespace Tasker.Web.Helpers;

public static class EnumHelper 
{
  public static string GetEnumStatusLabel(Status value)
  {
    return value switch
    {
      Status.InRefinement => "Em refinamento",
      Status.Ready => "Pronto",
      Status.OnProgress => "Em progresso",
      Status.Interrupted => "Interrompido",
      Status.Canceled => "Cancelado",
      Status.Done => "Concluído",
      _ => value.ToString()
    };
  }

  public static string GetEnumPriorityLabel(Priority value)
  {
    return value switch
    {
      Priority.Low => "Baixa",
      Priority.Medium => "Média",
      Priority.High => "Alta",
      Priority.Urgent => "Urgente",
      _ => value.ToString()
    };
  }
}