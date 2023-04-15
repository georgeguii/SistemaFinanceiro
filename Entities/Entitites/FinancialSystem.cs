namespace Entities.Entitites;

public class FinancialSystem : Base
{
    public int Mouth { get; set; }

    public int Year { get; set; }

    public int ClosingDate { get; set; }

    public bool GenerateExpenseCopy { get; set; }

    public int CopyMouth { get; set; }

    public int CopyYear { get; set; }
}
