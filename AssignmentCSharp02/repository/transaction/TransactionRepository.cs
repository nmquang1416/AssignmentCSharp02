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

            return transactionEntity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public List<TransactionEntity> findAllTransaction(TransactionEntity transactionEntity)
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

            Console.WriteLine("done!");
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
            MySqlCommand command = new MySqlCommand("update users set user_name = @user_name, user_password = @user_password, balance = @balance, account_number = @account_number, fisrt_name = @fisrt_name, last_name = @last_name, email = @email, phone = @phone, is_admin = @is_admin, status = @status, update_at = @update_at, create_at = @create_at, update_by = @update_by, create_by = @create_by where user_id =" + userEntity.userId);
            command.Connection = connection;
            
            command.Parameters.AddWithValue("@user_name", transactionEntity.userName);
            command.Parameters.AddWithValue("@user_password", transactionEntity.userPassword);
            command.Parameters.AddWithValue("@balance", transactionEntity.balance);
            command.Parameters.AddWithValue("@account_number", transactionEntity.accountNumber);
            command.Parameters.AddWithValue("@fisrt_name", transactionEntity.firstName);
            command.Parameters.AddWithValue("@last_name", transactionEntity.lastName);
            command.Parameters.AddWithValue("@email", userEntity.email);
            command.Parameters.AddWithValue("@phone", userEntity.phone);
            command.Parameters.AddWithValue("@salt", userEntity.salt);
            command.Parameters.AddWithValue("@is_admin", userEntity.isAdmin);
            command.Parameters.AddWithValue("@status", userEntity.status);
            command.Parameters.AddWithValue("@update_at", userEntity.update_at);
            command.Parameters.AddWithValue("@create_at", userEntity.create_at);
            command.Parameters.AddWithValue("@update_by", userEntity.update_by);
            command.Parameters.AddWithValue("@create_by", userEntity.create_by);
            command.ExecuteNonQuery();
            connection.Close();
            Console.WriteLine("done");
            return userEntity;
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
        throw new NotImplementedException();
    }
}