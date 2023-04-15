using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entitites;

public class UserFinancialSystem
{
    public int Id { get; set; }
    public string UserEmail { get; set; }
    public bool isAdmin { get; set; }
    public bool CurrentSystem { get; set; }

    [ForeignKey("FinancialSystem")]
    [Column(Order = 1)]
    public int SystemId { get; set; }
    public virtual FinancialSystem FinancialSystem { get; set; }
}
