using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using WC_Simulator.DAL.Entities;
using WC_Simulator.DAL.Repositories;
using WC_Simulator.Helpers.Stores;
using WC_Simulator.Model;
using WC_Simulator.ViewModel.BaseClasses;

namespace WC_Simulator.ViewModel
{
    class GroupsViewModel : BaseViewModel
    {
        #region Variables

        //private ObservableCollection<TeamInGroup> _teamsA;
        //private ObservableCollection<TeamInGroup> _teamsB;
        //private ObservableCollection<TeamInGroup> _teamsC;
        //private ObservableCollection<TeamInGroup> _teamsD;
        //private ObservableCollection<TeamInGroup> _teamsE;
        //private ObservableCollection<TeamInGroup> _teamsF;
        //private ObservableCollection<TeamInGroup> _teamsG;
        //private ObservableCollection<TeamInGroup> _teamsH;

        //private ObservableCollection<ObservableCollection<TeamInGroup>> _groupsTeams;
        //private ObservableCollection<ObservableCollection<Single_match>> _groupsMatches;

        //private int _currentGroup;

        //private ObservableCollection<Team> _allTeams;

        //private Schedule _scheduleInfo;

        //private ObservableCollection<Single_match> _matchesA;
        //private ObservableCollection<Single_match> _matchesB;
        //private ObservableCollection<Single_match> _matchesC;
        //private ObservableCollection<Single_match> _matchesD;
        //private ObservableCollection<Single_match> _matchesE;
        //private ObservableCollection<Single_match> _matchesF;
        //private ObservableCollection<Single_match> _matchesG;
        //private ObservableCollection<Single_match> _matchesH;
        public enum Alphabet
        {
            A,
            B,
            C,
            D,
            E,
            F,
            G,
            H
        }


        #endregion


        #region Constructor

        public GroupsViewModel(MainModel model, NavigationStore navigationStore)
        {
            Model = model;
            NavigationStore = navigationStore;

            Model.CurrentGroup = 0;
            //GroupsTeams = new ObservableCollection<ObservableCollection<TeamInGroup>>();

            //Prepare_Teams();
            //GroupsTeams.Add(TeamsA);
            //GroupsTeams.Add(TeamsB);
            //GroupsTeams.Add(TeamsC);
            //GroupsTeams.Add(TeamsD);
            //GroupsTeams.Add(TeamsE);
            //GroupsTeams.Add(TeamsF);
            //GroupsTeams.Add(TeamsG);
            //GroupsTeams.Add(TeamsH);

            //GroupsMatches = new ObservableCollection<ObservableCollection<Single_match>>();
            //PrepareMatchesA();
            //PrepareMatchesB();
            //PrepareMatchesC();
            //PrepareMatchesD();
            //PrepareMatchesE();
            //PrepareMatchesF();
            //PrepareMatchesG();
            //PrepareMatchesH();

            // prepare standing poza konstruktorem zakomentowane bo obsluguje event aktualizwanie, ale placeholdery trza dodac 
            //TeamsA = PrepareStanding(MatchesA, 0);
            //TeamsB = PrepareStanding(MatchesB, 1);
            //TeamsC = PrepareStanding(MatchesC, 2);
            //TeamsD = PrepareStanding(MatchesD, 3);
            //TeamsE = PrepareStanding(MatchesE, 4);
            //TeamsF = PrepareStanding(MatchesF, 5);
            //TeamsG = PrepareStanding(MatchesG, 6);
            //TeamsH = PrepareStanding(MatchesH, 7);

            //CurrentGroup = 0;
        }

        #endregion


        #region Properties

