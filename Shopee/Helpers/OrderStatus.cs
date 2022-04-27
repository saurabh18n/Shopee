using System.Runtime.Serialization;

namespace Shopee;
public enum OrderStatus
{
    [EnumMember(Value = "PENDING")]
    Pending,
    [EnumMember(Value = "PROCESSING")]
    Processing, [EnumMember(Value = "INTRANSIT")]
    Intransit,
    [EnumMember(Value = "COMPLETED")]
    Completed,
    [EnumMember(Value = "CANCELLED")]
    Cancelled
}