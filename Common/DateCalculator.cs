using System;
using System.Collections.Generic;
using System.Text;

namespace ClassManager.Common
{
    internal class DateCalculator
    {
        #region Private Members
        private int _Days;
        private int _Weeks;
        private int _Months;
        private int _Years;
        private int _TotalDays =1;
        private int _TotalWeeks;
        private int _TotalMonths;
        private DateTime FromDate;
        private DateTime ToDate;
        DateTime CheckDate = new DateTime();
        private int[] MonthDays = new int[12] { 31, -1, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        private int[] _MonthAccural = new int[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private int _NumberOfLeapYears = 0;

        #endregion

        #region Proprietes
        public int Days
        {
            get { return _Days; }

        }

        public int Weeks
        {
            get { return _Weeks; }

        }

        public int Months
        {
            get { return _Months; }

        }

        public int Years
        {
            get { return _Years; }

        }

        public int TotalDays
        {
            get { return _TotalDays; }
        }

        public int TotalWeeks
        {
            get { return _TotalWeeks; }
        }

        public int TotalMonths
        {
            get { return _TotalMonths; }
        }

        public int[] MonthAccural
        {
            get { return _MonthAccural; }
        }

        public int NumberOfLeapYears
        {
            get { return _NumberOfLeapYears; }
        }
        #endregion

        #region Constructor
        public DateCalculator(DateTime _StartDate, DateTime _EndDate)
        {
            if (_StartDate != null && _EndDate != null)
            {
                if (_StartDate > _EndDate)
                {
                    this.FromDate = _EndDate;
                    this.ToDate = _StartDate;
                }
                else
                {
                    this.FromDate = _StartDate;
                    this.ToDate = _EndDate;
                }           
               
            }
            else
            {
                throw new Exception("The value of Start or End date can't be null");
            }

        }
        #endregion

        #region Methods
        public void CalculateDateDifference()
        {
            bool Finish = false;
            DateTime TempDate = this.FromDate;
            int MonthsIndex = this.FromDate.Month - 1;
            int CurrentMonthDayes = this.MonthDays[MonthsIndex];
            this._TotalDays-= this.FromDate.Day;

            while (!Finish)
            {

                if (CurrentMonthDayes == -1)
                {
                    if (DateTime.IsLeapYear(TempDate.Year))
                    {
                        CheckDate = TempDate.AddDays(29);
                        TempDate = CheckDate;
                        this._NumberOfLeapYears++;

                    }
                    else
                    {
                        CheckDate =TempDate.AddDays(28);
                        TempDate = CheckDate;
                    }
                    this._MonthAccural[MonthsIndex]++;
                    this._Months++;
                }
                else
                {
                    CheckDate = TempDate.AddDays(CurrentMonthDayes);
                    TempDate = CheckDate;
                    this._MonthAccural[MonthsIndex]++;
                    this._Months++;
                }

                if (!CheckTerminationCondition())
                {
                    if (MonthsIndex == 11)
                        MonthsIndex = 0;
                    else
                        MonthsIndex++;

                    CurrentMonthDayes = this.MonthDays[MonthsIndex];
                }
                else
                {
                    Finish = true;
                    int Accumlator = 0;
                    for (int i = 0; i <= 11; i++)
                    {
                        if (i == 1)
                        {
                            Accumlator += this._MonthAccural[i] * 28;
                        }
                        else
                        {
                            Accumlator += this._MonthAccural[i] * this.MonthDays[i];
                        }
                    }
                    Accumlator += this._NumberOfLeapYears;

                    if (CheckDate > this.ToDate)
                    {
                        this._Months--;
                        this._MonthAccural[MonthsIndex]--;
                        Accumlator -= this.MonthDays[MonthsIndex];
                    }
                    DateTime AccumlatedEndDate = this.FromDate.AddDays(Accumlator);
                    this._Days = ((TimeSpan)this.ToDate.Subtract(AccumlatedEndDate)).Days;
                    this._TotalDays = Accumlator + this._Days;
                    this._TotalWeeks = this._TotalDays / 7;
                    this._TotalMonths = this._Months;
                   
                    if ((this._Months / 12) > 0)
                    {
                        this._Years = this._Months / 12;
                        this._Months = this._Months % 12;
                    }
                    if ((this._Days / 7) > 0)
                    {
                        this._Weeks = this._Days / 7;
                        this._Days = this._Days % 7;
                    }
                    
                }


            }
        }
        #endregion

        #region Helper Methods
        private bool CheckTerminationCondition()
        {
            if (CheckDate >= this.ToDate)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

    }
}
