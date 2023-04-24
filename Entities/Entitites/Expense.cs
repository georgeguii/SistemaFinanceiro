using Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entitites;

public class Expense : Base
{
    public decimal Value { get; set; }

    public int Mouth { get; set; }

    public int Year { get; set; }

    public ExpenseType ExpenseType { get; set; }

    public DateTime SignUpDate { get; set; }

    public DateTime UpdateDate { get; set; }

    public DateTime PaymentDate { get; set; }

    public DateTime DueDate { get; set; }

    public bool Paid { get; set; }

    public bool LateExpense { get; set; }

    [ForeignKey("Category")]
    [Column(Order = 1)]
    public int CategoryId { get; set; }
    public virtual Category? Category { get; set; }
}