        //public ObservableCollection<Team> AllTeams
        //{
        //    get { return _allTeams; }
        //    set
        //    {
        //        _allTeams = value;
        //        OnPropertyChanged(nameof(AllTeams));
        //    }
        //}
        //public ObservableCollection<TeamInGroup> TeamsA
        //{
        //    get { return _teamsA; }
        //    set
        //    {
        //        _teamsA = value;
        //        OnPropertyChanged(nameof(TeamsA));
        //    }
        //}
        //public ObservableCollection<TeamInGroup> TeamsB
        //{
        //    get { return _teamsB; }
        //    set
        //    {
        //        _teamsB = value;
        //        OnPropertyChanged(nameof(TeamsB));
        //    }
        //}
        //public ObservableCollection<TeamInGroup> TeamsC
        //{
        //    get { return _teamsC; }
        //    set
        //    {
        //        _teamsC = value;
        //        OnPropertyChanged(nameof(TeamsC));
        //    }
        //}
        //public ObservableCollection<TeamInGroup> TeamsD
        //{
        //    get { return _teamsD; }
        //    set
        //    {
        //        _teamsD = value;
        //        OnPropertyChanged(nameof(TeamsD));
        //    }
        //}
        //public ObservableCollection<TeamInGroup> TeamsE
        //{
        //    get { return _teamsE; }
        //    set
        //    {
        //        _teamsE = value;
        //        OnPropertyChanged(nameof(TeamsE));
        //    }
        //}
        //public ObservableCollection<TeamInGroup> TeamsF
        //{
        //    get { return _teamsF; }
        //    set
        //    {
        //        _teamsF = value;
        //        OnPropertyChanged(nameof(TeamsF));
        //    }
        //}
        //public ObservableCollection<TeamInGroup> TeamsG
        //{
        //    get { return _teamsG; }
        //    set
        //    {
        //        _teamsG = value;
        //        OnPropertyChanged(nameof(TeamsG));
        //    }
        //}
        //public ObservableCollection<TeamInGroup> TeamsH
        //{
        //    get { return _teamsH; }
        //    set
        //    {
        //        _teamsH = value;
        //        OnPropertyChanged(nameof(TeamsH));
        //    }
        //}

        //public Schedule ScheduleInfo
        //{
        //    get { return _scheduleInfo; }
        //    set
        //    {
        //        _scheduleInfo = value;
        //        OnPropertyChanged(nameof(Schedule));
        //    }
        //}

        //public ObservableCollection<Single_match> MatchesA
        //{
        //    get { return _matchesA; }
        //    set
        //    {
        //        _matchesA = value;
        //        OnPropertyChanged(nameof(MatchesA));
        //    }
        //}
        //public ObservableCollection<Single_match> MatchesB
        //{
        //    get { return _matchesB; }
        //    set
        //    {
        //        _matchesB = value;
        //        OnPropertyChanged(nameof(MatchesB));
        //    }
        //}
        //public ObservableCollection<Single_match> MatchesC
        //{
        //    get { return _matchesC; }
        //    set
        //    {
        //        _matchesC = value;
        //        OnPropertyChanged(nameof(MatchesC));
        //    }
        //}
        //public ObservableCollection<Single_match> MatchesD
        //{
        //    get { return _matchesD; }
        //    set
        //    {
        //        _matchesD = value;
        //        OnPropertyChanged(nameof(MatchesD));
        //    }
        //}
        //public ObservableCollection<Single_match> MatchesE
        //{
        //    get { return _matchesE; }
        //    set
        //    {
        //        _matchesE = value;
        //        OnPropertyChanged(nameof(MatchesE));
        //    }
        //}
        //public ObservableCollection<Single_match> MatchesF
        //{
        //    get { return _matchesF; }
        //    set
        //    {
        //        _matchesF = value;
        //        OnPropertyChanged(nameof(MatchesF));
        //    }
        //}
        //public ObservableCollection<Single_match> MatchesG
        //{
        //    get { return _matchesG; }
        //    set
        //    {
        //        _matchesG = value;
        //        OnPropertyChanged(nameof(MatchesG));
        //    }
        //}
        //public ObservableCollection<Single_match> MatchesH
        //{
        //    get { return _matchesH; }
        //    set
        //    {
        //        _matchesH = value;
        //        OnPropertyChanged(nameof(MatchesH));
        //    }
        //}

        //public int CurrentGroup
        //{
        //    get { return _currentGroup; }
        //    set
        //    {
        //        _currentGroup = value;
        //        OnPropertyChanged(nameof(CurrentGroup));

        //    }
        //}

        //public ObservableCollection<ObservableCollection<Single_match>> GroupsMatches
        //{
        //    get { return _groupsMatches; }
        //    set
        //    {
        //        _groupsMatches = value;
        //        OnPropertyChanged(nameof(GroupsMatches));
        //    }
        //}
        //public ObservableCollection<ObservableCollection<TeamInGroup>> GroupsTeams
        //{
        //    get { return _groupsTeams; }
        //    set
        //    {
        //        _groupsTeams = value;
        //        OnPropertyChanged(nameof(GroupsTeams));
        //    }
        //}

        #endregion


        #region Methods

