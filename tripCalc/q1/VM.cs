using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

//Tony Kwak
namespace q1
{
    public class VM : INotifyPropertyChanged
    {
        const string OUTPUT_FILE = "SeatContract.txt";
        const decimal BASIC_PRICE = 10;
        const decimal STANDARD_PRICE = 15;
        const decimal DELUXE_PRICE = 20;
        public string FileData = "";
        private Seat selectedSeat;
        public Seat SelectedSeat
        {
            get => selectedSeat;
            set { selectedSeat = value; Calc(); OnChange(); }
        }
        private Lifejacket selectedLifejacket;
        public Lifejacket SelectedLifejacket
        {
            get => selectedLifejacket;
            set { selectedLifejacket = value; Calc(); OnChange(); }
        }
        private decimal total;
        public decimal Total
        {
            get => total;
            set { total = value; OnChange(); }
        }
        private int enteredDays;
        public int EnteredDays
        {
            get => enteredDays;
            set { enteredDays = value; Calc(); OnChange(); }
        }
        private decimal toPrint;
        public decimal ToPrint
        {
            get => toPrint;
            set { toPrint = value; OnChange(); }
        }
        //basic/Basic is the running total
        private int basic;
        public int Basic
        {
            get => basic;
            set { basic = value; Calc(); OnChange(); }
        }
        private bool basic1;
        public bool Basic1
        {
            get => basic1;
            set { basic1 = value; JacketCalc(); OnChange(); }
        }
        private bool basic2;
        public bool Basic2
        {
            get => basic2;
            set { basic2 = value; JacketCalc(); OnChange(); }
        }
        private bool basic3;
        public bool Basic3
        {
            get => basic3;
            set { basic3 = value; JacketCalc(); OnChange(); }
        }
        private bool basic4;
        public bool Basic4
        {
            get => basic4;
            set { basic4 = value; JacketCalc(); OnChange(); }
        }
        private bool basic5;
        public bool Basic5
        {
            get => basic5;
            set { basic5 = value; JacketCalc(); OnChange(); }
        }
        private bool basic6;
        public bool Basic6
        {
            get => basic6;
            set { basic6 = value; JacketCalc(); OnChange(); }
        }
        private bool basic7;
        public bool Basic7
        {
            get => basic7;
            set { basic7 = value; JacketCalc(); OnChange(); }
        }
        //standard/Standard is the running total
        private int standard;
        public int Standard
        {
            get => standard;
            set { standard = value; Calc(); OnChange(); }
        }
        private bool standard1;
        public bool Standard1
        {
            get => standard1;
            set { standard1 = value; JacketCalc(); OnChange(); }
        }
        private bool standard2;
        public bool Standard2
        {
            get => standard2;
            set { standard2 = value; JacketCalc(); OnChange(); }
        }
        private bool standard3;
        public bool Standard3
        {
            get => standard3;
            set { standard3 = value; JacketCalc(); OnChange(); }
        }
        private bool standard4;
        public bool Standard4
        {
            get => standard4;
            set { standard4 = value; JacketCalc(); OnChange(); }
        }
        private bool standard5;
        public bool Standard5
        {
            get => standard5;
            set { standard5 = value; JacketCalc(); OnChange(); }
        }
        private bool standard6;
        public bool Standard6
        {
            get => standard6;
            set { standard6 = value; JacketCalc(); OnChange(); }
        }
        private bool standard7;
        public bool Standard7
        {
            get => standard7;
            set { standard7 = value; JacketCalc(); OnChange(); }
        }
        //deluxe/Deluxe is the running total
        private int deluxe;
        public int Deluxe
        {
            get => deluxe;
            set { deluxe = value; Calc(); OnChange(); }
        }
        private bool deluxe1;
        public bool Deluxe1
        {
            get => deluxe1;
            set { deluxe1 = value; JacketCalc(); OnChange(); }
        }
        private bool deluxe2;
        public bool Deluxe2
        {
            get => deluxe2;
            set { deluxe2 = value; JacketCalc(); OnChange(); }
        }
        private bool deluxe3;
        public bool Deluxe3
        {
            get => deluxe3;
            set { deluxe3 = value; JacketCalc(); OnChange(); }
        }
        private bool deluxe4;
        public bool Deluxe4
        {
            get => deluxe4;
            set { deluxe4 = value; JacketCalc(); OnChange(); }
        }
        private bool deluxe5;
        public bool Deluxe5
        {
            get => deluxe5;
            set { deluxe5 = value; JacketCalc(); OnChange(); }
        }
        private bool deluxe6;
        public bool Deluxe6
        {
            get => deluxe6;
            set { deluxe6 = value; JacketCalc(); OnChange(); }
        }
        private bool deluxe7;
        public bool Deluxe7
        {
            get => deluxe7;
            set { deluxe7 = value; JacketCalc(); OnChange(); }
        }
        private decimal jacket;
        public decimal Jacket
        {
            get => jacket;
            set { jacket = value; Calc(); OnChange(); }
        }
        private bool oneDay;
        public bool OneDay
        {
            get => oneDay;
            set { oneDay = value; Reset(); EnteredDaysCalc(); OnChange(); }
        }
        private bool twoDay;
        public bool TwoDay
        {
            get => twoDay;
            set { twoDay = value; Reset(); EnteredDaysCalc(); OnChange(); }
        }
        private bool threeDay;
        public bool ThreeDay
        {
            get => threeDay;
            set { threeDay = value; Reset(); EnteredDaysCalc(); OnChange(); }
        }
        private bool fourDay;
        public bool FourDay
        {
            get => fourDay;
            set { fourDay = value; Reset(); EnteredDaysCalc(); OnChange(); }
        }
        private bool fiveDay;
        public bool FiveDay
        {
            get => fiveDay;
            set { fiveDay = value; Reset(); EnteredDaysCalc(); OnChange(); }
        }
        private bool sixDay;
        public bool SixDay
        {
            get => sixDay;
            set { sixDay = value; Reset(); EnteredDaysCalc(); OnChange(); }
        }
        private bool sevenDay;
        public bool SevenDay
        {
            get => sevenDay;
            set { sevenDay = value; Reset(); EnteredDaysCalc(); OnChange(); }
        }
        private bool day1Visible = false;
        public bool Day1Visible
        {
            get => day1Visible;
            set { day1Visible = value; OnChange(); }
        }
        private bool day2Visible = false;
        public bool Day2Visible
        {
            get => day2Visible;
            set { day2Visible = value; OnChange(); }
        }
        private bool day3Visible = false;
        public bool Day3Visible
        {
            get => day3Visible;
            set { day3Visible = value; OnChange(); }
        }
        private bool day4Visible = false;
        public bool Day4Visible
        {
            get => day4Visible;
            set { day4Visible = value; OnChange(); }
        }
        private bool day5Visible = false;
        public bool Day5Visible
        {
            get => day5Visible;
            set { day5Visible = value; OnChange(); }
        }
        private bool day6Visible = false;
        public bool Day6Visible
        {
            get => day6Visible;
            set { day6Visible = value; OnChange(); }
        }
        private bool day7Visible = false;
        public bool Day7Visible
        {
            get => day7Visible;
            set { day7Visible = value; OnChange(); }
        }

