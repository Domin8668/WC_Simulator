using System;
using System.Linq;

namespace WC_Simulator.Model
{
    class Schedule
    {
        #region Variables
        private int[] _matchCodes = new int[64];
        private int[] _matchStages = new int[64];
        private int[] _matchLocations = new int[64];
        private int[] _matchReferees = new int[64];
        private DateTime[] _matchDates = new DateTime[64];
        private ScheduleMatch[] _finalSchedule = new ScheduleMatch[64];
        #endregion

        #region Properties
        public int[] MatchCodes
        {
            get { return _matchCodes; }
            set { _matchCodes = value; }
        }
        public int[] MatchStages
        {
            get { return _matchStages; }
            set { _matchStages = value; }
        }
        public int[] MatchLocations
        {
            get { return _matchLocations; }
            set { _matchLocations = value; }
        }
        public int[] MatchReferees
        {
            get { return _matchReferees; }
            set { _matchReferees = value; }
        }
        public DateTime[] MatchDates
        {
            get { return _matchDates; }
            set { _matchDates = value; }
        }
        public ScheduleMatch[] FinalSchedule
        {
            get { return _finalSchedule; }
            set { _finalSchedule = value; }
        }

        #endregion

        #region Constructor
        public Schedule()
        {
            Prepare_matchcodes();
            Prepare_matchstages();
            Prepare_matchlocations();
            Prepare_matchdates();
            Prepare_referees();

            ScheduleMatch[] november = new ScheduleMatch[40];
            ScheduleMatch[] december = new ScheduleMatch[24];

            for (int i = 0; i < 40; i++)
            {
                november[i] = new ScheduleMatch(_matchCodes[i], _matchStages[i], _matchLocations[i], _matchReferees[i], MatchDates[i]);
            }
            var novqry = november.Select(p => p).OrderBy(p => p.DateTimeVariable).ThenBy(p => p.MatchCode);


            for (int i = 0; i < 24; i++)
            {
                december[i] = new ScheduleMatch(_matchCodes[40 + i], _matchStages[40 + i], _matchLocations[40 + i], _matchReferees[40 + i], MatchDates[40 + i]);
            }
            var decqry = december.Select(p => p).OrderBy(p => p.DateTimeVariable).ThenBy(p => p.MatchCode);

            FinalSchedule = novqry.Concat(decqry).ToArray();
        }
        #endregion

