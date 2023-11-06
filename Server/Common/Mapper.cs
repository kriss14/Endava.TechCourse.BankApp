using Endava.TechCourse.BankApp.Domain.Models;
using Endava.TechCourse.BankApp.Shared;

namespace Endava.TechCourse.BankApp.Server.Common
{
    public static class Mapper
    {
        public static IEnumerable<WalletDto> Map(IEnumerable<Wallet> wallets)
        {
            var dtos = new List<WalletDto>();

            foreach (var wallet in wallets)
            {
                var dto = new WalletDto()
                {
                    Id = wallet.Id.ToString(),
                    Type = wallet.Type,
                    Currency = wallet.Currency.Name,
                    ChangeRate = wallet.Currency.ChangeRate,
                    Amount = wallet.Amount
                };

                dtos.Add(dto);
            }

            return dtos;
        }
    }
}
