using MySql.Data.MySqlClient;
using System;
using System.Text;
using WC_Simulator.Helpers.Hashing;

namespace WC_Simulator.DAL.Entities
{
    class User
    {
        #region Properties
        public uint? Id_user { get; set; }

        public string Login { get; set; }

        public byte[] Password { get; set; }

        public DateTime Creation_date { get; set; }

        public DateTime Last_log_date { get; set; }

        public string Security_question { get; set; }

        public byte[] Security_answer { get; set; }

        #endregion


        #region Constructors

        public User()
        {
            Id_user = null;
            Login = string.Empty;
            Password = new byte[0];
            Creation_date = new DateTime();
            Last_log_date = new DateTime();
            Security_question = string.Empty;
            Security_answer = new byte[32];
        }

        public User(MySqlDataReader reader)
        {
            Id_user = uint.Parse(reader["id_user"].ToString());
            Login = reader["login"].ToString();
            Password = (byte[])reader["password"];
            Creation_date = DateTime.Parse(reader["creation_date"].ToString());
            Last_log_date = DateTime.Parse(reader["last_log_date"].ToString());
            Security_question = reader["login"].ToString();
            Security_answer = (byte[])reader["security_answer"];
        }

        public User(uint id_user, string login, byte[] password, DateTime creation_date, DateTime last_log_date, string security_question, byte[] security_answer)
        {
            Id_user = id_user;
            Login = login;
            Password = password;
            Creation_date = creation_date;
            Last_log_date = last_log_date;
            Security_question = security_question;
            Security_answer = security_answer;
        }

        #endregion


        #region Methods

        public override string ToString()
        {
            return $"Nazwa użytkownika: {Login}, Data założenia konta: {Creation_date}, Ostatnie logowanie: {Last_log_date}";
        }

        //public string ToInsert()
        //{
        //    return $"('{Id_user}', '{Login}', '{Password}', '{DateTime.Now.ToString("yyyy-MM-dd")}', '{DateTime.Now.ToString("yyyy-MM-dd")}', '{Security_question}', '{Security_answer}')";
        //}

        public override bool Equals(object obj)
        {
            var user = obj as User;
            if (user is null) return false;
            //if (Id_user != user.Id_user) return false;
            if (Login.ToLower() != user.Login.ToLower()) return false;
            if (!new SHA256Hashing().MatchHashes(Password, user.Password)) return false;
            //if (Creation_date != user.Creation_date) return false;
            //if (Last_log_date != user.Last_log_date) return false;
            if (Security_question.ToLower() != user.Security_question.ToLower()) return false;
            if (!new SHA256Hashing().MatchHashes(Security_answer, user.Security_answer)) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

    }
}
