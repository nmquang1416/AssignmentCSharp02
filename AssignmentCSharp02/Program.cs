// See https://aka.ms/new-console-template for more information

using AssignmentCSharp02.controller.user;
using AssignmentCSharp02.repository.user;

Console.WriteLine("Hello, World!");
UserRepository userRepository =new UserRepository();
UserController userController = new UserController();

// userController.signupUser();
userController.signinUser();
// userRepository.findAllUser();
 