        //public void Prepare_Teams()
        //{
        //    AllTeams = new ObservableCollection<Team> {
        //    new Team(1, "Katar", "QAT", "Félix Sánchez Bas", (float)0.5, (float)0.5),
        //    new Team(1, "Ekwador", "ECU", "Gustavo Alfaro", (float)0.5, (float)0.5),
        //    new Team(1, "Senegal", "SEN", "Aliou Cissé", (float)0.5, (float)0.5),
        //    new Team(1, "Holandia", "NED", "Louis van Gaal", (float)0.5, (float)0.5),

        //    new Team(2, "Anglia", "ENG", "Gareth Southgate", (float)0.5, (float)0.5),
        //    new Team(2, "Iran", "IRN", "Dragan Skočić", (float)0.5, (float)0.5),
        //    new Team(2, "Stany Zjednoczone", "USA", "Gregg Berhalter", (float)0.5, (float)0.5),
        //    new Team(2, "Walia", "WAL", "Robert Page", (float)0.5, (float)0.5),

        //    new Team(3, "Argentyna", "ARG", "Lionel Scaloni", (float)0.5, (float)0.5),
        //    new Team(3, "Arabia Saudyjska", "KSA", "Hervé Renard", (float)0.5, (float)0.5),
        //    new Team(3, "Meksyk", "MEX", "Gerardo Martino", (float)0.5, (float)0.5),
        //    new Team(3, "Polska", "POL", "Czesław Michniewicz", (float)0.5, (float)0.5),

        //    new Team(4, "Francja", "FRA", "Didier Deschamps", (float)0.5, (float)0.5),
        //    new Team(4, "Australia", "AUS", "Graham Arnold", (float)0.5, (float)0.5),
        //    new Team(4, "Dania", "DEN", "Kasper Hjulmand", (float)0.5, (float)0.5),
        //    new Team(4, "Tunezja", "TUN", "Mondher Kebaier", (float)0.5, (float)0.5),

        //    new Team(5, "Hiszpania", "ESP", "Luis Enrique", (float)0.5, (float)0.5),
        //    new Team(5, "Kostaryka", "CRC", "Luis Fernando Suárez", (float)0.5, (float)0.5),
        //    new Team(5, "Niemcy", "GER", "Hans-Dieter Flick", (float)0.5, (float)0.5),
        //    new Team(5, "Japonia", "JPN", "Hajime Moriyasu", (float)0.5, (float)0.5),

        //    new Team(6, "Belgia", "BEL", "Roberto Martínez", (float)0.5, (float)0.5),
        //    new Team(6, "Kanada", "CAN", "John Herdman", (float)0.5, (float)0.5),
        //    new Team(6, "Maroko", "MAR", "Vahid Halilhodžić", (float)0.5, (float)0.5),
        //    new Team(6, "Chorwacja", "CRO", "Zlatko Dalić", (float)0.5, (float)0.5),

        //    new Team(7, "Brazylia", "BRA", "Tite", (float)0.5, (float)0.5),
        //    new Team(7, "Serbia", "SRB", "Dragan Stojković", (float)0.5, (float)0.5),
        //    new Team(7, "Szwajcaria", "SUI", "Murat Yakın", (float)0.5, (float)0.5),
        //    new Team(7, "Kamerun", "CMR", "Rigobert Song", (float)0.5, (float)0.5),

        //    new Team(8, "Portugalia", "POR", "Fernando Santos", (float)0.5, (float)0.5),
        //    new Team(8, "Ghana", "GHA", "Otto Addo", (float)0.5, (float)0.5),
        //    new Team(8, "Urugwaj", "URU", "Diego Alonso", (float)0.5, (float)0.5),
        //    new Team(8, "Korea Południowa", "KOR", "Paulo Bento", (float)0.5, (float)0.5)
        //    };
        //}
        //public void PrepareMatchesA()
        //{
        //    int i = 0 * 4;
        //    MatchesA = new ObservableCollection<Single_match>();

        //    MatchesA.Add(new Single_match(1, AllTeams[i], AllTeams[i + 1], 0, null, null));
        //    MatchesA.Add(new Single_match(1, AllTeams[i + 2], AllTeams[i + 3], 1, null, null));

        //    MatchesA.Add(new Single_match(1, AllTeams[i], AllTeams[i + 2], 17, null, null));
        //    MatchesA.Add(new Single_match(1, AllTeams[i + 3], AllTeams[i + 1], 18, null, null));

