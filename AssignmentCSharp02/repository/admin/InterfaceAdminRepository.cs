using AssignmentCSharp02.Entity;

namespace AssignmentCSharp02.repository.admin;

public interface InterfaceAdminRepository
{
    List<UserEntity> findAllUser();
    List<TransactionEntity> findAllTransaction();
    UserEntity findUserByLastName(string lastName);
    UserEntity findUserByPhone(string phone);
    UserEntity saveNewUser(UserEntity userEntity);
    UserEntity updateStatusUser(UserEntity userEntity);

}