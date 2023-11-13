namespace Endava.TechCourse.BankApp.Shared;

public class GetWalletDTO
{
    public Guid WalletId { get; set; }
    public decimal Amount { get; set; }
    public string CurrencyCode { get; set; }
    public decimal ChangeRate { get; set; }
    public string CurrencyName { get; set; }
    public int Pincode { get; set; }
    public string Type { get; set; }
    public DateTime LastActivity { get; set; }
    public Guid CurrencyId { get; set; }
}