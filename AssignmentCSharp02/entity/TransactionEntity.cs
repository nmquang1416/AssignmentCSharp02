namespace AssignmentCSharp02.Entity;

public class TransactionEntity
{
    public long transactionId { get; set; }
    public String accountSend{ get; set; }
    public String personSend{ get; set; }
    public String accountReceive{ get; set; }
    public String personReceive{ get; set; }
    public double transactionAmount{ get; set; }
    public String message{ get; set; }
    public int status { get; set; }
    public DateTime create_at{ get; set; }
    public DateTime update_at{ get; set; }
    public string create_by{ get; set; }
    public string update_by{ get; set; }
    public TransactionEntity()
    {
    }

    public TransactionEntity(long transactionId, string accountSend, string personSend, string accountReceive, string personReceive, double transactionAmount, string message, int status, DateTime createAt, DateTime updateAt, string createBy, string updateBy)
    {
        this.transactionId = transactionId;
        this.accountSend = accountSend;
        this.personSend = personSend;
        this.accountReceive = accountReceive;
        this.personReceive = personReceive;
        this.transactionAmount = transactionAmount;
        this.message = message;
        this.status = status;
        create_at = createAt;
        update_at = updateAt;
        create_by = createBy;
        update_by = updateBy;
    }
}