        //    MatchesA.Add(new Single_match(1, AllTeams[i + 3], AllTeams[i], 35, null, null));
        //    MatchesA.Add(new Single_match(1, AllTeams[i + 1], AllTeams[i + 2], 34, null, null));
        //    GroupsMatches.Add(MatchesA);

        //}
        //public void PrepareMatchesB()
        //{
        //    int i = 1 * 4;
        //    MatchesB = new ObservableCollection<Single_match>();

        //    MatchesB.Add(new Single_match(1, AllTeams[i], AllTeams[i + 1], 2, 10, 1));
        //    MatchesB.Add(new Single_match(1, AllTeams[i + 2], AllTeams[i + 3], 3, 4, 0));

        //    MatchesB.Add(new Single_match(1, AllTeams[i], AllTeams[i + 2], 19, 1, 4));
        //    MatchesB.Add(new Single_match(1, AllTeams[i + 3], AllTeams[i + 1], 16, 2, 2));

        //    MatchesB.Add(new Single_match(1, AllTeams[i + 3], AllTeams[i], 32, 3, 3));
        //    MatchesB.Add(new Single_match(1, AllTeams[i + 1], AllTeams[i + 2], 33, 2, 1));
        //    GroupsMatches.Add(MatchesB);

        //}
        //public void PrepareMatchesC()
        //{
        //    int i = 2 * 4;
        //    MatchesC = new ObservableCollection<Single_match>();

        //    MatchesC.Add(new Single_match(1, AllTeams[i], AllTeams[i + 1], 7, 0, 0));
        //    MatchesC.Add(new Single_match(1, AllTeams[i + 2], AllTeams[i + 3], 6, 0, 0));

        //    MatchesC.Add(new Single_match(1, AllTeams[i], AllTeams[i + 2], 23, 0, 0));
        //    MatchesC.Add(new Single_match(1, AllTeams[i + 3], AllTeams[i + 1], 21, 0, 0));

        //    MatchesC.Add(new Single_match(1, AllTeams[i + 3], AllTeams[i], 38, 0, 0));
        //    MatchesC.Add(new Single_match(1, AllTeams[i + 1], AllTeams[i + 2], 39, 0, 0));
        //    GroupsMatches.Add(MatchesC);

        //}
        //public void PrepareMatchesD()
        //{
        //    int i = 3 * 4;
        //    MatchesD = new ObservableCollection<Single_match>();

        //    MatchesD.Add(new Single_match(1, AllTeams[i], AllTeams[i + 1], 4, 1, 3));
        //    MatchesD.Add(new Single_match(1, AllTeams[i + 2], AllTeams[i + 3], 5, 2, 4));

        //    MatchesD.Add(new Single_match(1, AllTeams[i], AllTeams[i + 2], 22, 1, 2));
        //    MatchesD.Add(new Single_match(1, AllTeams[i + 3], AllTeams[i + 1], 20, 2, 0));

        //    MatchesD.Add(new Single_match(1, AllTeams[i + 3], AllTeams[i], 36, 0, 0));
        //    MatchesD.Add(new Single_match(1, AllTeams[i + 1], AllTeams[i + 2], 37, 2, 1));
        //    GroupsMatches.Add(MatchesD);

        //}
        //public void PrepareMatchesE()
        //{
        //    int i = 4 * 4;
        //    MatchesE = new ObservableCollection<Single_match>();

        //    MatchesE.Add(new Single_match(1, AllTeams[i], AllTeams[i + 1], 9, 1, 3));
        //    MatchesE.Add(new Single_match(1, AllTeams[i + 2], AllTeams[i + 3], 10, 2, 4));

        //    MatchesE.Add(new Single_match(1, AllTeams[i], AllTeams[i + 2], 27, 1, 2));
        //    MatchesE.Add(new Single_match(1, AllTeams[i + 3], AllTeams[i + 1], 24, 2, 0));

        //    MatchesE.Add(new Single_match(1, AllTeams[i + 3], AllTeams[i], 42, 0, 0));
        //    MatchesE.Add(new Single_match(1, AllTeams[i + 1], AllTeams[i + 2], 43, 2, 1));
        //    GroupsMatches.Add(MatchesE);

        //}
        //public void PrepareMatchesF()
        //{
        //    int i = 5 * 4;
        //    MatchesF = new ObservableCollection<Single_match>();

        //    MatchesF.Add(new Single_match(1, AllTeams[i], AllTeams[i + 1], 8, 1, 3));
        //    MatchesF.Add(new Single_match(1, AllTeams[i + 2], AllTeams[i + 3], 11, 2, 4));

