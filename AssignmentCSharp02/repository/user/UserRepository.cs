using AssignmentCSharp02.Entity;
using MySqlConnector;

namespace AssignmentCSharp02.repository.user;

public class UserRepository : InterfaceUserRepository
{
    public string MYSQL_CONNECTION_STRING = "server=127.0.0.1;uid=root;pwd=;database=spring_hero_bank";

    public UserEntity save(UserEntity userEntity)
    {
        try
        {
            var connection = new MySqlConnection(MYSQL_CONNECTION_STRING);
            connection.Open();

            MySqlCommand command = new MySqlCommand(
                "insert into users ( user_name, user_password, balance, account_number, fisrt_name, last_name, email, phone, is_admin, status, update_at, create_at, update_by, create_by) values (@user_name, @user_password, @balance, @account_number, @fisrt_name, @last_name, @email, @phone, @is_admin, @status, @update_at, @create_at, @update_by, @create_by)");
            command.Connection = connection;

            command.Parameters.AddWithValue("@user_name", userEntity.userName);
            command.Parameters.AddWithValue("@user_password", userEntity.userPassword);
            command.Parameters.AddWithValue("@balance", userEntity.balance);
            command.Parameters.AddWithValue("@account_number", userEntity.accountNumber);
            command.Parameters.AddWithValue("@first_name", userEntity.firstName);
            command.Parameters.AddWithValue("@last_name", userEntity.lastName);
            command.Parameters.AddWithValue("@email", userEntity.email);
            command.Parameters.AddWithValue("@phone", userEntity.phone);
            command.Parameters.AddWithValue("@is_admin", userEntity.isAdmin);
            command.Parameters.AddWithValue("@status", userEntity.status);
            command.Parameters.AddWithValue("@update_at", userEntity.update_at);
            command.Parameters.AddWithValue("@create_at", userEntity.create_at);
            command.Parameters.AddWithValue("@update_by", userEntity.update_by);
            command.Parameters.AddWithValue("@create_by", userEntity.create_by);

            command.ExecuteNonQuery();
            Console.WriteLine("done!");

            return userEntity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        // throw new NotImplementedException();
    }

    public List<TransactionEntity> findUserTransactionHistory(string accountNumber)
    {
        var result = new List<TransactionEntity>();
        try
        {
            var connection = new MySqlConnection(MYSQL_CONNECTION_STRING);
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from transaction_history where status = 1 and account_send =" + accountNumber);
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
                var create_by = mySqlDataReader.GetDateTime("create_by");
                var update_by = mySqlDataReader.GetDateTime("update_by");

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

            Console.WriteLine("done!");
            connection.Close();
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        // throw new NotImplementedException();
    }

    public UserEntity updateInfo(UserEntity userEntity)
    {
        try
        {
            var connection = new MySqlConnection(MYSQL_CONNECTION_STRING);
            connection.Open();
            MySqlCommand command = new MySqlCommand("update users set first_name = @first_name, last_name = @last_name, email = @email, phone = @phone where user_id =" + userEntity.userId);
            command.Connection = connection;

            command.Parameters.AddWithValue("@first_name", userEntity.firstName);
            command.Parameters.AddWithValue("@last_name", userEntity.lastName);
            command.Parameters.AddWithValue("@email", userEntity.email);
            command.Parameters.AddWithValue("@phone", userEntity.phone);
            
            command.ExecuteNonQuery();

            Console.WriteLine("done!");
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        throw new NotImplementedException();
    }

    public UserEntity updatePassword(UserEntity userEntity)
    {
        try
        {
            var connection = new MySqlConnection(MYSQL_CONNECTION_STRING);
            connection.Open();
            MySqlCommand command = new MySqlCommand("update users set first_name = @first_name, last_name = @last_name, email = @email, phone = @phone where user_id =" + userEntity.userId);
            command.Connection = connection;
            //de sau
            
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        throw new NotImplementedException();
    }

    public UserEntity updateAmount(UserEntity userEntity)
    {
        try
        {
            var connection = new MySqlConnection(MYSQL_CONNECTION_STRING);
            connection.Open();
            MySqlCommand command = new MySqlCommand("update users set balance = @balance where user_id =" + userEntity.userId);
            command.Connection = connection;
            
            command.Parameters.AddWithValue("@balance", userEntity.balance);
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        throw new NotImplementedException();
    }

    public UserEntity getAmount(UserEntity userEntity)
    {
        throw new NotImplementedException();
    }

    public void showInfo(long id)
    {
        throw new NotImplementedException();
    }

    public double minusAmount(double amount)
    {
        throw new NotImplementedException();
    }

    public double plusAmount(double amount)
    {
        throw new NotImplementedException();
    }

    public void deleteTransaction(string id)
    {
        throw new NotImplementedException();
    }
}