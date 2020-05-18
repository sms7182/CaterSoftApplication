using System;
using System.Collections.Generic;
using System.Text;

namespace CaterSoftDomain.Views
{
    public class SaleReport
    {
        public SaleReport()
        {
            SaleDetails = new List<SaleDetail>();
        }
        public List<SaleDetail> SaleDetails { get; set; }
    }
    public class SaleDetail
    {
        public decimal SumItems { get; set; }
        public decimal AmountSum { get; set; }

        public Int64 PeriodType { get; set; }

        public DateTime ReportDate { get; set; }

        public Int64 Duration { get; set; }
        public Int64 R { get; set; }
    }
    public enum PeriodType
    {
        Day=1,
        Week=2,
        Month=3,
        Year=4
    }
}
