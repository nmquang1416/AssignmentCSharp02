// See https://aka.ms/new-console-template for more information

using AssignmentCSharp02.controller.admin;
using AssignmentCSharp02.controller.user;
using AssignmentCSharp02.Entity;
using AssignmentCSharp02.repository.user;

UserController userController = new UserController();
AdminController adminController = new AdminController();
int choice01 = 0;

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

    do
    {
        if (choice == 1)
        {
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
        }
    } while (choice01 != 8);

    do
    {
        if (choice == 2)
        {
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
        
            AdminEntity adminEntity = null;
            switch (choice)
            {
                case 1:
                    adminEntity = adminController.signinAdmin();
                    break;
                case 2:
                    userController.signupUser();
                    Console.WriteLine("Please log in account you just Sign up to continue");
                    adminEntity = adminController.signinAdmin();
                    break;
            }
        
            while (choice != 8)
            {
                if (adminEntity != null)
                {
                    Console.WriteLine("\n————————————Spring hero bank————————————");
                    Console.WriteLine("Welcome " + adminEntity.firstName );
                    Console.WriteLine("Please choice one service: ");
                    Console.WriteLine("[1]. Show list users");
                    Console.WriteLine("[2]. Show list transactions");
                    Console.WriteLine("[3]. Find user by name");
                    Console.WriteLine("[4]. Find user by account number");
                    Console.WriteLine("[5]. Find user by phone");
                    Console.WriteLine("[6]. Add new user");
                    Console.WriteLine("[7]. Lock and unlock user");
                    Console.WriteLine("[8]. Find transaction by account number");
                    Console.WriteLine("[9]. Edit information");
                    Console.WriteLine("[10]. Edit password");
                    Console.WriteLine("[11]. Exit");

                    Console.WriteLine("Your choice is: ");
                    choice = Convert.ToInt32(Console.ReadLine());
                }

                switch (choice)
                {   
                    case 1:
                        adminController.showAllListUser();
                        break;
                    case 2:
                        adminController.showAllListTransactionHistory();
                        break;
                    case 3: 
                        adminController.searchUserByName();
                        break;
                    case 4:
                        adminController.searchUserByAccountNumber();
                        break;
                    case 5:
                        adminController.searchUserByPhone();
                        break;
                    case 6:
                        adminController.createNewUser();
                        break;
                    case 7:
                        adminController.lockAndUnLockUser();
                        break;
                    case 8:
                        adminController.findTransactionHistoryByAccountNumber();
                        break;
                    case 9:
                        adminController.editInformation();
                        break;
                    case 10:
                        adminController.editPassword();
                        break;
                    case 11:
                        choice = 11;
                        break;
                }
            }

            if (choice == 8)
            {
                Console.WriteLine("Good bye, see you later!");
            }
            choice01 = choice;
        }
    } while (choice01 != 11);


 
