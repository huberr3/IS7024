﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var rootObject = RootObject.FromJson(jsonString);

namespace QuickType
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class RootObject
    {
        [JsonProperty("resultsPage")]
        public ResultsPage ResultsPage { get; set; }
    }

    public partial class ResultsPage
    {
        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("results")]
        public Results Results { get; set; }

        [JsonProperty("perPage")]
        public long PerPage { get; set; }

        [JsonProperty("page")]
        public long Page { get; set; }

        [JsonProperty("totalEntries")]
        public long TotalEntries { get; set; }
    }

    public partial class Results
    {
        [JsonProperty("event")]
        public List<Event> Event { get; set; }
    }

    public partial class Event
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("uri")]
        public Uri Uri { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("popularity")]
        public double Popularity { get; set; }

        [JsonProperty("start")]
        public Start Start { get; set; }

        [JsonProperty("sunset")]
        public String Sunset { get; set; }

        [JsonProperty("performance")]
        public List<Performance> Performance { get; set; }

        [JsonProperty("ageRestriction")]
        public object AgeRestriction { get; set; }

        [JsonProperty("flaggedAsEnded")]
        public bool FlaggedAsEnded { get; set; }

        [JsonProperty("venue")]
        public Venue Venue { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }
    }

    public partial class Location
    {
        [JsonProperty("city")]
        public City City { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lng")]
        public double Lng { get; set; }
    }

    public partial class Performance
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("billing")]
        public Billing Billing { get; set; }

        [JsonProperty("billingIndex")]
        public long BillingIndex { get; set; }

        [JsonProperty("artist")]
        public Artist Artist { get; set; }
    }

    public partial class Artist
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("uri")]
        public Uri Uri { get; set; }

        [JsonProperty("identifier")]
        public List<Identifier> Identifier { get; set; }
    }

    public partial class Identifier
    {
        [JsonProperty("mbid")]
        public Guid Mbid { get; set; }

        [JsonProperty("href")]
        public Uri Href { get; set; }
    }

    public partial class Start
    {
        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("datetime")]
        public string Datetime { get; set; }

        [JsonProperty("time")]
        public DateTimeOffset? Time { get; set; }
    }

    public partial class Venue
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("displayName")]
        public VenueDisplayName DisplayName { get; set; }

        [JsonProperty("uri")]
        public Uri Uri { get; set; }

        [JsonProperty("metroArea")]
        public MetroArea MetroArea { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lng")]
        public double Lng { get; set; }
    }

    public partial class MetroArea
    {
        [JsonProperty("displayName")]
        public MetroAreaDisplayName DisplayName { get; set; }

        [JsonProperty("country")]
        public Country Country { get; set; }

        [JsonProperty("state")]
        public Country State { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("uri")]
        public Uri Uri { get; set; }
    }

    public partial class Country
    {
        [JsonProperty("displayName")]
        public CountryDisplayName DisplayName { get; set; }
    }

    public enum City { CincinnatiOhUs };

    public enum Billing { Headline };

    public enum Status { Cancelled, Ok };

    public enum TypeEnum { Concert };

    public enum VenueDisplayName { LudlowGarage };

    public enum CountryDisplayName { Oh, Us };

    public enum MetroAreaDisplayName { Cincinnati };

    public partial class RootObject
    {
        public static RootObject FromJson(string json) => JsonConvert.DeserializeObject<RootObject>(json, QuickType.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this RootObject self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                CityConverter.Singleton,
                BillingConverter.Singleton,
                StatusConverter.Singleton,
                TypeEnumConverter.Singleton,
                VenueDisplayNameConverter.Singleton,
                CountryDisplayNameConverter.Singleton,
                MetroAreaDisplayNameConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class CityConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(City) || t == typeof(City?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "Cincinnati, OH, US")
            {
                return City.CincinnatiOhUs;
            }
            throw new Exception("Cannot unmarshal type City");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (City)untypedValue;
            if (value == City.CincinnatiOhUs)
            {
                serializer.Serialize(writer, "Cincinnati, OH, US");
                return;
            }
            throw new Exception("Cannot marshal type City");
        }

        public static readonly CityConverter Singleton = new CityConverter();
    }

    internal class BillingConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Billing) || t == typeof(Billing?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "headline")
            {
                return Billing.Headline;
            }
            throw new Exception("Cannot unmarshal type Billing");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Billing)untypedValue;
            if (value == Billing.Headline)
            {
                serializer.Serialize(writer, "headline");
                return;
            }
            throw new Exception("Cannot marshal type Billing");
        }

        public static readonly BillingConverter Singleton = new BillingConverter();
    }

    internal class StatusConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Status) || t == typeof(Status?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "cancelled":
                    return Status.Cancelled;
                case "ok":
                    return Status.Ok;
            }
            throw new Exception("Cannot unmarshal type Status");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Status)untypedValue;
            switch (value)
            {
                case Status.Cancelled:
                    serializer.Serialize(writer, "cancelled");
                    return;
                case Status.Ok:
                    serializer.Serialize(writer, "ok");
                    return;
            }
            throw new Exception("Cannot marshal type Status");
        }

        public static readonly StatusConverter Singleton = new StatusConverter();
    }

    internal class TypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "Concert")
            {
                return TypeEnum.Concert;
            }
            throw new Exception("Cannot unmarshal type TypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TypeEnum)untypedValue;
            if (value == TypeEnum.Concert)
            {
                serializer.Serialize(writer, "Concert");
                return;
            }
            throw new Exception("Cannot marshal type TypeEnum");
        }

        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
    }

    internal class VenueDisplayNameConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(VenueDisplayName) || t == typeof(VenueDisplayName?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "Ludlow Garage")
            {
                return VenueDisplayName.LudlowGarage;
            }
            throw new Exception("Cannot unmarshal type VenueDisplayName");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (VenueDisplayName)untypedValue;
            if (value == VenueDisplayName.LudlowGarage)
            {
                serializer.Serialize(writer, "Ludlow Garage");
                return;
            }
            throw new Exception("Cannot marshal type VenueDisplayName");
        }

        public static readonly VenueDisplayNameConverter Singleton = new VenueDisplayNameConverter();
    }

    internal class CountryDisplayNameConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(CountryDisplayName) || t == typeof(CountryDisplayName?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "OH":
                    return CountryDisplayName.Oh;
                case "US":
                    return CountryDisplayName.Us;
            }
            throw new Exception("Cannot unmarshal type CountryDisplayName");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (CountryDisplayName)untypedValue;
            switch (value)
            {
                case CountryDisplayName.Oh:
                    serializer.Serialize(writer, "OH");
                    return;
                case CountryDisplayName.Us:
                    serializer.Serialize(writer, "US");
                    return;
            }
            throw new Exception("Cannot marshal type CountryDisplayName");
        }

        public static readonly CountryDisplayNameConverter Singleton = new CountryDisplayNameConverter();
    }

    internal class MetroAreaDisplayNameConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(MetroAreaDisplayName) || t == typeof(MetroAreaDisplayName?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "Cincinnati")
            {
                return MetroAreaDisplayName.Cincinnati;
            }
            throw new Exception("Cannot unmarshal type MetroAreaDisplayName");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (MetroAreaDisplayName)untypedValue;
            if (value == MetroAreaDisplayName.Cincinnati)
            {
                serializer.Serialize(writer, "Cincinnati");
                return;
            }
            throw new Exception("Cannot marshal type MetroAreaDisplayName");
        }

        public static readonly MetroAreaDisplayNameConverter Singleton = new MetroAreaDisplayNameConverter();
    }
}