        //    MatchesF.Add(new Single_match(1, AllTeams[i], AllTeams[i + 2], 25, 1, 2));
        //    MatchesF.Add(new Single_match(1, AllTeams[i + 3], AllTeams[i + 1], 26, 2, 0));

        //    MatchesF.Add(new Single_match(1, AllTeams[i + 3], AllTeams[i], 40, 0, 0));
        //    MatchesF.Add(new Single_match(1, AllTeams[i + 1], AllTeams[i + 2], 41, 2, 1));
        //    GroupsMatches.Add(MatchesF);

        //}
        //public void PrepareMatchesG()
        //{
        //    int i = 6 * 4;
        //    MatchesG = new ObservableCollection<Single_match>();

        //    MatchesG.Add(new Single_match(1, AllTeams[i], AllTeams[i + 1], 15, 2, 3));
        //    MatchesG.Add(new Single_match(1, AllTeams[i + 2], AllTeams[i + 3], 12, 1, 2));

        //    MatchesG.Add(new Single_match(1, AllTeams[i], AllTeams[i + 2], 30, 2, 1));
        //    MatchesG.Add(new Single_match(1, AllTeams[i + 3], AllTeams[i + 1], 28, 0, 0));

        //    MatchesG.Add(new Single_match(1, AllTeams[i + 3], AllTeams[i], 47, 2, 5));
        //    MatchesG.Add(new Single_match(1, AllTeams[i + 1], AllTeams[i + 2], 46, 3, 3));
        //    GroupsMatches.Add(MatchesG);


        //}
        //public void PrepareMatchesH()
        //{
        //    int i = 7 * 4;
        //    MatchesH = new ObservableCollection<Single_match>();

        //    MatchesH.Add(new Single_match(1, AllTeams[i], AllTeams[i + 1], 14, 1, 3));
        //    MatchesH.Add(new Single_match(1, AllTeams[i + 2], AllTeams[i + 3], 13, 2, 4));

        //    MatchesH.Add(new Single_match(1, AllTeams[i], AllTeams[i + 2], 31, 1, 2));
        //    MatchesH.Add(new Single_match(1, AllTeams[i + 3], AllTeams[i + 1], 29, 2, 0));

        //    MatchesH.Add(new Single_match(1, AllTeams[i + 3], AllTeams[i], 45, 0, 0));
        //    MatchesH.Add(new Single_match(1, AllTeams[i + 1], AllTeams[i + 2], 44, 2, 1));
        //    GroupsMatches.Add(MatchesH);
        //}

        public ObservableCollection<TeamInGroup> PrepareStanding(ObservableCollection<Single_match> groupMatches, int group)
        {
            // matches gf ga points
            var goalsfor = new int[4] { 0, 0, 0, 0 };
            var goalsagainst = new int[4] { 0, 0, 0, 0 };
            var points = new int[4] { 0, 0, 0, 0 };
            //1
            goalsfor[0] = (int)groupMatches[0].Goals_first_team + (int)groupMatches[2].Goals_first_team + (int)groupMatches[4].Goals_second_team;
            goalsagainst[0] = (int)groupMatches[0].Goals_second_team + (int)groupMatches[2].Goals_second_team + (int)groupMatches[4].Goals_first_team;
            points[0] = Points_for_match(groupMatches[0], 0) + Points_for_match(groupMatches[2], 0) + Points_for_match(groupMatches[4], 1);
            //2
            goalsfor[1] = (int)groupMatches[0].Goals_second_team + (int)groupMatches[3].Goals_second_team + (int)groupMatches[5].Goals_first_team;
            goalsagainst[1] = (int)groupMatches[0].Goals_first_team + (int)groupMatches[3].Goals_first_team + (int)groupMatches[5].Goals_second_team;
            points[1] = Points_for_match(groupMatches[0], 1) + Points_for_match(groupMatches[3], 1) + Points_for_match(groupMatches[5], 0);
            //3
            goalsfor[2] = (int)groupMatches[1].Goals_first_team + (int)groupMatches[2].Goals_second_team + (int)groupMatches[5].Goals_second_team;
            goalsagainst[2] = (int)groupMatches[1].Goals_second_team + (int)groupMatches[2].Goals_first_team + (int)groupMatches[5].Goals_first_team;
            points[2] = Points_for_match(groupMatches[1], 0) + Points_for_match(groupMatches[2], 1) + Points_for_match(groupMatches[5], 1);
            //4
            goalsfor[3] = (int)groupMatches[1].Goals_second_team + (int)groupMatches[3].Goals_first_team + (int)groupMatches[4].Goals_first_team;
            goalsagainst[3] = (int)groupMatches[1].Goals_first_team + (int)groupMatches[3].Goals_second_team + (int)groupMatches[4].Goals_second_team;
            points[3] = Points_for_match(groupMatches[1], 1) + Points_for_match(groupMatches[3], 0) + Points_for_match(groupMatches[4], 0);

            var teams_list = new List<TeamInGroup>
            {
                new TeamInGroup(Model.AllTeams[group * 4], 3, goalsfor[0], goalsagainst[0], points[0]),
                new TeamInGroup(Model.AllTeams[group * 4 + 1], 3, goalsfor[1], goalsagainst[1], points[1]),
                new TeamInGroup(Model.AllTeams[group * 4 + 2], 3, goalsfor[2], goalsagainst[2], points[2]),
                new TeamInGroup(Model.AllTeams[group * 4 + 3], 3, goalsfor[3], goalsagainst[3], points[3])
            };

            teams_list = teams_list.Select(p => p).OrderByDescending(p => p.Points).ThenByDescending(p => Math.Abs(p.GF - p.GA)).ThenByDescending(p => p.GF).ToList();

            for (int i = 0; i < teams_list.Count; i++)
            {
                teams_list[i].Position = (i + 1).ToString() + ".";
            }


            return new ObservableCollection<TeamInGroup>(teams_list);

        }

