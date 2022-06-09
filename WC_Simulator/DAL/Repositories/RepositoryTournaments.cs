using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC_Simulator.DAL.Repositories
{
    using WC_Simulator.DAL;
    class RepositoryTournaments
    {
        #region QUERIES
        private const string ALL_TOURNAMENT = "SELECT * FROM `tournament`";
        private const string ADD_TOURNAMENT = "INSERT INTO `tournament`(`id_tournament`, `id_user`) VALUES ";
        private const string DELETE_TOURNAMENT = "DELETE FROM `tournament` WHERE id_tournament = ";
        //private const string UPDATE_TOURNAMENT = "UPDATE `tournament` SET xx WHERE id_tournament = ";
        #endregion

        #region CRUD

        #endregion
    }
}
