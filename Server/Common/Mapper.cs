using Endava.TechCourse.BankApp.Domain.Models;
using Endava.TechCourse.BankApp.Shared;

namespace Endava.TechCourse.BankApp.Server.Common
{
    public static class Mapper
    {
        public static IEnumerable<CurrencyDto> Map(IEnumerable<Currency> currencies)
        {
            var dtos = new List<CurrencyDto>();

            foreach (var currency in currencies)
            {
                var dto = new CurrencyDto()
                {
                    Id = currency.Id.ToString(),
                    Name = currency.Name,
                    CurrencyCode = currency.CurrencyCode,
                    ChangeRate = currency.ChangeRate,
                    CanBeRemoved = currency.CanBeRemoved
                };

                dtos.Add(dto);
            }

            return dtos;
        }

        public static IEnumerable<WalletDto> Map(IEnumerable<Wallet> wallets)
        {
            var dtos = new List<WalletDto>();

            foreach (var wallet in wallets)
            {
                var dto = new WalletDto()
                {
                    Id = wallet.Id.ToString(),
                    Type = wallet.Type,
                    Currency = wallet.Currency,
                    ChangeRate = wallet.ChangeRate,
                    Amount = wallet.Amount
                };

                dtos.Add(dto);
            }

            return dtos;
        }

        public static IEnumerable<TransactionDto> Map(IEnumerable<Transaction> transactions)
        {
            var dtos = new List<TransactionDto>();

            foreach (var transaction in transactions)
            {
                var dto = new TransactionDto()
                {
                    SourceWalletId = transaction.SourceWalletId.ToString(),
                    DestinationWalletId = transaction.DestinationWalletId.ToString(),
                    Amount = transaction.Amount,
                    Currency = transaction.Currency,
                    TransactionTime = transaction.TransactionTime
                };

                dtos.Add(dto);
            }

            return dtos;
        }
    }
}