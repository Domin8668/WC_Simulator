using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC_Simulator.Model
{
    internal class ScheduleMatch
    {
        #region Properties
        public int Match_code { get; set; }
        public string Stage { get; set; }
        public string Location { get; set; }
        public string Referee { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

        public string[] StageTypes = new string[6]
        {
            "Faza grupowa", 
            "1/8 finału", 
            "Ćwierćfinały", 
            "Półfinały", 
            "Mecz o 3. miejsce", 
            "Finał"
        };

        public string[] LocationTypes = new string[8]
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

        public string[] Referees = new string[35]
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

        #region Constructors
        //useless
        public ScheduleMatch()
        {
            Match_code = 0;
            Stage = StageTypes[0];
            Location = LocationTypes[0];
            Referee = Referees[0];
            Date = DateTime.Now.ToString("dddd, dd MMMM yyyy");
            Time = DateTime.Now.ToString("HH: mm");
        }

        public ScheduleMatch(int match_code, int stage, int location, int referee, DateTime date_and_time)
        {
            Match_code = match_code;
            Stage = StageTypes[stage];
            Location = LocationTypes[location];
            Referee = Referees[referee];
            Date = date_and_time.ToString("dddd, dd MMMM yyyy");
            Time = date_and_time.ToString("HH: mm");
        }

        #endregion 

        #region Methods
        public override string ToString()
        {
            return $"Faza: {Stage},\n Lokalizacja: {Location},\n Data: {Date},\n Godzina: {Time}\n, Sędzia: {Referee}";
        }

        #endregion
    }
}
