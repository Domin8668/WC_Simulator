using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC_Simulator.DAL.Repositories
{
    using WC_Simulator.DAL;
    class RepositoryTeams
    {
        #region QUERIES
        private const string ALL_TEAM = "SELECT * FROM `team`";
        private const string ADD_TEAM = "INSERT INTO `team`(`id_team`, `id_group`, `name`," +
            " `short_name`, `coach`, `def_factor`, `att_factor`) VALUES ";
        private const string DELETE_TEAM = "DELETE FROM `team` WHERE id_team = ";
        //private const string UPDATE_TEAM = "UPDATE `team` SET xx WHERE id_team = ";
        #endregion

        #region CRUD

        #endregion
    }
}
