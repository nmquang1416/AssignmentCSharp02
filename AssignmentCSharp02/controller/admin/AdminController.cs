using AssignmentCSharp02.Entity;
using AssignmentCSharp02.repository.admin;
using AssignmentCSharp02.repository.user;

namespace AssignmentCSharp02.controller.admin;

public class AdminController
{
    AdminEntity adminEntity = new AdminEntity();
    UserEntity userEntity = new UserEntity();
    TransactionEntity transactionEntity = new TransactionEntity();
    
    public AdminEntity signinAdmin()
    {
        try
        {
            AdminRepository adminRepository = new AdminRepository();
            List<AdminEntity> admins = adminRepository.findAllAdmin();

            Console.WriteLine("Enter your user name: ");
            var user_name = Console.ReadLine();

            Console.WriteLine("Enter your password: ");
            var password = Console.ReadLine();

            int status = 0;
            bool check = true;
            foreach (var admin in admins)
            {
                status = admin.status;
                if (user_name == $"{admin.adminName}" &&
                    adminRepository.ComparePassword($"{admin.adminPassword}", $"{password}", $"{admin.salt}") && status == 1)
                {
                    adminEntity = admin;
                    Console.WriteLine("success");
                    check = false;
                }
            }

            if (status != 1)
            {
                Console.WriteLine("your account is block, please contact for admin to know more!");
            }
            
            if (check)
            {
                Console.WriteLine("fail");
            }

            return adminEntity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void signupAdmin()
    {
        AdminRepository adminRepository = new AdminRepository();
        AdminEntity adminEntity = new AdminEntity();

        Console.WriteLine("Please, enter admin name: ");
        var userName = Console.ReadLine();
        
        Console.WriteLine("Please, enter admin password: ");
        var userPassword = Console.ReadLine();
        string salt = adminRepository.GenerateSalt();
        string passwordHashed = adminRepository.HashPassword(userPassword, salt);
        
        var balance = 0;
        var accountNumber = "1903" + randomAccountNumber(7);
        
        Console.WriteLine("Please, enter fisrt name: ");
        var fisrtName = Console.ReadLine();
        
        Console.WriteLine("Please, enter last name: ");
        var lastName = Console.ReadLine();
        
        Console.WriteLine("Please, enter email: ");
        var email = Console.ReadLine();
        
        Console.WriteLine("Please, enter phone: ");
        var phone = Console.ReadLine();
        
        var isAdmin = false;
        var status = 1;
        var update_at = DateTime.Now;
        var create_at = DateTime.Now;
        var update_by = userName;
        var create_by = userName;

        adminEntity.adminName = userName;
        adminEntity.adminPassword = passwordHashed;
        adminEntity.firstName = fisrtName;
        adminEntity.lastName = lastName;
        adminEntity.email = email;
        adminEntity.phone = phone;
        adminEntity.salt = salt;
        adminEntity.isAdmin = isAdmin;   
        adminEntity.status = status;
        adminEntity.update_at = update_at;
        adminEntity.create_at = create_at;
        adminEntity.update_by = update_by;
        adminEntity.create_by = create_by;

        adminRepository.save(adminEntity);
        Console.WriteLine("sign up done");
    }
    public void showAllListUser()
    {
        AdminRepository adminRepository = new AdminRepository();
        List<UserEntity> users = adminRepository.findAllUser();
        foreach (var user in users)
        {
            Console.WriteLine("------------------------");
            Console.WriteLine("User id: " + user.userId);
            Console.WriteLine("User name: " + user.userName);
            Console.WriteLine("User Password: " + user.userPassword);
            Console.WriteLine("User balance: " + user.balance);
            Console.WriteLine("User account number: " + user.accountNumber);
            Console.WriteLine("User first name: " + user.firstName);
            Console.WriteLine("User last name: " + user.lastName);
            Console.WriteLine("User email: " + user.email);
            Console.WriteLine("User phone: " + user.phone);
            Console.WriteLine("User salt: " + user.salt);
            Console.WriteLine("User is Admin: " + user.isAdmin);
            Console.WriteLine("User status: " + user.status);
            Console.WriteLine("User update at: " + user.update_at);
            Console.WriteLine("User create at: " + user.create_at);
            Console.WriteLine("User update by: " + user.update_by);
            Console.WriteLine("User create by: " + user.create_by);
        }
    }
    
    public void showAllListTransactionHistory()
    {
        AdminRepository adminRepository = new AdminRepository();
        List<TransactionEntity> transactions =  adminRepository.findAllTransaction();

        foreach (var transaction in transactions)  
        {
            Console.WriteLine("------------------------");
            Console.WriteLine("transaction id: " + transaction.transactionId);
            Console.WriteLine("account send: " + transaction.accountSend);
            Console.WriteLine("person send: " + transaction.personSend);
            Console.WriteLine("account receive: " + transaction.accountReceive);
            Console.WriteLine("person receive: " + transaction.personReceive);
            Console.WriteLine("transaction amount: " + transaction.transactionAmount);
            Console.WriteLine("create at: " + transaction.create_at);
            Console.WriteLine("update at: " + transaction.update_at);
            Console.WriteLine("create by : " + transaction.create_by);
            Console.WriteLine("update by: " + transaction.update_by);
        }
    }

    public void searchUserByName()
    {
        AdminRepository adminRepository = new AdminRepository();
        Console.WriteLine("Enter last name to searching: ");
        string name = Console.ReadLine();
        
        userEntity = adminRepository.findUserByLastName(name);

        Console.WriteLine("------------Your result------------");
        Console.WriteLine("User id: " + userEntity.userId);
        Console.WriteLine("User name: " + userEntity.userName);
        Console.WriteLine("User Password: " + userEntity.userPassword);
        Console.WriteLine("User balance: " + userEntity.balance);
        Console.WriteLine("User account number: " + userEntity.accountNumber);
        Console.WriteLine("User first name: " + userEntity.firstName);
        Console.WriteLine("User last name: " + userEntity.lastName);
        Console.WriteLine("User email: " + userEntity.email);
        Console.WriteLine("User phone: " + userEntity.phone);
        Console.WriteLine("User salt: " + userEntity.salt);
        Console.WriteLine("User is Admin: " + userEntity.isAdmin);
        Console.WriteLine("User status: " + userEntity.status);
        Console.WriteLine("User update at: " + userEntity.update_at);
        Console.WriteLine("User create at: " + userEntity.create_at);
        Console.WriteLine("User update by: " + userEntity.update_by);
        Console.WriteLine("User create by: " + userEntity.create_by);
    }

    public void searchUserByPhone()
    {
        AdminRepository adminRepository = new AdminRepository();
        Console.WriteLine("Enter phone to searching: ");
        string phone = Console.ReadLine();
        
        userEntity = adminRepository.findUserByPhone(phone);

        Console.WriteLine("------------Your result------------");
        Console.WriteLine("User id: " + userEntity.userId);
        Console.WriteLine("User name: " + userEntity.userName);
        Console.WriteLine("User Password: " + userEntity.userPassword);
        Console.WriteLine("User balance: " + userEntity.balance);
        Console.WriteLine("User account number: " + userEntity.accountNumber);
        Console.WriteLine("User first name: " + userEntity.firstName);
        Console.WriteLine("User last name: " + userEntity.lastName);
        Console.WriteLine("User email: " + userEntity.email);
        Console.WriteLine("User phone: " + userEntity.phone);
        Console.WriteLine("User salt: " + userEntity.salt);
        Console.WriteLine("User is Admin: " + userEntity.isAdmin);
        Console.WriteLine("User status: " + userEntity.status);
        Console.WriteLine("User update at: " + userEntity.update_at);
        Console.WriteLine("User create at: " + userEntity.create_at);
        Console.WriteLine("User update by: " + userEntity.update_by);
        Console.WriteLine("User create by: " + userEntity.create_by);
    }
    
    public void searchUserByAccountNumber()
    {
        AdminRepository adminRepository = new AdminRepository();
        Console.WriteLine("Enter phone to searching: ");
        string accountNumber = Console.ReadLine();
        
        userEntity = adminRepository.findUserByAccountNumber(accountNumber);

        Console.WriteLine("------------Your result------------");
        Console.WriteLine("User id: " + userEntity.userId);
        Console.WriteLine("User name: " + userEntity.userName);
        Console.WriteLine("User Password: " + userEntity.userPassword);
        Console.WriteLine("User balance: " + userEntity.balance);
        Console.WriteLine("User account number: " + userEntity.accountNumber);
        Console.WriteLine("User first name: " + userEntity.firstName);
        Console.WriteLine("User last name: " + userEntity.lastName);
        Console.WriteLine("User email: " + userEntity.email);
        Console.WriteLine("User phone: " + userEntity.phone);
        Console.WriteLine("User salt: " + userEntity.salt);
        Console.WriteLine("User is Admin: " + userEntity.isAdmin);
        Console.WriteLine("User status: " + userEntity.status);
        Console.WriteLine("User update at: " + userEntity.update_at);
        Console.WriteLine("User create at: " + userEntity.create_at);
        Console.WriteLine("User update by: " + userEntity.update_by);
        Console.WriteLine("User create by: " + userEntity.create_by);
    }

    public void createNewUser()
    {
        UserRepository userRepository = new UserRepository();
        AdminRepository adminRepository = new AdminRepository();
        UserEntity userEntity = new UserEntity();

        Console.WriteLine("Please, enter user name: ");
        var userName = Console.ReadLine();
        
        Console.WriteLine("Please, enter user password: ");
        var userPassword = Console.ReadLine();
        string salt = userRepository.GenerateSalt();
        string passwordHashed = userRepository.HashPassword(userPassword, salt);
        
        var balance = 0;
        var accountNumber = "1903" + randomAccountNumber(7);
        
        Console.WriteLine("Please, enter fisrt name: ");
        var fisrtName = Console.ReadLine();
        
        Console.WriteLine("Please, enter last name: ");
        var lastName = Console.ReadLine();
        
        Console.WriteLine("Please, enter email: ");
        var email = Console.ReadLine();
        
        Console.WriteLine("Please, enter phone: ");
        var phone = Console.ReadLine();
        
        var isAdmin = false;
        var status = 1;
        var update_at = DateTime.Now;
        var create_at = DateTime.Now;
        var update_by = userName;
        var create_by = userName;

        userEntity.userName = userName;
        userEntity.userPassword = passwordHashed;
        userEntity.balance =  Convert.ToDouble(balance);
        userEntity.accountNumber = accountNumber;
        userEntity.firstName = fisrtName;
        userEntity.lastName = lastName;
        userEntity.email = email;
        userEntity.phone = phone;
        userEntity.salt = salt;
        userEntity.isAdmin = isAdmin;   
        userEntity.status = status;
        userEntity.update_at = update_at;
        userEntity.create_at = create_at;
        userEntity.update_by = update_by;
        userEntity.create_by = create_by;

        adminRepository.saveNewUser(this.userEntity);
        Console.WriteLine("sign up done");
    }

    public void lockAndUnLockUser()
    {
        Console.WriteLine("Enter your user id: ");
        long userid = Convert.ToInt64(Console.ReadLine());
        AdminRepository adminRepository = new AdminRepository();
        List<UserEntity> users = adminRepository.findAllUser();
        
        Console.WriteLine("This is user you find: ");
        
        foreach (var user in users)
        {
            if (user.userId == userid)
            {
                userEntity = user;
            }
        }
        Console.WriteLine("------------------------");
        Console.WriteLine("User id: " + userEntity.userId);
        Console.WriteLine("User name: " + userEntity.userName);
        Console.WriteLine("User Password: " + userEntity.userPassword);
        Console.WriteLine("User balance: " + userEntity.balance);
        Console.WriteLine("User account number: " + userEntity.accountNumber);
        Console.WriteLine("User first name: " + userEntity.firstName);
        Console.WriteLine("User last name: " + userEntity.lastName);
        Console.WriteLine("User email: " + userEntity.email);
        Console.WriteLine("User phone: " + userEntity.phone);
        Console.WriteLine("User salt: " + userEntity.salt);
        Console.WriteLine("User is Admin: " + userEntity.isAdmin);
        Console.WriteLine("User status: " + userEntity.status);
        Console.WriteLine("User update at: " + userEntity.update_at);
        Console.WriteLine("User create at: " + userEntity.create_at);
        Console.WriteLine("User update by: " + userEntity.update_by);
        Console.WriteLine("User create by: " + userEntity.create_by);

        int choice;
        do
        {
            Console.WriteLine("What do you want?");
            Console.WriteLine("[1]. Lock");
            Console.WriteLine("[2]. Unlock");
            choice = Convert.ToInt32(Console.ReadLine());
        } while (choice is not 1 and 2);
        
        if (userEntity.status == 1 && choice == 1)
        {
            userEntity.status = 0;
            Console.WriteLine("User is locked!");
        }
        else if (userEntity.status == 1 && choice == 2)
        {
            Console.WriteLine("User is not Lock!");
        }
        else if (userEntity.status == 0 && choice == 1)
        {
            Console.WriteLine("The user has been locked out before!");
        }
        else if (userEntity.status == 0 && choice == 2)
        {
            userEntity.status = 1;
            Console.WriteLine("User is Unlocked!");
        }

        adminRepository.updateStatusUser(userEntity);
    }

    public void findTransactionHistoryByAccountNumber()
    {
        AdminRepository adminRepository = new AdminRepository();

        Console.WriteLine("Enter User account number: ");
        string accountNumber = Console.ReadLine();

        List<TransactionEntity> transactionList = adminRepository.findTransactionByAccountNumber(accountNumber);

        foreach (var transaction in transactionList)
        {
            Console.WriteLine("------------------------");
            Console.WriteLine("transaction id: " + transaction.transactionId);
            Console.WriteLine("account send: " + transaction.accountSend);
            Console.WriteLine("person send: " + transaction.personSend);
            Console.WriteLine("account receive: " + transaction.accountReceive);
            Console.WriteLine("person receive: " + transaction.personReceive);
            Console.WriteLine("transaction amount: " + transaction.transactionAmount);
            Console.WriteLine("create at: " + transaction.create_at);
            Console.WriteLine("update at: " + transaction.update_at);
            Console.WriteLine("create by : " + transaction.create_by);
            Console.WriteLine("update by: " + transaction.update_by);
        }
    }

    public void editInformation()
    {
        AdminRepository adminRepository = new AdminRepository();
        List<AdminEntity> admins = adminRepository.findAllAdmin();

        foreach (var admin in admins)
        {
            if (admin.adminId == adminEntity.adminId)
            {
                AdminEntity adminEntity = admin;
            }
        }

        Console.WriteLine("Enter first name: ");
        string firstName = Console.ReadLine();
        
        Console.WriteLine("Enter last name: ");
        string lastName = Console.ReadLine();

        Console.WriteLine("Enter email: ");
        string email = Console.ReadLine();

        Console.WriteLine("Enter phone: ");
        string phone = Console.ReadLine();
        
        adminEntity.firstName = firstName;
        adminEntity.lastName = lastName;
        adminEntity.email = email;
        adminEntity.phone = phone;

        adminRepository.update(adminEntity);
    }

    public void editPassword()
    {
        AdminRepository adminRepository = new AdminRepository();
        List<AdminEntity> admins = adminRepository.findAllAdmin();

        var user_name = adminEntity.adminName;
        var password = adminEntity.adminPassword;
            
        string oldPassword;
        string oldSalt = adminEntity.salt;
        string oldPasswordHashed;

        string newPassword;
        string newSalt;
        string newPasswordHashed;
        string newPasswordWithOldSalt ;
            
        do
        {
            Console.WriteLine("Enter your old password: ");
            oldPassword = Console.ReadLine();
            oldPasswordHashed = adminRepository.HashPassword(oldPassword, oldSalt);
            if (password != oldPasswordHashed)
            {
                Console.WriteLine("input password not equal old password, try again");
            }
        } while (password != oldPasswordHashed);

        do
        {
            Console.WriteLine("Enter your new password: ");
            newPassword = Console.ReadLine();
                
            newPasswordWithOldSalt = adminRepository.HashPassword(newPassword, oldSalt);
            if (password == newPasswordWithOldSalt)
            {
                Console.WriteLine("new password can't equal old password");
            }
        } while (password == newPasswordWithOldSalt);

        newSalt = adminRepository.GenerateSalt();
        newPasswordHashed = adminRepository.HashPassword(newPassword, newSalt);
        adminEntity.adminPassword = newPasswordHashed;

        adminRepository.update(adminEntity);
        Console.WriteLine("done!");
    }
    public string randomAccountNumber(int length)
    {
        var random = new Random();
        string accountNumber = "";
        
        for (int i = 0; i < length; i++)
            accountNumber = String.Concat(accountNumber, random.Next(10).ToString());
        return accountNumber;
    }
}