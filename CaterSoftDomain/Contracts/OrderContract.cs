using System;

namespace CaterSoftDomain.Contracts
{
    public class OrderContract
    {
        public int Ref { get; set; }
        public string Name { get; set; }
        public double Delivery { get; set; }
        public double Discount { get; set; }
        public string Tel { get; set; }
        public DateTime? Date1 { get; set; }
        public double TotalItems { get; set; }
        public double OrderTotal { get; set; }
        public string Type { get; set; }
        public int CustRef { get; set; }
        public string Status { get; set; }
        public int RandomRef { get; set; }
        public double Price2 { get; set; }
        public double Price3 { get; set; }
        public DateTime? Date2 { get; set; }
        public string BAD { get; set; }
        public string Sessioned { get; set; }
        public double TenderedAmount { get; set; }
        public double ChangeAmount { get; set; }
        public double ReceiptTip { get; set; }
        public double ReceiptServiceCharge { get; set; }
        public double ReceiptCashAmount { get; set; }
        public double ReceiptChequeAmount { get; set; }
        public double ReceiptCreditCardAmount { get; set; }
        public string CancelReason { get; set; }
        public int DiscountPerCent { get; set; }
        public string DiscountReason { get; set; }
        public double Refund { get; set; }
        public string RefundReason { get; set; }
        public DateTime? RefundDate { get; set; }
        public int SessionId { get; set; }
        public double ReceiptVoucherAmount { get; set; }
        public string VoucherNumber { get; set; }
        public bool Weborder { get; set; }
        public double Loyaltybal { get; set; }
        public string Webcompany { get; set; }
        public double ReceiptWebAmount { get; set; }
        public int SaleID { get; set; }
        public string OType { get; set; }
        public int Tillid { get; set; }
        public int UserRef { get; set; }
        public int ShopsessId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int StartOrderRefNumber { get; set; }
        public double DeclaredTakings { get; set; }
        public string SessionStatus { get; set; }
        public string Items { get; set; }
        public DateTime? OCDate { get; set; }
        public int? OCRef { get; set; }
        public double? OCTotalItems { get; set; }
        public double? OCOrderTotal { get; set; }
        public string OCItems { get; set; }
        public string OCChangedBy { get; set; }
        public double? OCDiscount { get; set; }
        public string OCDiscountReason { get; set; }

        public double? OCRefund { get; set; }
        public double? OCDelivery { get; set; }
        public double? OCReceiptTip { get; set; }
        public double? OCReceiptServiceCharge { get; set; }
        public double? OCReceiptCashAmount { get; set; }

        public double? OCReceiptChequeAmount { get; set; }
        public double? OCReceiptCreditCardAmount { get; set; }

        public double? OCReceiptVoucherAmount { get; set; }
        public double? OCTenderedAmount { get; set; }
        public double? OCChangeAmount { get; set; }
        public double? OCLoyaltyDiscount { get; set; }
        public double? OCLoyaltyBal { get; set; }
        public int? OCTillNumber { get; set; }

        public string OCForeignCurrency { get; set; }
        public int? OCSessionID { get; set; }
        public double? OCReceiptWebAmount { get; set; }

        public virtual DateTime? Date3 { get; set; }



    }
}