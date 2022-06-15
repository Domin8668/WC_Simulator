using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using WC_Simulator.Helpers.Hashing;

namespace WC_Simulator.DAL.Entities
{
    class UserShort
    {
        #region Properties

        public string Login { get; set; }

        public byte[] Password { get; set; }
        
        #endregion


        #region Constructors

        public UserShort()
        {
            Login = string.Empty;
            Password = new byte[32];
        }

        public UserShort(MySqlDataReader reader)
        {
            Login = reader["login"].ToString();
            Password = (byte[])reader["password"];
        }

        #endregion


        #region Methods

        public override bool Equals(object obj)
        {
            var user = obj as User;
            if (user is null) return false;
            if (Login.ToLower() != user.Login.ToLower()) return false;
            if (!new SHA256Hashing().MatchHashes(Password, user.Password)) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }
}
