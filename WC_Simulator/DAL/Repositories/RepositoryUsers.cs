using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC_Simulator.DAL.Repositories
{
    using WC_Simulator.DAL;
    class RepositoryUsers
    {
        #region QUERIES
        private const string ALL_USER = "SELECT * FROM `user`";
        private const string ADD_USER = "INSERT INTO `user`(`id_user`, `login`, `password`," +
            " `creation_date`, `last_log_date`, `security_question`, `security_answer`) VALUES ";
        private const string DELETE_USER = "DELETE FROM `user` WHERE id_user = ";
        //private const string UPDATE_USER = "UPDATE `user` SET xx WHERE id_user = ";
        #endregion

        #region CRUD

        #endregion
    }
}
