using AssignmentCSharp02.Entity;

namespace AssignmentCSharp02.repository.transaction;

public interface InterfaceTransactionRepository
{
    TransactionEntity save(TransactionEntity transactionEntity);
    List<TransactionEntity> findAllTransaction();
    List<TransactionEntity> findAllTransactionWithAccountNumber(string accountNumber);
    TransactionEntity updateTransaction(TransactionEntity transactionEntity);
    void deleteTransaction(long id);
}