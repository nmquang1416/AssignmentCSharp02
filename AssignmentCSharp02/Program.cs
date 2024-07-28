// See https://aka.ms/new-console-template for more information

using AssignmentCSharp02.controller.user;
using AssignmentCSharp02.Entity;
using AssignmentCSharp02.repository.user;

UserController userController = new UserController();
int choice01;

do
{
    int choice;
    do
    {
        Console.WriteLine("————————————Spring hero bank————————————");
        Console.WriteLine("You are User or Admin ?");
        Console.WriteLine("[1]. User");
        Console.WriteLine("[2]. Admin");
        choice = Convert.ToInt32(Console.ReadLine());

        if (choice != 1 && choice!= 2)
        {
            Console.WriteLine("\nplease, choice [1] or [2] to continue.\n");
        }
    } while (choice != 1 && choice != 2);

    //Sign in|sign up
    do
    {
        Console.WriteLine("————————————Spring hero bank————————————");
        Console.WriteLine("You want to Sign in or Sign up ?");
        Console.WriteLine("[1]. Sign in");
        Console.WriteLine("[2]. Sign up");
        choice = Convert.ToInt32(Console.ReadLine());

        if (choice != 1 && choice!= 2)
        {
            Console.WriteLine("\nplease, choice [1] or [2] to continue.\n");
        }
    } while (choice != 1 && choice != 2);
    
    UserEntity userEntity = null;
    switch (choice)
    {
        case 1:
            userEntity = userController.signinUser();
            break;
        case 2:
            userController.signupUser();
            Console.WriteLine("Please log in account you just Sign up to continue");
            userEntity = userController.signinUser();
            break;
    }

    while (choice != 8)
    {
        if (userEntity != null)
        {
            Console.WriteLine("\n————————————Spring hero bank————————————");
            Console.WriteLine("Welcome " + userEntity.firstName );
            Console.WriteLine("Please choice one service: ");
            Console.WriteLine("[1]. Send amount to my account");
            Console.WriteLine("[2]. Withdraw Amount");
            Console.WriteLine("[3]. Transaction to another account");
            Console.WriteLine("[4]. Query Balance");
            Console.WriteLine("[5]. Change information");
            Console.WriteLine("[6]. Change password");
            Console.WriteLine("[7]. Query transaction history");
            Console.WriteLine("[8]. Exit");

            Console.WriteLine("Your choice is: ");
            choice = Convert.ToInt32(Console.ReadLine());
        }

        switch (choice)
        {   
            case 1:
                userController.sendAmountToMyAccount(userEntity.userId);
                break;
            case 2:
                userController.withdrawAmount(userEntity.userId);
                break;
            case 3: 
                userController.transactionAmount();
                break;
            case 4:
                userController.queryBalance(userEntity.userId);
                break;
            case 5:
                userController.editInfo(userEntity.userId);
                break;
            case 6:
                userController.editPassword(userEntity.userId);
                break;
            case 7:
                userController.queryBalance(userEntity.userId);
                break;
            case 8:
                choice = 8;
                break;
        }
    }

    if (choice == 8)
    {
        Console.WriteLine("Good bye, see you later!");
    }
    choice01 = choice;
    
} while (choice01 != 8);







// Console.WriteLine("————————————Hello " + userEntity.firstName +"————————————");
// userController.queryTransactionHistory(userEntity.accountNumber);
// userController.signupUser();
// userController.transactionAmount();
// userController.editPassword(userEntity.userId);
// userController.queryBalance(userEntity.userId);
// userController.sendAmountToMyAccount(userEntity.userId);
// userRepository.findAllUser();
 
