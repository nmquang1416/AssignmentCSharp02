using AssignmentCSharp02.Entity;
using MySqlConnector;

namespace AssignmentCSharp02.repository.admin;

public class AdminRepository : InterfaceAdminRepository
{
    public string MYSQL_CONNECTION_STRING = "server=127.0.0.1;uid=root;pwd=;database=spring_hero_bank";
    public AdminEntity save(AdminEntity adminEntity)
    {
        try
        {
            var connection = new MySqlConnection(MYSQL_CONNECTION_STRING);
            connection.Open();

            MySqlCommand command = new MySqlCommand(
                "insert into admins ( admin_name, admin_password, first_name, last_name, email, phone, birth, salt, is_admin, status, update_at, create_at, update_by, create_by) values (@admin_name, @admin_password, @fisrt_name, @last_name, @email, @phone, @birth, @salt, @is_admin, @status, @update_at, @create_at, @update_by, @create_by)");
            command.Connection = connection;

            command.Parameters.AddWithValue("@user_name", adminEntity.adminName);
            command.Parameters.AddWithValue("@user_password", adminEntity.adminPassword);
            command.Parameters.AddWithValue("@balance", adminEntity.firstName);
            command.Parameters.AddWithValue("@account_number", adminEntity.lastName);
            command.Parameters.AddWithValue("@email", adminEntity.email);
            command.Parameters.AddWithValue("@phone", adminEntity.phone);
            command.Parameters.AddWithValue("@phone", adminEntity.birth);
            command.Parameters.AddWithValue("@salt", adminEntity.salt);
            command.Parameters.AddWithValue("@is_admin", adminEntity.isAdmin);
            command.Parameters.AddWithValue("@status", adminEntity.status);
            command.Parameters.AddWithValue("@update_at", adminEntity.update_at);
            command.Parameters.AddWithValue("@create_at", adminEntity.create_at);
            command.Parameters.AddWithValue("@update_by", adminEntity.update_by);
            command.Parameters.AddWithValue("@create_by", adminEntity.create_by);

            command.ExecuteNonQuery();
            connection.Clone();

            return adminEntity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        throw new NotImplementedException();
    }
    public List<UserEntity> findAllUser()
    {
        var result = new List<UserEntity>();
        try
        {
            var connection = new MySqlConnection(MYSQL_CONNECTION_STRING);
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from users where status = 1  ");
            command.Connection = connection;
            MySqlDataReader mySqlDataReader = command.ExecuteReader();

            while (mySqlDataReader.Read())
            {
                var user_id = mySqlDataReader.GetInt64("user_id");
                var user_name = mySqlDataReader.GetString("user_name");
                var user_password = mySqlDataReader.GetString("user_password");
                var balance = mySqlDataReader.GetDouble("balance");
                var account_number = mySqlDataReader.GetString("account_number");
                var fisrt_name = mySqlDataReader.GetString("fisrt_name");
                var last_name = mySqlDataReader.GetString("last_name");
                var email = mySqlDataReader.GetString("email");
                var phone = mySqlDataReader.GetString("phone");
                var salt = mySqlDataReader.GetString("salt");
                var is_admin = mySqlDataReader.GetBoolean("is_admin");
                var status = mySqlDataReader.GetInt32("status");
                var update_at = mySqlDataReader.GetDateTime("update_at");
                var create_at = mySqlDataReader.GetDateTime("create_at");
                var update_by = mySqlDataReader.GetString("update_by");
                var create_by = mySqlDataReader.GetString("create_by");

                UserEntity userEntity = new UserEntity();
                userEntity.userId = user_id;
                userEntity.userName = user_name;
                userEntity.userPassword = user_password;
                userEntity.balance = balance;
                userEntity.accountNumber = account_number;
                userEntity.firstName = fisrt_name;
                userEntity.lastName = last_name;
                userEntity.email = email;
                userEntity.phone = phone;
                userEntity.salt = salt;
                userEntity.isAdmin = is_admin;
                userEntity.status = status;
                userEntity.update_at = update_at;
                userEntity.create_at = create_at;
                userEntity.update_by = update_by;
                userEntity.create_by = create_by;
                
                result.Add(userEntity);
            }
            connection.Close();
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        throw new NotImplementedException();
    }

    public List<AdminEntity> findAllAdmin()
    {
        var result = new List<AdminEntity>();
        try
        {
            var connection = new MySqlConnection(MYSQL_CONNECTION_STRING);
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from admins");
            command.Connection = connection;
            MySqlDataReader mySqlDataReader = command.ExecuteReader();
            
            while (mySqlDataReader.Read())
            {
                var admin_id  = mySqlDataReader.GetInt64("admin_id ");
                var admin_name = mySqlDataReader.GetString("admin_name");
                var admin_password = mySqlDataReader.GetString("admin_password");
                var fisrt_name = mySqlDataReader.GetString("fisrt_name");
                var last_name = mySqlDataReader.GetString("last_name");
                var email= mySqlDataReader.GetString("email");
                var phone= mySqlDataReader.GetString("phone");
                var is_admin= mySqlDataReader.GetBoolean("is_admin");
                var status= mySqlDataReader.GetInt32("status");
                var salt = mySqlDataReader.GetString("salt");
                var create_at = mySqlDataReader.GetDateTime("create_at");
                var update_at = mySqlDataReader.GetDateTime("update_at");
                var create_by = mySqlDataReader.GetString("create_by");
                var update_by = mySqlDataReader.GetString("update_by");


                AdminEntity adminEntity = new AdminEntity();
                adminEntity.adminId = admin_id;
                adminEntity.adminName = admin_name;
                adminEntity.adminPassword = admin_password;
                adminEntity.firstName = fisrt_name;
                adminEntity.lastName = last_name;
                adminEntity.email = email;
                adminEntity.phone = phone;
                adminEntity.isAdmin = is_admin;
                adminEntity.status = status;
                adminEntity.salt = salt;
                adminEntity.create_at = create_at;
                adminEntity.update_at = update_at;
                adminEntity.create_by = create_by;
                adminEntity.update_by = update_by;
                
                result.Add(adminEntity);
            }

            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }

    public UserEntity findUserByLastName(string lastName)
    {
        try
        {
            var connection = new MySqlConnection(MYSQL_CONNECTION_STRING);
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from users where status = 1 and last_name =" + lastName);
            command.Connection = connection;
            MySqlDataReader mySqlDataReader = command.ExecuteReader();
            // mySqlDataReader.Read();

            mySqlDataReader.Read();
            var user_id = mySqlDataReader.GetInt64("user_id");
            var user_name = mySqlDataReader.GetString("user_name");
            var user_password = mySqlDataReader.GetString("user_password");
            var balance = mySqlDataReader.GetDouble("balance");
            var account_number = mySqlDataReader.GetString("account_number");
            var fisrt_name = mySqlDataReader.GetString("fisrt_name");
            var last_name = mySqlDataReader.GetString("last_name");
            var email = mySqlDataReader.GetString("email");
            var phone = mySqlDataReader.GetString("phone");
            var salt = mySqlDataReader.GetString("salt");
            var is_admin = mySqlDataReader.GetBoolean("is_admin");
            var status = mySqlDataReader.GetInt32("status");
            var update_at = mySqlDataReader.GetDateTime("update_at");
            var create_at = mySqlDataReader.GetDateTime("create_at");
            var update_by = mySqlDataReader.GetString("update_by");
            var create_by = mySqlDataReader.GetString("create_by");

            UserEntity userEntity = new UserEntity();
            userEntity.userId = user_id;
            userEntity.userName = user_name;
            userEntity.userPassword = user_password;
            userEntity.balance = balance;
            userEntity.accountNumber = account_number;
            userEntity.firstName = fisrt_name;
            userEntity.lastName = last_name;
            userEntity.email = email;
            userEntity.phone = phone;
            userEntity.salt = salt;
            userEntity.isAdmin = is_admin;
            userEntity.status = status;
            userEntity.update_at = update_at;
            userEntity.create_at = create_at;
            userEntity.update_by = update_by;
            userEntity.create_by = create_by;
            
            connection.Close();
            return userEntity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        throw new NotImplementedException();
    }

    public UserEntity findUserByPhone(string phone)
    {
        try
        {
            var connection = new MySqlConnection(MYSQL_CONNECTION_STRING);
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from users where status = 1 and phone =" + phone);
            command.Connection = connection;
            MySqlDataReader mySqlDataReader = command.ExecuteReader();
            // mySqlDataReader.Read();

            mySqlDataReader.Read();
            var user_id = mySqlDataReader.GetInt64("user_id");
            var user_name = mySqlDataReader.GetString("user_name");
            var user_password = mySqlDataReader.GetString("user_password");
            var balance = mySqlDataReader.GetDouble("balance");
            var account_number = mySqlDataReader.GetString("account_number");
            var fisrt_name = mySqlDataReader.GetString("fisrt_name");
            var last_name = mySqlDataReader.GetString("last_name");
            var email = mySqlDataReader.GetString("email");
            phone = mySqlDataReader.GetString("phone");
            var salt = mySqlDataReader.GetString("salt");
            var is_admin = mySqlDataReader.GetBoolean("is_admin");
            var status = mySqlDataReader.GetInt32("status");
            var update_at = mySqlDataReader.GetDateTime("update_at");
            var create_at = mySqlDataReader.GetDateTime("create_at");
            var update_by = mySqlDataReader.GetString("update_by");
            var create_by = mySqlDataReader.GetString("create_by");

            UserEntity userEntity = new UserEntity();
            userEntity.userId = user_id;
            userEntity.userName = user_name;
            userEntity.userPassword = user_password;
            userEntity.balance = balance;
            userEntity.accountNumber = account_number;
            userEntity.firstName = fisrt_name;
            userEntity.lastName = last_name;
            userEntity.email = email;
            userEntity.phone = phone;
            userEntity.salt = salt;
            userEntity.isAdmin = is_admin;
            userEntity.status = status;
            userEntity.update_at = update_at;
            userEntity.create_at = create_at;
            userEntity.update_by = update_by;
            userEntity.create_by = create_by;
            
            connection.Close();
            return userEntity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        throw new NotImplementedException();
    }

    public UserEntity findUserByAccountNumber(string accountNumber)
    {
        try
        {
            var connection = new MySqlConnection(MYSQL_CONNECTION_STRING);
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from users where status = 1 and phone =" + accountNumber);
            command.Connection = connection;
            MySqlDataReader mySqlDataReader = command.ExecuteReader();
            // mySqlDataReader.Read();

            mySqlDataReader.Read();
            var user_id = mySqlDataReader.GetInt64("user_id");
            var user_name = mySqlDataReader.GetString("user_name");
            var user_password = mySqlDataReader.GetString("user_password");
            var balance = mySqlDataReader.GetDouble("balance");
            var account_number = mySqlDataReader.GetString("account_number");
            var fisrt_name = mySqlDataReader.GetString("fisrt_name");
            var last_name = mySqlDataReader.GetString("last_name");
            var email = mySqlDataReader.GetString("email");
            var phone = mySqlDataReader.GetString("phone");
            var salt = mySqlDataReader.GetString("salt");
            var is_admin = mySqlDataReader.GetBoolean("is_admin");
            var status = mySqlDataReader.GetInt32("status");
            var update_at = mySqlDataReader.GetDateTime("update_at");
            var create_at = mySqlDataReader.GetDateTime("create_at");
            var update_by = mySqlDataReader.GetString("update_by");
            var create_by = mySqlDataReader.GetString("create_by");

            UserEntity userEntity = new UserEntity();
            userEntity.userId = user_id;
            userEntity.userName = user_name;
            userEntity.userPassword = user_password;
            userEntity.balance = balance;
            userEntity.accountNumber = account_number;
            userEntity.firstName = fisrt_name;
            userEntity.lastName = last_name;
            userEntity.email = email;
            userEntity.phone = phone;
            userEntity.salt = salt;
            userEntity.isAdmin = is_admin;
            userEntity.status = status;
            userEntity.update_at = update_at;
            userEntity.create_at = create_at;
            userEntity.update_by = update_by;
            userEntity.create_by = create_by;
            
            connection.Close();
            return userEntity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        throw new NotImplementedException();
    }

    public List<TransactionEntity> findTransactionByAccountNumber(string accountNumber)
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
        throw new NotImplementedException();
    }


    public UserEntity saveNewUser(UserEntity userEntity)
    {
        try
        {
            var connection = new MySqlConnection(MYSQL_CONNECTION_STRING);
            connection.Open();

            MySqlCommand command = new MySqlCommand(
                "insert into users ( user_name, user_password, balance, account_number, fisrt_name, last_name, email, phone, salt, is_admin, status, update_at, create_at, update_by, create_by) values (@user_name, @user_password, @balance, @account_number, @fisrt_name, @last_name, @email, @phone, @salt, @is_admin, @status, @update_at, @create_at, @update_by, @create_by)");
            command.Connection = connection;

            command.Parameters.AddWithValue("@user_name", userEntity.userName);
            command.Parameters.AddWithValue("@user_password", userEntity.userPassword);
            command.Parameters.AddWithValue("@balance", userEntity.balance);
            command.Parameters.AddWithValue("@account_number", userEntity.accountNumber);
            command.Parameters.AddWithValue("@fisrt_name", userEntity.firstName);
            command.Parameters.AddWithValue("@last_name", userEntity.lastName);
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
            connection.Clone();

            return userEntity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        throw new NotImplementedException();
    }

    public UserEntity updateStatusUser(UserEntity userEntity)
    {
        try
        {
            var connection = new MySqlConnection(MYSQL_CONNECTION_STRING);
            connection.Open();
            MySqlCommand command = new MySqlCommand("update users set status = "+ userEntity.status + "where user_id =" + userEntity.userId);
            command.Connection = connection;
            
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        throw new NotImplementedException();
    }

    public AdminEntity update(AdminEntity adminEntity)
    {
        try
        {
            var connection = new MySqlConnection(MYSQL_CONNECTION_STRING);
            connection.Open();
            MySqlCommand command = new MySqlCommand("update users set admin_name = @admin_name, admin_password = @admin_password, fisrt_name = @fisrt_name, last_name = @last_name, email = @email, phone = @phone, email = @email, is_admin = @is_admin, status = @status, salt = @salt, update_at = @update_at, create_at = @create_at, update_by = @update_by, create_by = @create_by");
            command.Connection = connection;
            
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        throw new NotImplementedException();
    }
    
    private System.Security.Cryptography.MD5 _md5 = System.Security.Cryptography.MD5.Create();
    
    public string GenerateSalt()
    {
        Random random = new Random(); 
        String characterPool = "abcdefghijklmnopqrstuvwxyz0123456789"; 
        int size = 5; 
        String randomstring = ""; 
        for (int i = 0; i < size; i++) 
        { 
            int x = random.Next(characterPool.Length); 
            randomstring = randomstring + characterPool[x]; 
        } 
        return randomstring;
    }
    public string HashPassword(string originPassword, string salt)
    {
        string hashInput = originPassword + salt;
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(hashInput);
        byte[] hashBytes = _md5.ComputeHash(inputBytes);
        return Convert.ToHexString(hashBytes); 
    }
    public bool ComparePassword(string hashPassword, string originPassword, string salt)
    {
        string newHash = HashPassword(originPassword, salt);
        return newHash.Equals(hashPassword);
    }
}