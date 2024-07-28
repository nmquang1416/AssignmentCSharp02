using System.Collections;
using AssignmentCSharp02.Entity;
using AssignmentCSharp02.repository.transaction;
using AssignmentCSharp02.repository.user;

namespace AssignmentCSharp02.controller.user;

public class UserController
{
    UserEntity userEntity = new UserEntity();
    TransactionEntity transactionEntity = new TransactionEntity();
    public UserEntity signinUser()
    {
        try
        {
            UserRepository userRepository = new UserRepository();
            List<UserEntity> users = userRepository.findAllUser();

            Console.WriteLine("Enter your user name: ");
            var user_name = Console.ReadLine();

            Console.WriteLine("Enter your password: ");
            var password = Console.ReadLine();

            int status = 0;
            bool check = true;
            foreach (var user in users)
            {
                status = user.status;
                if (user_name == $"{user.userName}" &&
                    userRepository.ComparePassword($"{user.userPassword}", $"{password}", $"{user.salt}") && status == 1)
                {
                    userEntity = user;
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

            return userEntity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
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
        try
        {
            UserRepository userRepository = new UserRepository();
            UserEntity userEntity = userRepository.findAllInfoUser(id);
            TransactionRepository transactionRepository = new TransactionRepository();

            Console.WriteLine("Enter amount you want send to account: ");
            double amount = Convert.ToDouble(Console.ReadLine());
            
            userEntity.balance += amount;

            transactionEntity.accountSend = userEntity.accountNumber;
            transactionEntity.personSend = userEntity.firstName;
            transactionEntity.accountReceive = userEntity.accountNumber;
            transactionEntity.personReceive = userEntity.firstName;
            transactionEntity.transactionAmount = amount;
            transactionEntity.message = "";
            transactionEntity.status = 1;
            transactionEntity.create_at = DateTime.Now;
            transactionEntity.update_at = DateTime.Now;
            transactionEntity.create_by = userEntity.userName;
            transactionEntity.update_by = userEntity.userName;
            
            transactionRepository.save(transactionEntity);
            userRepository.update(userEntity);

            Console.WriteLine("done");
            
            // return amount;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void withdrawAmount(long id)
    {
        try
        {
            UserRepository userRepository = new UserRepository();
            UserEntity userEntity = userRepository.findAllInfoUser(id);
            Console.WriteLine("Enter amount you want send to account: ");
            double amount = Convert.ToDouble(Console.ReadLine());
            
            userEntity.balance =- amount;

            userRepository.update(userEntity);

            Console.WriteLine("done");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    public void transactionAmount()
    {
        try
        {
            UserRepository userRepository = new UserRepository();
            List<UserEntity> users = userRepository.findAllUser();
            TransactionEntity transactionEntity = new TransactionEntity();
            TransactionRepository transactionRepository = new TransactionRepository();
            UserEntity userEntity = null;
            
            Console.WriteLine("Enter account you want transaction: ");
            string account02 = Console.ReadLine();

            Console.WriteLine("Enter your amount you want send: ");
            double amount = Convert.ToDouble(Console.ReadLine());
            
            Console.WriteLine("Enter account you want transaction: ");
            string message = Console.ReadLine();
            
            foreach (var user in users)
            {
                if (account02 == $"{user.accountNumber}")
                {
                    userEntity = user;
                }
            }
            userEntity.balance = plusAmount(userEntity.balance, amount);
            this.userEntity.balance = minusAmount(this.userEntity.balance, amount);

            transactionEntity.accountSend = this.userEntity.accountNumber;
            transactionEntity.personSend = this.userEntity.firstName;
            transactionEntity.accountReceive = userEntity.accountNumber;
            transactionEntity.personReceive = userEntity.firstName;
            transactionEntity.message = message;
            transactionEntity.status = 1;
            transactionEntity.transactionAmount = amount;
            transactionEntity.create_at = DateTime.Now;
            transactionEntity.create_by = userEntity.userName;
            transactionEntity.update_at = DateTime.Now;
            transactionEntity.update_by = userEntity.userName;

            transactionRepository.save(transactionEntity);
            userRepository.update(this.userEntity);
            userRepository.update(userEntity);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public double minusAmount(double balance, double amount)
    {
        balance -= amount;
        return balance;
    }

    public double plusAmount(double balance, double amount)
    {
        balance += amount;
        return balance;
    }

    public void queryBalance(long id)
    {
        try
        {
            UserRepository userRepository = new UserRepository();
            Console.WriteLine("Your balance: " + userEntity.balance);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void editInfo(long id)
    {
        try
        {
            UserRepository userRepository = new UserRepository();
            userRepository.findAllInfoUser(id);
            
            Console.WriteLine("Edit first name: ");
            string firstName = Console.ReadLine();
            
            Console.WriteLine("Edit last name: ");
            string lastName = Console.ReadLine();
            
            Console.WriteLine("Edit email: ");
            string email = Console.ReadLine();
            
            Console.WriteLine("Edit phone: ");
            string phone = Console.ReadLine();

            userEntity.firstName = firstName;
            userEntity.lastName = lastName;
            userEntity.email = email;
            userEntity.phone = phone;

            userRepository.update(userEntity);
            Console.WriteLine("edit done!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void editPassword(long id)
    {
        try
        {
            UserRepository userRepository = new UserRepository();
            List<UserEntity> users = userRepository.findAllUser();

            var user_name = userEntity.userName;
            var password = userEntity.userPassword;
            
            string oldPassword;
            string oldSalt = userEntity.salt;
            string oldPasswordHashed;

            string newPassword;
            string newSalt;
            string newPasswordHashed;
            string newPasswordWithOldSalt ;
            
            do
            {
                Console.WriteLine("Enter your old password: ");
                oldPassword = Console.ReadLine();
                oldPasswordHashed = userRepository.HashPassword(oldPassword, oldSalt);
                if (password != oldPasswordHashed)
                {
                    Console.WriteLine("input password not equal old password, try again");
                }
            } while (password != oldPasswordHashed);

            do
            {
                Console.WriteLine("Enter your new password: ");
                newPassword = Console.ReadLine();
                
                newPasswordWithOldSalt = userRepository.HashPassword(newPassword, oldSalt);
                if (password == newPasswordWithOldSalt)
                {
                    Console.WriteLine("new password can't equal old password");
                }
            } while (password == newPasswordWithOldSalt);

            newSalt = userRepository.GenerateSalt();
            newPasswordHashed = userRepository.HashPassword(newPassword, newSalt);
            userEntity.userPassword = newPasswordHashed;

            userRepository.update(userEntity);
            Console.WriteLine("done!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void queryTransactionHistory(string accountNumber)
    {
        UserRepository userRepository = new UserRepository();
        TransactionRepository transactionRepository = new TransactionRepository();

        List<TransactionEntity> transactionList = transactionRepository.findAllTransactionWithAccountNumber(userEntity.accountNumber);

        foreach (var transaction in transactionList)
        {
            Console.WriteLine("\n=====Your Transaction=====");
            Console.WriteLine("transaction id:" + transaction.transactionId);
            Console.WriteLine("account send:" + transaction.accountSend);
            Console.WriteLine("person send:" + transaction.personSend);
            Console.WriteLine("account receive:" + transaction.accountReceive);
            Console.WriteLine("person receive:" + transaction.personReceive);
            Console.WriteLine("transaction amount:" + transaction.transactionAmount);
            Console.WriteLine("message:" + transaction.message);
            Console.WriteLine("create at:" + transaction.create_at);
            Console.WriteLine("create by:" + transaction.create_by);
        }
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