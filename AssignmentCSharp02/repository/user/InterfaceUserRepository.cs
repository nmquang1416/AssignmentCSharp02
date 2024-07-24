using AssignmentCSharp02.Entity;

namespace AssignmentCSharp02.repository.user;

public interface InterfaceUserRepository
{
    UserEntity save(UserEntity userEntity);
    List<TransactionEntity> findUserTransactionHistory(string accountNumber);
    UserEntity updateInfo(UserEntity userEntity);
    UserEntity updatePassword(UserEntity userEntity);
    UserEntity updateAmount(UserEntity userEntity);
    UserEntity getAmount(UserEntity userEntity);
    void showInfo (long id);
    double minusAmount (double amount);
    double plusAmount (double amount);
    void deleteTransaction(string id);

}