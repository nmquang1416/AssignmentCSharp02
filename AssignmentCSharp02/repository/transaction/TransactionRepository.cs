using AssignmentCSharp02.Entity;
using MySqlConnector;

namespace AssignmentCSharp02.repository.transaction;

public class TransactionRepository : InterfaceTransactionRepository
{
    public string MYSQL_CONNECTION_STRING = "server=127.0.0.1;uid=root;pwd=;database=spring_hero_bank";
    public TransactionEntity save(TransactionEntity transactionEntity)
    {
        try
        {
            var connection = new MySqlConnection(MYSQL_CONNECTION_STRING);
            connection.Open();
            
            MySqlCommand command = new MySqlCommand(
                "insert into transaction_entity ( account_send, person_send, account_receive, person_receive, transaction_amount, message, status, update_at, create_at, update_by, create_by) " +
                "values (@account_send, @person_send,@account_receive, @person_receive,@transaction_amount,@message, @status, @update_at, @create_at, @update_by, @create_by)");
            command.Connection = connection;

            command.Parameters.AddWithValue("@account_send", transactionEntity.accountSend);
            command.Parameters.AddWithValue("@person_send", transactionEntity.personSend);
            command.Parameters.AddWithValue("@account_receive", transactionEntity.accountReceive);
            command.Parameters.AddWithValue("@person_receive", transactionEntity.personReceive);
            command.Parameters.AddWithValue("@transaction_amount", transactionEntity.transactionAmount);
            command.Parameters.AddWithValue("@message", transactionEntity.message);
            command.Parameters.AddWithValue("@status", transactionEntity.status);
            command.Parameters.AddWithValue("@update_at", transactionEntity.update_at);
            command.Parameters.AddWithValue("@create_at", transactionEntity.create_at);
            command.Parameters.AddWithValue("@update_by", transactionEntity.update_by);
            command.Parameters.AddWithValue("@create_by", transactionEntity.create_by);
            
            command.ExecuteNonQuery();
            return transactionEntity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public List<TransactionEntity> findAllTransaction()
    {
        var result = new List<TransactionEntity>();
        try
        {
            var connection = new MySqlConnection(MYSQL_CONNECTION_STRING);
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from transaction_entity where status = 1 ");
            command.Connection = connection;
            MySqlDataReader mySqlDataReader = command.ExecuteReader();
            
            while (mySqlDataReader.Read())
            {
                var transaction_id = mySqlDataReader.GetInt64("transaction_id");
                var account_send = mySqlDataReader.GetString("account_send");
                var person_send = mySqlDataReader.GetString("person_send");
                var account_receive = mySqlDataReader.GetString("account_receive");
                var person_receive = mySqlDataReader.GetString("person_receive");
                var transaction_amount= mySqlDataReader.GetDouble("transaction_amount");
                var create_at = mySqlDataReader.GetDateTime("create_at");
                var update_at = mySqlDataReader.GetDateTime("update_at");
                var create_by = mySqlDataReader.GetString("create_by");
                var update_by = mySqlDataReader.GetString("update_by");
                TransactionEntity transactionEntity = new TransactionEntity();
                transactionEntity.transactionId = transaction_id;
                transactionEntity.accountSend = account_send;
                transactionEntity.personSend = person_send;
                transactionEntity.accountReceive = account_receive;
                transactionEntity.personReceive = person_receive;
                transactionEntity.transactionAmount = transaction_amount;
                transactionEntity.create_at = create_at;
                transactionEntity.update_at = update_at;
                transactionEntity.create_by = create_by;
                transactionEntity.update_by = update_by;
                
                result.Add(transactionEntity);
            }

            // Console.WriteLine("done!");
            connection.Close();
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public List<TransactionEntity> findAllTransactionWithAccountNumber(string accountNumber)
    {
        var result = new List<TransactionEntity>();
        
        try
        {
            var connection = new MySqlConnection(MYSQL_CONNECTION_STRING);
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from transaction_entity where status = 1 and account_send = " + accountNumber);
            command.Connection = connection;
            MySqlDataReader mySqlDataReader = command.ExecuteReader();
            
            while (mySqlDataReader.Read())
            {
                var transaction_id = mySqlDataReader.GetInt64("transaction_id");
                var account_send = mySqlDataReader.GetString("account_send");
                var person_send = mySqlDataReader.GetString("person_send");
                var account_receive = mySqlDataReader.GetString("account_receive");
                var person_receive = mySqlDataReader.GetString("person_receive");
                var transaction_amount= mySqlDataReader.GetDouble("transaction_amount");
                var create_at = mySqlDataReader.GetDateTime("create_at");
                var update_at = mySqlDataReader.GetDateTime("update_at");
                var create_by = mySqlDataReader.GetString("create_by");
                var update_by = mySqlDataReader.GetString("update_by");

                TransactionEntity transactionEntity = new TransactionEntity();
                transactionEntity.transactionId = transaction_id;
                transactionEntity.accountSend = account_send;
                transactionEntity.personSend = person_send;
                transactionEntity.accountReceive = account_receive;
                transactionEntity.personReceive = person_receive;
                transactionEntity.transactionAmount = transaction_amount;
                transactionEntity.create_at = create_at;
                transactionEntity.update_at = update_at;
                transactionEntity.create_by = create_by;
                transactionEntity.update_by = update_by;
                
                result.Add(transactionEntity);
            }

            // Console.WriteLine("done!");
            connection.Close();
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public TransactionEntity updateTransaction(TransactionEntity transactionEntity)
    {
        try
        {
            var connection = new MySqlConnection(MYSQL_CONNECTION_STRING);
            connection.Open();
            MySqlCommand command = new MySqlCommand("update transaction_entity set account_send = @account_send, person_send = @person_send, account_receive = @account_receive, person_receive = @person_receive, transaction_amount = @transaction_amount, message = @message, create_at = @create_at, update_at = @update_at, create_by = @create_by, update_by = @update_by where account_send =" + transactionEntity.accountSend);
            command.Connection = connection;

            command.Parameters.AddWithValue("@account_send", transactionEntity.accountSend);
            command.Parameters.AddWithValue("@person_send", transactionEntity.personSend);
            command.Parameters.AddWithValue("@account_receive", transactionEntity.accountReceive);
            command.Parameters.AddWithValue("@person_receive", transactionEntity.personReceive);
            command.Parameters.AddWithValue("@transaction_amount", transactionEntity.transactionAmount);
            command.Parameters.AddWithValue("@message", transactionEntity.message);
            command.Parameters.AddWithValue("@create_at", transactionEntity.create_at);
            command.Parameters.AddWithValue("@create_by", transactionEntity.create_by);
            command.Parameters.AddWithValue("@update_at", transactionEntity.update_at);
            command.Parameters.AddWithValue("@update_by", transactionEntity.update_by);
            
            command.ExecuteNonQuery();
            connection.Close();
            // Console.WriteLine("done");
            return transactionEntity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        throw new NotImplementedException();
    }

    public void deleteTransaction(long id)
    {
        try
        {
            var connection = new MySqlConnection(MYSQL_CONNECTION_STRING);
            connection.Open();
            MySqlCommand command = new MySqlCommand("update transaction_entity set status = 0 where transaction_id =" + id);
            command.Connection = connection;
            
            // Console.WriteLine("done");
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        throw new NotImplementedException();
    }
}