        #region Methods
        private void Prepare_matchcodes()
        {
            for (int i = 0; i < 64; i++)
            {
                MatchCodes[i] = i;
            }
        }
        private void Prepare_matchstages()
        {
            // group
            for (int i = 0; i < 48; i++)
            {
                MatchStages[i] = 0;
            }
            // 1/8
            for (int i = 48; i < 56; i++)
            {
                MatchStages[i] = 1;
            }
            // 1/4
            for (int i = 56; i < 60; i++)
            {
                MatchStages[i] = 2;
            }
            // 1/2
            for (int i = 60; i < 62; i++)
            {
                MatchStages[i] = 3;
            }
            // 3rd and final
            MatchStages[62] = 4;
            MatchStages[63] = 5;
        }
        private void Prepare_matchlocations()
        {
            // na zielono cyfra w schedule match 
            int[] al_bayt = new int[9] { 0, 11, 19, 27, 35, 43, 50, 58, 61 }; // 0
            foreach (int i in al_bayt)
            {
                MatchLocations[i] = 0;
            }

            int[] lusail = new int[10] { 7, 15, 23, 31, 39, 47, 55, 56, 60, 63 }; // 1
            foreach (int i in lusail)
            {
                MatchLocations[i] = 1;
            }

            int[] stadium_974 = new int[7] { 6, 14, 22, 30, 38, 46, 53 }; // 2
            foreach (int i in stadium_974)
            {
                MatchLocations[i] = 2;
            }

            int[] al_thumana = new int[8] { 1, 9, 17, 25, 33, 41, 51, 59 }; //3
            foreach (int i in al_thumana)
            {
                MatchLocations[i] = 3;
            }

            int[] education = new int[8] { 5, 13, 21, 29, 37, 45, 54, 57 }; //4
            foreach (int i in education)
            {
                MatchLocations[i] = 4;
            }

            int[] ahmad = new int[7] { 3, 8, 16, 24, 32, 40, 49 }; //5
            foreach (int i in ahmad)
            {
                MatchLocations[i] = 5;
            }

            int[] khalifa_inter = new int[8] { 2, 10, 18, 26, 34, 42, 48, 62 }; //6
            foreach (int i in khalifa_inter)
            {
                MatchLocations[i] = 6;
            }

            int[] al_janoub = new int[7] { 4, 12, 20, 28, 36, 44, 52 }; //7
            foreach (int i in al_janoub)
            {
                MatchLocations[i] = 7;
            }
        }
        private void Prepare_matchdates()
        {
            int[] eleven = new int[8] { 1, 7, 11, 12, 16, 20, 24, 28 }; //matchcode o 11, grupa
            int[] fourteen = new int[8] { 2, 5, 10, 13, 17, 21, 25, 29 }; //matchcode o 14, grupa
            int[] sixteen = new int[8] { 48, 51, 52, 54, 57, 59, 62, 63 }; //matchcode o 16
            int[] seventeen = new int[8] { 0, 6, 9, 14, 18, 22, 26, 30 }; //matchcode o 17, grupa
            int[] twenty = new int[10] { 3, 4, 8, 15, 19, 23, 27, 31, 60, 61 }; //matchcode o 20
            // wylaczone sa dwie ostatnie kolejki fazy grupowej

            #region pierwsze dwie kolejki fazy grupwej
            // 11
            int day = 21;
            foreach (int element in eleven)
            {
                MatchDates[element] = new DateTime(2022, 11, day, 11, 0, 0);
                day++;
            }
            // 14
            day = 21;
            foreach (int element in fourteen)
            {
                MatchDates[element] = new DateTime(2022, 11, day, 14, 0, 0);
                day++;
            }
            // 17
            day = 21;
            foreach (var element in seventeen)
            {
                MatchDates[element] = new DateTime(2022, 11, day, 17, 0, 0);
                day++;
            }
            // 20
            for (int q = 0; q < 8; q++)
            {
                MatchDates[twenty[q]] = new DateTime(2022, 11, 21 + q, 20, 0, 0);
            }

            #endregion

            #region ostatnia kolejka
            MatchDates[32] = new DateTime(2022, 11, 29, 20, 0, 0);
            MatchDates[33] = new DateTime(2022, 11, 29, 20, 0, 0);
            MatchDates[34] = new DateTime(2022, 11, 29, 16, 0, 0);
            MatchDates[35] = new DateTime(2022, 11, 29, 16, 0, 0);

            MatchDates[36] = new DateTime(2022, 11, 30, 16, 0, 0);
            MatchDates[37] = new DateTime(2022, 11, 30, 16, 0, 0);
            MatchDates[38] = new DateTime(2022, 11, 30, 20, 0, 0);
            MatchDates[39] = new DateTime(2022, 11, 30, 20, 0, 0);

            MatchDates[40] = new DateTime(2022, 12, 1, 16, 0, 0);
            MatchDates[41] = new DateTime(2022, 12, 1, 16, 0, 0);
            MatchDates[42] = new DateTime(2022, 12, 1, 20, 0, 0);
            MatchDates[43] = new DateTime(2022, 12, 1, 20, 0, 0);

            MatchDates[44] = new DateTime(2022, 12, 2, 16, 0, 0);
            MatchDates[45] = new DateTime(2022, 12, 2, 16, 0, 0);
            MatchDates[46] = new DateTime(2022, 12, 2, 20, 0, 0);
            MatchDates[47] = new DateTime(2022, 12, 2, 20, 0, 0);
            #endregion

            #region 1/8
            // pierwsza połówka
            MatchDates[48] = new DateTime(2022, 12, 3, 16, 0, 0);
            MatchDates[49] = new DateTime(2022, 12, 3, 20, 0, 0);
            MatchDates[50] = new DateTime(2022, 12, 4, 20, 0, 0);
            MatchDates[51] = new DateTime(2022, 12, 4, 16, 0, 0);

            // druga połówka
            day = 5;
            for (int i = 52; i < 56; i += 2)
            {
                MatchDates[i] = new DateTime(2022, 12, day, 16, 0, 0);
                MatchDates[i + 1] = new DateTime(2022, 12, day, 20, 0, 0);
                day++;
            }

            #endregion

            #region ćwierćfinały
            day = 9;
            int hour = 20;
            for (int i = 56; i < 60; i++)
            {
                MatchDates[i] = new DateTime(2022, 12, day, hour, 0, 0);
                MatchDates[i + 2] = new DateTime(2022, 12, day + 1, hour, 0, 0);
                hour = 16;
            }
            #endregion

            #region strefa finałowa
            for (int i = 8; i < 10; i++)
            {
                MatchDates[twenty[i]] = new DateTime(2022, 12, 5 + i, 20, 0, 0);
            }
            for (int i = 6; i < 8; i++)
            {
                MatchDates[sixteen[i]] = new DateTime(2022, 12, 11 + i, 16, 0, 0);
            }
            #endregion
        }
        private void Prepare_referees()
        {
            for (int i = 0; i < 63; i++)
            {
                if (i < 35)
                {
                    MatchReferees[i] = i;
                }
                else
                {
                    MatchReferees[i] = i - 35;
                }
            }
            MatchReferees[63] = 0;
        }
        #endregion
    }
}
