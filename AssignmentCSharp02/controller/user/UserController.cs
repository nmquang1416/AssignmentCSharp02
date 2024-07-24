using System.Collections;
using AssignmentCSharp02.Entity;
using AssignmentCSharp02.repository.user;

namespace AssignmentCSharp02.controller.user;

public class UserController
{
    private string _userEntityUserName;
    private string _entityUserName;

    public void signinUser()
    {
        
        UserRepository userRepository = new UserRepository();
        List<UserEntity> users = userRepository.findAllUser();
        
        Console.WriteLine("Enter your user name: ");
        var user_name = Console.ReadLine();
        
        Console.WriteLine("Enter your password: ");
        var password = Console.ReadLine();

        bool check = true;
        foreach (var user in users)
        {
            if (user_name==$"{user.userName}" && userRepository.ComparePassword($"{user.userPassword}", $"{password}", $"{user.salt}"))
            {
                Console.WriteLine("success");
                check = false;
            }
        }
        if (check)
        {
            Console.WriteLine("fail");
        }
    }

    public void signupUser()
    {
        UserRepository userRepository = new UserRepository();
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

        userRepository.save(userEntity);
        Console.WriteLine("sign up done");
    }

    public void sendAmountToMyAccount(long id)
    {
        UserRepository userRepository = new UserRepository();
    }

    public void withdrawAmount(long id)
    {
        UserRepository userRepository = new UserRepository();
        
    }

    public void transactionAmount(string account01, string account02)
    {
        UserRepository userRepository = new UserRepository();
    }

    public double minusAmount(double amount)
    {
        UserRepository userRepository = new UserRepository();
        return amount;
    }

    public double plusAmount(double amount)
    {
        UserRepository userRepository = new UserRepository();
        return amount;
    }

    public void queryBalance(long id)
    {
        UserRepository userRepository = new UserRepository();
    }

    public void editInfo(long id)
    {
        UserRepository userRepository = new UserRepository();
    }

    public void editPassword(long id)
    {
        UserRepository userRepository = new UserRepository();
    }

    public void queryTransactionHistory(string accountNumber)
    {
        UserRepository userRepository = new UserRepository();
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