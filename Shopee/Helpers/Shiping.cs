using System.Runtime.Serialization;

namespace Shopee;
public enum ShippingType
{
    [EnumMember(Value = "INDIAPOST")]
    IndiaPost,
    [EnumMember(Value = "LOCALDELIVERY")]
    LocalDelivery,
    [EnumMember(Value = "CURRIOR")]
    CURRIOR,
    [EnumMember(Value = "BYHAND")]
    ByHand
}