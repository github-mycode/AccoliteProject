using AccoliteBank.Dtos.Request.Transaction;
using AccoliteBank.Models.Transactions;
using AutoMapper;

namespace AccoliteBank.Mapper.Transactions
{
    public class TransactionMapper: Profile
    {
        public TransactionMapper()
        {
            CreateMap<TransactionDto, TransactionModel>();
        }
    }
}
