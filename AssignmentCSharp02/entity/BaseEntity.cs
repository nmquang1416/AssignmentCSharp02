namespace AssignmentCSharp02.Entity;

public class BaseEntity
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
    public DateTime birth { get; set; }
    public bool isAdmin { get; set; } 
    public int status { get; set; }
    public DateTime update_at { get; set; }
    public DateTime create_at { get; set; }
    public DateTime update_by { get; set; }
    public DateTime create_by { get; set; }

    public BaseEntity()
    {
    }

    public BaseEntity(string firstName, string lastName, string email, string phone, DateTime birth, bool isAdmin, int status, DateTime updateAt, DateTime createAt, DateTime updateBy, DateTime createBy)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
        this.phone = phone;
        this.birth = birth;
        this.isAdmin = isAdmin;
        this.status = status;
        update_at = updateAt;
        create_at = createAt;
        update_by = updateBy;
        create_by = createBy;
    }
}