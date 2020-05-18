using System;

namespace CaterSoftDomain.Models
{
    public  class Order:BaseModel
    {
        public virtual int Ref { get; set; }
        public virtual string Name { get; set; }
        public virtual  decimal Delivery { get; set; }
        public virtual  decimal Discount { get; set; }
        public virtual  string Tel { get; set; }
        public virtual  DateTime? Date1 { get; set; }
        public virtual  decimal TotalItems { get; set; }
        public virtual  decimal OrderTotal { get; set; }
        public virtual  string Type { get; set; }
        public virtual  int CustRef { get; set; }
        public virtual  string Status { get; set; }
        public virtual  int RandomRef { get; set; }
        public virtual  decimal Price2 { get; set; }
        public virtual  decimal Price3 { get; set; }
        public virtual  DateTime? Date2 { get; set; }
        public virtual  string BAD { get; set; }
        public virtual  string Sessioned { get; set; }
        public virtual  decimal TenderedAmount { get; set; }
        public virtual  decimal ChangeAmount { get; set; }
        public virtual  decimal ReceiptTip { get; set; }
        public virtual  decimal ReceiptServiceCharge { get; set; }
        public virtual decimal ReceiptCashAmount { get; set; }
        public virtual decimal ReceiptChequeAmount { get; set; }
        public virtual decimal ReceiptCreditCardAmount { get; set; }
        public virtual string CancelReason { get; set; }
        public virtual int DiscountPerCent { get; set; }
        public virtual string DiscountReason { get; set; }
        public virtual decimal Refund { get; set; }
        public virtual string RefundReason { get; set; }
        public virtual DateTime? RefundDate { get; set; }
        public virtual int SessionId { get; set; }
        public virtual decimal ReceiptVoucherAmount { get; set; }
        public virtual string VoucherNumber { get; set; }
        public virtual bool Weborder { get; set; }
        public virtual decimal Loyaltybal { get; set; }
        public virtual string Webcompany { get; set; }
        public virtual decimal ReceiptWebAmount { get; set; }
        public virtual int SaleID { get; set; }
        public virtual string OType { get; set; }
        public virtual int Tillid { get; set; }
        public virtual int UserRef { get; set; }
        public virtual int ShopsessId { get; set; }
        public virtual DateTime? StartDate { get; set; }
        public virtual DateTime? EndDate { get; set; }
        public virtual int StartOrderRefNumber { get; set; }
        public virtual decimal DeclaredTakings { get; set; }
        public virtual string SessionStatus { get; set; }
        public virtual string Items { get; set; }
        public virtual DateTime? OCDate { get; set; }
        public virtual int? OCRef { get; set; }
       public virtual double? OCTotalItems { get; set; }
       public virtual double? OCOrderTotal { get; set; }
       public virtual string OCItems { get; set; }
       public virtual string OCChangedBy { get; set; }
       public virtual double? OCDiscount { get; set; }
       public virtual string OCDiscountReason { get; set; }

       public virtual double? OCRefund { get; set; }
       public virtual double? OCDelivery { get; set; }
       public virtual double? OCReceiptTip { get; set; }
       public virtual double? OCReceiptServiceCharge { get; set; }
       public virtual double? OCReceiptCashAmount { get; set; }

       public virtual double? OCReceiptChequeAmount { get; set; }
       public virtual double? OCReceiptCreditCardAmount { get; set; }

       public virtual double? OCReceiptVoucherAmount { get; set; }
       public virtual double? OCTenderedAmount { get; set; }
       public virtual double? OCChangeAmount { get; set; }
       public virtual double? OCLoyaltyDiscount { get; set; }
       public virtual double? OCLoyaltyBal { get; set; }
       public virtual int? OCTillNumber { get; set; }

       public virtual string OCForeignCurrency { get; set; }
       public virtual int? OCSessionID { get; set; }
       public virtual double? OCReceiptWebAmount { get; set; }
       public virtual DateTime? Date3 { get; set; }



    }
}