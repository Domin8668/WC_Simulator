using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using WC_Simulator.DAL.Entities;
using WC_Simulator.DAL.Repositories;

namespace WC_Simulator.Model
{
    public class MainModel
    {
        /// <summary>
        /// Mechanizm w Modelu zapewnia możliwość wykonywania operacji na obiektach z automatycznym
        /// aktualizowaniem ich odpowiedników w bazie danych. Edycja np. Playera powoduje aktualizację
        /// bazy danych oraz aktualizuje obiekt tego Playera w kolekcji obiektów.
        /// </summary>
        internal void ValidateUser()
        {
            throw new NotImplementedException();
        }
        // kolekcje obiektów poszczególnych zbiorów encji

        //public ObservableCollection<Player> AllPlayers { get; set; } = new ObservableCollection<Player>();
        //public ObservableCollection<Single_group> AllGroups { get; set; } = new ObservableCollection<Single_group>();
        //public ObservableCollection<Single_match> AllMatches { get; set; } = new ObservableCollection<Single_match>();
        //public ObservableCollection<Team> AllTeams { get; set; } = new ObservableCollection<Team>();
        //public ObservableCollection<Tournament> AllTournaments { get; set; } = new ObservableCollection<Tournament>();

        //public MainModel()
        //{
        //    //pobranie danych z bazy do kolekcji za pomocą Repozytoriów

        //    //var groups = RepositoryGroups.LoadGroup();
        //    //foreach (var g in groups)
        //    //    AllGroups.Add(g);
        //    //var matches = RepositoryMatches.LoadMatch();
        //    //foreach (var m in matches)
        //    //    AllMatches.Add(m);
        //    //var players = RepositoryPlayers.Load();
        //    //foreach (var p in players)
        //    //    AllPlayers.Add(p);
        //    //var teams = RepositoryTeams.LoadTeam();
        //    //foreach (var t in teams)
        //    //    AllTeams.Add(t);
        //}

    }
}
