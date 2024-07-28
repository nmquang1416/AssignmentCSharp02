using AssignmentCSharp02.Entity;

namespace AssignmentCSharp02.repository.admin;

public interface InterfaceAdminRepository
{
    AdminEntity save(AdminEntity adminEntity);
    List<UserEntity> findAllUser();
    List<AdminEntity> findAllAdmin();
    List<TransactionEntity> findAllTransaction();
    UserEntity findUserByLastName(string lastName);
    UserEntity findUserByPhone(string phone);
    UserEntity findUserByAccountNumber(string accountNumber);
    List<TransactionEntity> findTransactionByAccountNumber(string accountNumber);
    UserEntity saveNewUser(UserEntity userEntity);
    UserEntity updateStatusUser(UserEntity userEntity);
    AdminEntity update(AdminEntity adminEntity);

}