        public BindingList<Seat> Seats { get; set; } = new BindingList<Seat>()
        {
            new Seat(){Description = "Single Seat", Price = 100m },
            new Seat(){Description = "Two Seat", Price = 200m },
            new Seat(){Description = "Three Seat", Price = 300m },
        };
        public BindingList<Lifejacket> Lifejackets { get; set; } = new BindingList<Lifejacket>()
        {
            new Lifejacket(){Description = "Basic", Price = 10m},
            new Lifejacket(){Description = "Standard", Price = 15m},
            new Lifejacket(){Description = "Deluxe", Price = 20m},
        };

        public void Reset()
        {
            Day1Visible = false;
            Day2Visible = false;
            Day3Visible = false;
            Day4Visible = false;
            Day5Visible = false;
            Day6Visible = false;
            Day7Visible = false;            
        }
        public void Day1Reset()
        {
            Basic2 = false;
            Basic3 = false;
            Basic4 = false;
            Basic5 = false;
            Basic6 = false;
            Basic7 = false;
            Standard2 = false;
            Standard3 = false;
            Standard4 = false;
            Standard5 = false;
            Standard6 = false;
            Standard7 = false;
            Deluxe2 = false;
            Deluxe3 = false;
            Deluxe4 = false;
            Deluxe5 = false;
            Deluxe6 = false;
            Deluxe7 = false;
        }
        public void Day2Reset()
        {
            Basic3 = false;
            Basic4 = false;
            Basic5 = false;
            Basic6 = false;
            Basic7 = false;
            Standard3 = false;
            Standard4 = false;
            Standard5 = false;
            Standard6 = false;
            Standard7 = false;
            Deluxe3 = false;
            Deluxe4 = false;
            Deluxe5 = false;
            Deluxe6 = false;
            Deluxe7 = false;
        }
        public void Day3Reset()
        {
            Basic4 = false;
            Basic5 = false;
            Basic6 = false;
            Basic7 = false;
            Standard4 = false;
            Standard5 = false;
            Standard6 = false;
            Standard7 = false;
            Deluxe4 = false;
            Deluxe5 = false;
            Deluxe6 = false;
            Deluxe7 = false;
        }
        public void Day4Reset()
        {
            Basic5 = false;
            Basic6 = false;
            Basic7 = false;
            Standard5 = false;
            Standard6 = false;
            Standard7 = false;
            Deluxe5 = false;
            Deluxe6 = false;
            Deluxe7 = false;
        }
        public void Day5Reset()
        {
            Basic6 = false;
            Basic7 = false;
            Standard6 = false;
            Standard7 = false;
            Deluxe6 = false;
            Deluxe7 = false;
        }
        public void Day6Reset()
        {
            Basic7 = false;
            Standard7 = false;
            Deluxe7 = false;
        }
        public void EnteredDaysCalc()
        {
            if (OneDay == true)
            {
                EnteredDays = 1;
                Day1Visible = true;
                Day1Reset();
            }
            if (TwoDay == true)
            {
                EnteredDays = 2;
                Day1Visible = true;
                Day2Visible = true;
                Day2Reset();
            }
            if (ThreeDay == true)
            {
                EnteredDays = 3;
                Day1Visible = true;
                Day2Visible = true;
                Day3Visible = true;
                Day3Reset();
            }
            if (FourDay == true)
            {
                EnteredDays = 4;
                Day1Visible = true;
                Day2Visible = true;
                Day3Visible = true;
                Day4Visible = true;
                Day4Reset();
            }
            if (FiveDay == true)
            {
                EnteredDays = 5;
                Day1Visible = true;
                Day2Visible = true;
                Day3Visible = true;
                Day4Visible = true;
                Day5Visible = true;
                Day5Reset();
            }
            if (SixDay == true)
            {
                EnteredDays = 6;
                Day1Visible = true;
                Day2Visible = true;
                Day3Visible = true;
                Day4Visible = true;
                Day5Visible = true;
                Day6Visible = true;
                Day6Reset();
            }
            if (SevenDay == true)
            {
                EnteredDays = 7;
                Day1Visible = true;
                Day2Visible = true;
                Day3Visible = true;
                Day4Visible = true;
                Day5Visible = true;
                Day6Visible = true;
                Day7Visible = true;
            }
        }
        public void JacketCalc()
        {
            Basic = 0;
            Standard = 0;
            Deluxe = 0;
            if (Basic1 == true)
            {
                Basic++;
            }
            if (Basic2 == true)
            {
                Basic++;
            }
            if (Basic3 == true)
            {
                Basic++;
            }
            if (Basic4 == true)
            {
                Basic++;
            }
            if (Basic5 == true)
            {
                Basic++;
            }
            if (Basic6 == true)
            {
                Basic++;
            }
            if (Basic7 == true)
            {
                Basic++;
            }
            if (Standard1 == true)
            {
                Standard++;
            }
            if (Standard2 == true)
            {
                Standard++;
            }
            if (Standard3 == true)
            {
                Standard++;
            }
            if (Standard4 == true)
            {
                Standard++;
            }
            if (Standard5 == true)
            {
                Standard++;
            }
            if (Standard6 == true)
            {
                Standard++;
            }
            if (Standard7 == true)
            {
                Standard++;
            }
            if (Deluxe1 == true)
            {
                Deluxe++;
            }
            if (Deluxe2 == true)
            {
                Deluxe++;
            }
            if (Deluxe3 == true)
            {
                Deluxe++;
            }
            if (Deluxe4 == true)
            {
                Deluxe++;
            }
            if (Deluxe5 == true)
            {
                Deluxe++;
            }
            if (Deluxe6 == true)
            {
                Deluxe++;
            }
            if (Deluxe7 == true)
            {
                Deluxe++;
            }
        }

        public void Calc()
        {
            ToPrint = ((SelectedSeat?.Price ?? 0) * EnteredDays + Basic*BASIC_PRICE + Standard*STANDARD_PRICE + Deluxe*DELUXE_PRICE);
            FileData = ToPrint.ToString();
            File.WriteAllText(OUTPUT_FILE, FileData);
        }
        public void OnChange([CallerMemberName]string property = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
