namespace AssignmentCSharp02.Entity;

public class UserEntity : BaseEntity
{
    public long userId { get; set; }
    public string userName { get; set; }
    public string userPassword { get; set; }
    public string accountNumber { get; set; }
    public double balance { get; set; }

    public UserEntity()
    {
    }
    

    public UserEntity(long userId, string userName, string userPassword, string accountNumber, double balance)
    {
        this.userId = userId;
        this.userName = userName;
        this.userPassword = userPassword;
        this.accountNumber = accountNumber;
        this.balance = balance;
    }
}