using System;
using Keyfactor.HydrantId.Client.Models;
using Newtonsoft.Json;

public class TagEnumConverter : JsonConverter
{
    public override bool CanConvert(Type objectType) => objectType == typeof(PolicyDetailsSubjectAltNames.TagEnum) || objectType == typeof(PolicyDetailsSubjectAltNames.TagEnum?);

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        var strValue = (reader.Value as string)?.ToUpperInvariant();

        return strValue switch
        {
            "DNSNAME" => PolicyDetailsSubjectAltNames.TagEnum.DnsName,
            "IPADDRESS" => PolicyDetailsSubjectAltNames.TagEnum.IpAddress,
            "RFC822NAME" => PolicyDetailsSubjectAltNames.TagEnum.Rfc822Name,
            "RFS822NAME" => PolicyDetailsSubjectAltNames.TagEnum.Rfc822Name, // typo fallback
            "UPN" => PolicyDetailsSubjectAltNames.TagEnum.Upn,
            _ => throw new JsonSerializationException($"Unknown TagEnum value: {strValue}")
        };
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        var enumVal = (PolicyDetailsSubjectAltNames.TagEnum)value;

        var strVal = enumVal switch
        {
            PolicyDetailsSubjectAltNames.TagEnum.DnsName => "DNSNAME",
            PolicyDetailsSubjectAltNames.TagEnum.IpAddress => "IPADDRESS",
            PolicyDetailsSubjectAltNames.TagEnum.Rfc822Name => "RFC822NAME",
            PolicyDetailsSubjectAltNames.TagEnum.Upn => "UPN",
            _ => throw new JsonSerializationException($"Cannot write TagEnum value: {value}")
        };

        writer.WriteValue(strVal);
    }
}
