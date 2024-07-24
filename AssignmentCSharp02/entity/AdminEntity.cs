namespace AssignmentCSharp02.Entity;

public class AdminEntity : BaseEntity
{
    public long adminId { get; set; }
    public string adminName { get; set; }
    public string adminPassword { get; set; }

    public AdminEntity()
    {
    }

    public AdminEntity(long adminId, string adminName, string adminPassword)
    {
        this.adminId = adminId;
        this.adminName = adminName;
        this.adminPassword = adminPassword;
    }
}