using AssignmentCSharp02.Entity;

namespace AssignmentCSharp02.repository.transaction;

public interface InterfaceTransactionRepository
{
    TransactionEntity save(TransactionEntity transactionEntity);
    List<TransactionEntity> findAllTransaction(TransactionEntity transactionEntity);
    TransactionEntity updateTransaction(TransactionEntity transactionEntity);
    void deleteTransaction(long id);
}