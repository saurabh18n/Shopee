using System.Runtime.Serialization;

namespace Shopee;
public enum PaymentType
{
    [EnumMember(Value = "CC")]
    CreditCard,
    [EnumMember(Value = "DC")]
    DebitCard,
    [EnumMember(Value = "CC")]
    NetBanking,
    [EnumMember(Value = "UPI")]
    UPI,
    [EnumMember(Value = "COD")]
    CashOnDelivary
}