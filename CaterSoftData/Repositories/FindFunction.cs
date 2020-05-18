using CaterSoftDomain.IRepositories;
using CaterSoftDomain.Views;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CaterSoftData.Repositories
{
    public class FindFunction : IFindFunction
    {
        Dictionary<PeriodType, Func<string,DateTime,DateTime, string>> salePerPeriodQuery;
        public Dictionary<PeriodType, Func<string,DateTime,DateTime, string>> SalePerPeriodQuery 
        { get
            {
               
                return salePerPeriodQuery;
            }
            set { }
           
              
        }
        public FindFunction()
        {
            salePerPeriodQuery= new Dictionary<PeriodType, Func<string,DateTime,DateTime, string>>();
            salePerPeriodQuery.Add(PeriodType.Day, GenerateQueryPerDay);
            salePerPeriodQuery.Add(PeriodType.Week, GenerateQueryPerWeek);
            salePerPeriodQuery.Add(PeriodType.Month, GenerateQueryPerMonth);
            salePerPeriodQuery.Add(PeriodType.Year, GenerateQueryPerYear);
        }
        public  string GenerateQueryPerDay(string tenant, DateTime start, DateTime end)
        {
          return  string.Format(string.Format(@"select *,1 as PeriodType from (
                select 
                DATEPART(WEEKDAY,po.date1) Duration,
                sum(po.totalitems) over (partition by convert(Date,po.date1)) SumItems,
                sum(po.ReceiptCashAmount+po.ReceiptChequeAmount+po.ReceiptCreditCardAmount) over (partition by convert(Date,po.date1)) AmountSum
                ,
                ROW_NUMBER() over(partition by convert(Date,po.date1) order by po.date1) R,
                po.Date1 as ReportDate
                
                from CaterSoft.POrder po
                where po.Tenant='{0}' and po.Status!='X' and convert(Date,date1)>=convert(Date,'{1}') and CONVERT(date,date1)<=convert(Date,'{2}')) rd  where rd.r=1 ", tenant,start,end));
        }
        public string GenerateQueryPerWeek(string tenant, DateTime start, DateTime end)
        {
            return string.Format(string.Format(@"select *,2 as PeriodType from (
                select 
                DATEPART(WEEK,po.date1) Duration,
                sum(po.totalitems) over (partition by DatePart(year,po.date1),DATEPART(WEEK,po.date1)) SumItems,
                
                sum(po.ReceiptCashAmount+po.ReceiptChequeAmount+po.ReceiptCreditCardAmount) over (partition by DatePart(year,po.date1),DATEPART(WEEK,po.date1)) AmountSum
                ,
                ROW_NUMBER() over(partition by DatePart(year,po.date1),DATEPART(WEEK,po.date1) order by po.date1) R,
                po.Date1 as ReportDate
                
                from CaterSoft.POrder po
                where po.Tenant='{0}' and po.Status!='X' and convert(Date,date1)>=convert(Date,'{1}') and CONVERT(date,date1)<=convert(Date,'{2}')
                )rd  where rd.R=1 ", tenant,start,end));
        }
        public string GenerateQueryPerMonth(string tenant,DateTime start,DateTime end)
        {
            return string.Format(@"select *,3 as PeriodType from ( select  DATEPART(Month,po.date1) Duration, sum(po.totalitems) over (partition by DatePart(year,po.date1),DATEPART(Month,po.date1)) SumItems,
            sum(po.ReceiptCashAmount+po.ReceiptChequeAmount+po.ReceiptCreditCardAmount) over (partition by DatePart(year,po.date1),DATEPART(Month,po.date1)) AmountSum
            ,ROW_NUMBER() over(partition by DatePart(year,po.date1),DATEPART(Month,po.date1) order by po.date1) R,
            po.Date1 as ReportDate  from CaterSoft.POrder po where po.Tenant='{0}' and po.Status!='X' and convert(Date,date1)>=convert(Date,'{1}') and CONVERT(date,date1)<=convert(Date,'{2}') )rd  where rd.R=1 ", tenant,start,end);
        }
        public string GenerateQueryPerYear(string tenant, DateTime start, DateTime end)
        {
            return string.Format(@"select *,4 as PeriodType from (
            select 
            DATEPART(YEAR,po.date1) Duration,
            sum(po.totalitems) over (partition by DatePart(year,po.date1)) SumItems,
            
            sum(po.ReceiptCashAmount+po.ReceiptChequeAmount+po.ReceiptCreditCardAmount) over (partition by DatePart(year,po.date1)) AmountSum
            ,
            ROW_NUMBER() over(partition by DatePart(year,po.date1) order by po.date1) r,
            po.Date1 as ReportDate
            
            from CaterSoft.POrder po
            where po.Tenant='{0}' and po.Status!='X' and  convert(Date,date1)>=convert(Date,'{1}') and CONVERT(date,date1)<=convert(Date,'{2}')
            )rd  where rd.r=1 ", tenant,start,end);
        }

    }
}
