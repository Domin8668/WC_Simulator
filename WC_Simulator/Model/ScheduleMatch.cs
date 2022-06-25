using System;

namespace WC_Simulator.Model
{
    internal class ScheduleMatch
    {
        #region Variables 

        private int _matchCode { get; set; }
        private string _stage { get; set; }
        private string _location { get; set; }
        private string _referee { get; set; }
        private DateTime _dateTimeVariable { get; set; }
        private string _date { get; set; }
        private string _time { get; set; }

        //local
        public string[] _stageTypes = new string[6]
{
            "Faza grupowa",
            "1/8 finału",
            "Ćwierćfinały",
            "Półfinały",
            "Mecz o 3. miejsce",
            "Finał"
};

        public string[] _locationTypes = new string[8]
        {
            "Al Bayt Stadium, Al-Chaur",
            "Lusail Stadium, Lusajl",
            "Stadium 974, Doha",
            "Al Thumama Stadium, Doha",
            "Education City Stadium, Ar-Rajjan",
            "Ahmed bin Ali Stadium, Ar-Rajjan",
            "Khalifa International Stadium, Ar-Rajjan",
            "Al Janoub Stadium, Al-Wakra"
        };

        public string[] _referees = new string[35]
        {
            "Szymon Marciniak",
            "Michael Oliver",
            "Anthony Taylor",
            "Benoît Bastien",
            "Clément Turpin",
            "Daniel Siebert",
            "Orel Grinfeeld",
            "Daniele Orsato",
            "Danny Makkelie",
            "Artur Soares Dias",
            "Ovidiu Hațegan",
            "Sergei Karasyov",
            "Srdan Jovanovic",
            "Slavko Vincic",
            "Carlos del Cerro Grande",
            "Jesus Gil Manzano",
            "Antonio Miguel Mateu Lahoz",
            "Cuneyt Cakır",

            "Rédouane Jiyed",
            "Mustapha Ghorbal",
            "Maguette Ndiaye",
            "Omar Mohamed",
            "Bamlak Tessema",

            "Abdelkader Zitouni",

            "Adham Makhadmad",
            "Ko Hyung-Jin",
            "Ahmad Al-Kaf",
            "Abdulrahman Al-Jassim",

            "Fernando Rapallini",
            "Gery Vargas",
            "Raphael Claus",
            "Roberto Tobar",
            "Nicolas Gallo",
            "Carlos Orbe",
            "Mario Díaz de Vivar"
        };
        #endregion

        #region Properties
        public int MatchCode
        {
            get { return _matchCode; }
            set { _matchCode = value; }
        }
        public string Stage
        {
            get { return _stage; }
            set { _stage = value; }
        }
        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }
        public string Referee
        {
            get { return _referee; }
            set { _referee = value; }
        }
        public DateTime DateTimeVariable
        {
            get { return _dateTimeVariable; }
            set { _dateTimeVariable = value; }
        }

        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }
        public string Time
        {
            get { return _time; }
            set { _time = value; }
        }

        #endregion

        #region Constructors
        public ScheduleMatch(int matchCode, int stage, int location, int referee, DateTime date_and_time)
        {
            MatchCode = matchCode;
            Stage = _stageTypes[stage];
            Location = _locationTypes[location];
            Referee = _referees[referee];
            DateTimeVariable = date_and_time;
            Date = date_and_time.ToString("dddd, dd MMMM yyyy");
            Time = date_and_time.ToString("HH: mm");
        }

        #endregion 

        #region Methods
        public override string ToString()
        {
            return $"Faza: {Stage},\n Lokalizacja: {Location},\n Data: {Date},\n Godzina: {Time},\n Sędzia: {Referee}";
        }

        #endregion
    }
}
