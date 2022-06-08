using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC_Simulator.DAL.Repositories
{
    using WC_Simulator.DAL;
    class RepositoryGroups
    {
        #region QUERIES
        private const string ALL_GROUP = "SELECT * FROM `single_group`";
        private const string ADD_GROUP = "INSERT INTO `single_group`(`id_group`, `id_first_pl_team`, `id_second_pl_team`, `id_tournament`, `letter`) VALUES ";
        private const string DELETE_GROUP = "DELETE FROM `single_group` WHERE id_group = ";
        //private const string UPDATE_GROUP = "UPDATE `single_group` SET xx WHERE id_group = ";
        #endregion

        #region CRUD

        #endregion
    }
}
