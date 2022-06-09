using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC_Simulator.DAL.Repositories
{
    using WC_Simulator.DAL;
    class RepositoryMatches
    {
        #region QUERIES
        private const string ALL_MATCH = "SELECT * FROM `single_match`";
        private const string ADD_MATCH = "INSERT INTO `single_match`(`id_match`, `id_first_team`, `id_second_team`," +
            " `id_tournament`, `match_code`, `goals_first_team`, `goals_second_team`) VALUES ";
        private const string DELETE_MATCH = "DELETE FROM `single_match` WHERE id_match = ";
        //private const string UPDATE_MATCH = "UPDATE `single_match` SET xx WHERE id_match = ";
        #endregion

        #region CRUD

        #endregion
    }
}
