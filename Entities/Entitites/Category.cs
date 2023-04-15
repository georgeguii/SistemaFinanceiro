using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entitites;

public class Category : Base
{
    [ForeignKey("FinancialSystem")]
    [Column(Order = 1)]
    public int SystemId { get; set; }
    public virtual FinancialSystem FinancialSystem { get; set; }
}
