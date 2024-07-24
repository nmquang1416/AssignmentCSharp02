using AssignmentCSharp02.Entity;

namespace AssignmentCSharp02.repository.user;

public interface InterfaceUserRepository
{
    UserEntity save(UserEntity userEntity);
    List<TransactionEntity> findUserTransactionHistory(string accountNumber);
    public List<UserEntity> findAllUser();
    UserEntity update(UserEntity userEntity);
    UserEntity findAllInfoUser(long id);
    void deleteTransaction(long id);

}