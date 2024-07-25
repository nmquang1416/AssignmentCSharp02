// See https://aka.ms/new-console-template for more information

using AssignmentCSharp02.controller.user;
using AssignmentCSharp02.Entity;
using AssignmentCSharp02.repository.user;

Console.WriteLine("Hello, World!");
UserController userController = new UserController();

// userController.signupUser();
UserEntity userEntity = userController.signinUser();

// userController.transactionAmount();
userController.editPassword(userEntity.userId);
// userController.queryBalance(userEntity.userId);
// userController.sendAmountToMyAccount(userEntity.userId);
// userRepository.findAllUser();
 
