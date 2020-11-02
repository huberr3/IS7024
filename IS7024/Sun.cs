﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickTypeSun;
//
//    var sun = Sun.FromJson(jsonString);

namespace QuickTypeSun
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Sun
    {
        [JsonProperty("results")]
        public Results Results { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public partial class Results
    {
        [JsonProperty("sunrise")]
        public string Sunrise { get; set; }

        [JsonProperty("sunset")]
        public string Sunset { get; set; }

        [JsonProperty("solar_noon")]
        public string SolarNoon { get; set; }

        [JsonProperty("day_length")]
        public DateTimeOffset DayLength { get; set; }

        [JsonProperty("civil_twilight_begin")]
        public string CivilTwilightBegin { get; set; }

        [JsonProperty("civil_twilight_end")]
        public string CivilTwilightEnd { get; set; }

        [JsonProperty("nautical_twilight_begin")]
        public string NauticalTwilightBegin { get; set; }

        [JsonProperty("nautical_twilight_end")]
        public string NauticalTwilightEnd { get; set; }

        [JsonProperty("astronomical_twilight_begin")]
        public string AstronomicalTwilightBegin { get; set; }

        [JsonProperty("astronomical_twilight_end")]
        public string AstronomicalTwilightEnd { get; set; }
    }

    public partial class Sun
    {
        public static Sun FromJson(string json) => JsonConvert.DeserializeObject<Sun>(json, QuickTypeSun.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Sun self) => JsonConvert.SerializeObject(self, QuickTypeSun.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
