using AssignmentCSharp02.Entity;

namespace AssignmentCSharp02.repository.user;

public interface InterfaceUserRepository
{
    UserEntity save(UserEntity userEntity);
    List<TransactionEntity> findAllTransactionHistory(TransactionEntity transactionEntity);
    UserEntity findAllInfoUser(UserEntity userEntity);
    UserEntity updateInfo(UserEntity userEntity);
    UserEntity updatePassword(UserEntity userEntity);
    UserEntity updateAmount(string accountNumber);
    void showInfo (UserEntity userEntity);
    UserEntity minusAmount (UserEntity userEntity);
    UserEntity plusAmount (UserEntity userEntity);
    void deleteTransaction(string id);
    UserEntity getAmount(UserEntity userEntity);

}