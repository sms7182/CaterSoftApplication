using System;

namespace CaterSoftDomain.Models
{
    public  class Order:BaseModel
    {
        public virtual int Ref { get; set; }
        public virtual string Name { get; set; }
        public virtual  double Delivery { get; set; }
        public virtual  double Discount { get; set; }
        public virtual  string Tel { get; set; }
        public virtual  DateTime? Date1 { get; set; }
        public virtual  double TotalItems { get; set; }
        public virtual  double OrderTotal { get; set; }
        public virtual  string Type { get; set; }
        public virtual  int CustRef { get; set; }
        public virtual  string Status { get; set; }
        public virtual  int RandomRef { get; set; }
        public virtual  double Price2 { get; set; }
        public virtual  double Price3 { get; set; }
        public virtual  DateTime? Date2 { get; set; }
        public virtual  string BAD { get; set; }
        public virtual  string Sessioned { get; set; }
        public virtual  double TenderedAmount { get; set; }
        public virtual  double ChangeAmount { get; set; }
        public virtual  double ReceiptTip { get; set; }
        public virtual  double ReceiptServiceCharge { get; set; }
        public virtual double ReceiptCashAmount { get; set; }
        public virtual double ReceiptChequeAmount { get; set; }
        public virtual double ReceiptCreditCardAmount { get; set; }
        public virtual string CancelReason { get; set; }
        public virtual int DiscountPerCent { get; set; }
        public virtual string DiscountReason { get; set; }
        public virtual double Refund { get; set; }
        public virtual string RefundReason { get; set; }
        public virtual DateTime? RefundDate { get; set; }
        public virtual int SessionId { get; set; }
        public virtual double ReceiptVoucherAmount { get; set; }
        public virtual string VoucherNumber { get; set; }
        public virtual bool Weborder { get; set; }
        public virtual double Loyaltybal { get; set; }
        public virtual string Webcompany { get; set; }
        public virtual double ReceiptWebAmount { get; set; }
        public virtual int SaleID { get; set; }
        public virtual string OType { get; set; }
        public virtual int Tillid { get; set; }
        public virtual int UserRef { get; set; }
        public virtual int ShopsessId { get; set; }
        public virtual DateTime? StartDate { get; set; }
        public virtual DateTime? EndDate { get; set; }
        public virtual int StartOrderRefNumber { get; set; }
        public virtual double DeclaredTakings { get; set; }
        public virtual string SessionStatus { get; set; }


    }
}