        public int Points_for_match(Single_match match, int who)
        {
            int goalsfirst = (int)match.Goals_first_team;
            int goalssecond = (int)match.Goals_second_team;

            if (goalsfirst == goalssecond)
            {
                return 1;
            }
            else if (goalsfirst > goalssecond)
            {
                if (who == 0)
                {
                    return 3;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                if (who == 0)
                {
                    return 0;
                }
                else
                {
                    return 3;
                }
            }


        }

        public void CalculateStats()
        {
            foreach (var team in Model.GroupsTeams[Model.CurrentGroup])
            {
                foreach (var match in Model.GroupsMatches[Model.CurrentGroup])
                {
                    if (match.Name_first == team.Country)
                    {
                        var points = Points_for_match(match, 0);
                        if (points == 3)
                            team.Wins += 1;
                        else if (points == 1)
                            team.Draws += 1;
                        else
                            team.Losses += 1;
                    }
                    else if (match.Name_second == team.Country)
                    {
                        var points = Points_for_match(match, 1);
                        if (points == 3)
                            team.Wins += 1;
                        else if (points == 1)
                            team.Draws += 1;
                        else
                            team.Losses += 1;
                    }
                }
            }
        }

        #endregion


        #region Commands

        private ICommand _checkStandings = null;

        public ICommand CheckStandings
        {
            get
            {
                if (_checkStandings == null)
                {
                    _checkStandings = new RelayCommand(arg =>
                    {
                        bool check = true;
                        foreach (var x in Model.GroupsMatches[Model.CurrentGroup])
                        {
                            if (x.Goals_first_team == null || x.Goals_second_team == null)
                            {
                                check = false;
                                break;
                            }
                        }
                        if (check)
                        {
                            Model.GroupsTeams[Model.CurrentGroup] = PrepareStanding(Model.GroupsMatches[Model.CurrentGroup], Model.CurrentGroup);
                            CalculateStats();
                            Model.CurrentTournamentGroups[Model.CurrentGroup].Id_first_pl_team = (uint?)Model.GroupsTeams[Model.CurrentGroup][0].Id;
                            Model.CurrentTournamentGroups[Model.CurrentGroup].Id_second_pl_team = (uint?)Model.GroupsTeams[Model.CurrentGroup][1].Id;
                            RepositoryGroups.UpdateGroup(Model.CurrentTournamentGroups[Model.CurrentGroup]);
                        }
                    },
                    arg => true);
                }
                return _checkStandings;
            }
        }

        //private ICommand _groupSelectionChanged = null;

        //public ICommand GroupSelectionChanged
        //{
        //    get
        //    {
        //        if (_groupSelectionChanged == null)
        //        {
        //            _groupSelectionChanged = new RelayCommand(arg =>
        //            {
        //                Console.WriteLine(Model.CurrentGroup);
        //            },
        //            arg => true);
        //        }
        //        return _groupSelectionChanged;
        //    }
        //}

        #endregion
    }
}
