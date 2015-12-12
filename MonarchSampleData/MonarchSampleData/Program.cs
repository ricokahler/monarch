﻿using Geocoding.Google;
using SimpleFixedWidthParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace MonarchSampleData
{
    struct SampleDataThing
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime DateTime { get; set; }

        public SampleDataThing(DateTime dateTime, double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
            DateTime = dateTime;
        }
    }

    struct Reporter
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string StreetAddress { get; set; }
        public string PostalCode { get; set; }
        public string HomePhone { get; set; }
        public string CellPhone { get; set; }
        public string Organization { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Name: " + Name);
            sb.AppendLine("UserName: " + UserName);
            sb.AppendLine("StreetAddress: " + StreetAddress);
            sb.AppendLine("PostalCode: " + PostalCode);
            sb.AppendLine("HomePhone: " + HomePhone);
            sb.AppendLine("CellPhone: " + CellPhone);
            sb.AppendLine("Organization: " + Organization);

            return sb.ToString();
        }
    }

    struct HumanSighting
    {
        public string UserName { get; set; }
        public DateTime DateTime { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string Country { get; set; }
        public string Species { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine("UserName: " + UserName);
            sb.AppendLine("DateTime: " + DateTime);
            sb.AppendLine("Latitude: " + Latitude);
            sb.AppendLine("Longitude: " + Longitude);
            sb.AppendLine("City: " + City);
            sb.AppendLine("StateProvince: " + StateProvince);
            sb.AppendLine("Country: " + Country);
            sb.AppendLine("Species: " + Species);

            return sb.ToString();
        }
    }

    struct CityState
    {
        public string City { get; set; }
        public string State { get; set; }
        public CityState(string city, string state)
        {
            City = city.ToLower();
            State = state.ToLower();
        }

        public override int GetHashCode()
        {
            return (City + State).GetHashCode();
        }
    }

    struct FirstLast
    {
        public string First { get; set; }
        public string Last { get; set; }
        public FirstLast(string first, string last)
        {
            First = first;
            Last = last;
        }
    }

    class Program
    {
        static string[] Organizations = { "Butterflies-R-Us", "Journey-North",  "Earthbound", "Mother", "Hoppipolla" };
        static Random rand;

        /// <summary>
        /// Thank you https://www.learner.org/cgi-bin/jnorth/jn-query-byday
        /// </summary>
        /// <returns></returns>
        static List<SampleDataThing> GetSampleData()
        {
            return new List<SampleDataThing>
            {
                new SampleDataThing(DateTime.Parse("2015-11-13"), 32.67, -79.94),
                new SampleDataThing(DateTime.Parse("2015-11-10"), 25.42, -101),
                new SampleDataThing(DateTime.Parse("2015-11-09"), 20.7, -100.45),
                new SampleDataThing(DateTime.Parse("2015-11-08"), 20.65, -100.44),
                new SampleDataThing(DateTime.Parse("2015-11-05"), 20.91, -100.74),
                new SampleDataThing(DateTime.Parse("2015-11-05"), 20.91, -100.33),
                new SampleDataThing(DateTime.Parse("2015-11-05"), 21.7, -100.85),
                new SampleDataThing(DateTime.Parse("2015-11-04"), 21.33, -99.67),
                new SampleDataThing(DateTime.Parse("2015-11-03"), 19.58, -100.34),
                new SampleDataThing(DateTime.Parse("2015-11-03"), 23.03, -99.15),
                new SampleDataThing(DateTime.Parse("2015-11-03"), 22.98, -99.64),
                new SampleDataThing(DateTime.Parse("2015-11-03"), 22.95, -99.61),
                new SampleDataThing(DateTime.Parse("2015-11-03"), 23.92, -99.58),
                new SampleDataThing(DateTime.Parse("2015-11-03"), 22.9, -99.53),
                new SampleDataThing(DateTime.Parse("2015-11-03"), 22.9, -99.53),
                new SampleDataThing(DateTime.Parse("2015-11-03"), 22.92, -99.52),
                new SampleDataThing(DateTime.Parse("2015-11-03"), 22.91, -99.49),
                new SampleDataThing(DateTime.Parse("2015-11-02"), 29.55, -98.34),
                new SampleDataThing(DateTime.Parse("2015-11-02"), 22.88, -99.03),
                new SampleDataThing(DateTime.Parse("2015-11-02"), 25.69, -100.23),
                new SampleDataThing(DateTime.Parse("2015-11-02"), 25.37, -101.01),
                new SampleDataThing(DateTime.Parse("2015-11-02"), 23.05, -99.17),
                new SampleDataThing(DateTime.Parse("2015-11-02"), 23.39, -99.5),
                new SampleDataThing(DateTime.Parse("2015-11-02"), 23.41, -99.38),
                new SampleDataThing(DateTime.Parse("2015-11-02"), 23.3, -99.63),
                new SampleDataThing(DateTime.Parse("2015-11-02"), 23.3, -99.65),
                new SampleDataThing(DateTime.Parse("2015-11-02"), 23.27, -99.68),
                new SampleDataThing(DateTime.Parse("2015-11-02"), 23.13, -99.7),
                new SampleDataThing(DateTime.Parse("2015-11-01"), 19.77, -101.19),
                new SampleDataThing(DateTime.Parse("2015-11-01"), 23.76, -99.16),
                new SampleDataThing(DateTime.Parse("2015-11-01"), 19.62, -100.3),
                new SampleDataThing(DateTime.Parse("2015-11-01"), 25.68, -100.26),
                new SampleDataThing(DateTime.Parse("2015-10-31"), 23.6, -99.22),
                new SampleDataThing(DateTime.Parse("2015-10-31"), 30.32, -97.82),
                new SampleDataThing(DateTime.Parse("2015-10-31"), 30.23, -97.71),
                new SampleDataThing(DateTime.Parse("2015-10-31"), 23.76, -99.16),
                new SampleDataThing(DateTime.Parse("2015-10-31"), 23.63, -99.4),
                new SampleDataThing(DateTime.Parse("2015-10-31"), 25.42, -101),
                new SampleDataThing(DateTime.Parse("2015-10-31"), 25.42, -101),
                new SampleDataThing(DateTime.Parse("2015-10-31"), 25.42, -101),
                new SampleDataThing(DateTime.Parse("2015-10-29"), 25.71, -100.27),
                new SampleDataThing(DateTime.Parse("2015-10-29"), 25.67, -100.3),
                new SampleDataThing(DateTime.Parse("2015-10-29"), 22.15, -100.84),
                new SampleDataThing(DateTime.Parse("2015-10-29"), 21.98, -99.02),
                new SampleDataThing(DateTime.Parse("2015-10-29"), 25.61, -100.37),
                new SampleDataThing(DateTime.Parse("2015-10-29"), 25.42, -101.83),
                new SampleDataThing(DateTime.Parse("2015-10-29"), 23.67, -100.17),
                new SampleDataThing(DateTime.Parse("2015-10-28"), 28.86, -97.03),
                new SampleDataThing(DateTime.Parse("2015-10-28"), 25.68, -100.25),
                new SampleDataThing(DateTime.Parse("2015-10-28"), 25.69, -100.27),
                new SampleDataThing(DateTime.Parse("2015-10-28"), 23.03, -99.15),
                new SampleDataThing(DateTime.Parse("2015-10-28"), 25.75, -100.28),
                new SampleDataThing(DateTime.Parse("2015-10-27"), 23.73, -99.18),
                new SampleDataThing(DateTime.Parse("2015-10-27"), 25.67, -100.21),
                new SampleDataThing(DateTime.Parse("2015-10-27"), 25.69, -100.26),
                new SampleDataThing(DateTime.Parse("2015-10-27"), 29.28, -94.83),
                new SampleDataThing(DateTime.Parse("2015-10-27"), 25.42, -101),
                new SampleDataThing(DateTime.Parse("2015-10-27"), 25.65, -100.36),
                new SampleDataThing(DateTime.Parse("2015-10-27"), 25.43, -100.13),
                new SampleDataThing(DateTime.Parse("2015-10-27"), 25.55, -100.97),
                new SampleDataThing(DateTime.Parse("2015-10-27"), 25.62, -100.24),
                new SampleDataThing(DateTime.Parse("2015-10-26"), 25.68, -100.23),
                new SampleDataThing(DateTime.Parse("2015-10-26"), 25.69, -100.27),
                new SampleDataThing(DateTime.Parse("2015-10-26"), 25.66, -100.45),
                new SampleDataThing(DateTime.Parse("2015-10-26"), 25.67, -100.3),
                new SampleDataThing(DateTime.Parse("2015-10-26"), 29.22, -98.86),
                new SampleDataThing(DateTime.Parse("2015-10-26"), 25.72, -100.29),
                new SampleDataThing(DateTime.Parse("2015-10-26"), 25.67, -100.3),
                new SampleDataThing(DateTime.Parse("2015-10-26"), 25.67, -100.3),
                new SampleDataThing(DateTime.Parse("2015-10-26"), 25.42, -101),
                new SampleDataThing(DateTime.Parse("2015-10-26"), 25.42, -101),
                new SampleDataThing(DateTime.Parse("2015-10-26"), 25.8, -100.26),
                new SampleDataThing(DateTime.Parse("2015-10-26"), 25.61, -100.37),
                new SampleDataThing(DateTime.Parse("2015-10-26"), 25.75, -100.28),
                new SampleDataThing(DateTime.Parse("2015-10-26"), 25.68, -100.26),
                new SampleDataThing(DateTime.Parse("2015-10-26"), 25.67, -100.3),
                new SampleDataThing(DateTime.Parse("2015-10-26"), 25.67, -100.3),
                new SampleDataThing(DateTime.Parse("2015-10-26"), 26.91, -101.42),
                new SampleDataThing(DateTime.Parse("2015-10-26"), 25.75, -100.28),
                new SampleDataThing(DateTime.Parse("2015-10-26"), 25.67, -100.3),
                new SampleDataThing(DateTime.Parse("2015-10-25"), 29.22, -98.86),
                new SampleDataThing(DateTime.Parse("2015-10-25"), 29.22, -98.86),
                new SampleDataThing(DateTime.Parse("2015-10-25"), 25.66, -100.33),
                new SampleDataThing(DateTime.Parse("2015-10-25"), 23.73, -99.18),
                new SampleDataThing(DateTime.Parse("2015-10-25"), 24.25, -99.57),
                new SampleDataThing(DateTime.Parse("2015-10-25"), 25.42, -101),
                new SampleDataThing(DateTime.Parse("2015-10-25"), 25.67, -100.3),
                new SampleDataThing(DateTime.Parse("2015-10-25"), 25.67, -100.3),
                new SampleDataThing(DateTime.Parse("2015-10-25"), 25.67, -100.3),
                new SampleDataThing(DateTime.Parse("2015-10-25"), 25.67, -100.3),
                new SampleDataThing(DateTime.Parse("2015-10-25"), 25.42, -101),
                new SampleDataThing(DateTime.Parse("2015-10-25"), 25.67, -100.3),
                new SampleDataThing(DateTime.Parse("2015-10-25"), 25.68, -100.26),
                new SampleDataThing(DateTime.Parse("2015-10-25"), 25.42, -101),
                new SampleDataThing(DateTime.Parse("2015-10-24"), 25.42, -100.15),
                new SampleDataThing(DateTime.Parse("2015-10-23"), 29.45, -102.82),
                new SampleDataThing(DateTime.Parse("2015-10-23"), 30.02, -103.02),
                new SampleDataThing(DateTime.Parse("2015-10-23"), 30.74, -101.65),
                new SampleDataThing(DateTime.Parse("2015-10-23"), 25.42, -101),
                new SampleDataThing(DateTime.Parse("2015-10-23"), 35.21, -101.84),
                new SampleDataThing(DateTime.Parse("2015-10-22"), 30.48, -87.86),
                new SampleDataThing(DateTime.Parse("2015-10-21"), 32.84, -79.72),
                new SampleDataThing(DateTime.Parse("2015-10-21"), 32.76, -79.86),
                new SampleDataThing(DateTime.Parse("2015-10-21"), 25.42, -101),
                new SampleDataThing(DateTime.Parse("2015-10-21"), 25.63, -100.74),
                new SampleDataThing(DateTime.Parse("2015-10-21"), 25.42, -101),
                new SampleDataThing(DateTime.Parse("2015-10-20"), 35.64, -101.6),
                new SampleDataThing(DateTime.Parse("2015-10-20"), 29.84, -103.56),
                new SampleDataThing(DateTime.Parse("2015-10-20"), 30.55, -87.61),
                new SampleDataThing(DateTime.Parse("2015-10-20"), 33.06, -96.73),
                new SampleDataThing(DateTime.Parse("2015-10-20"), 27.02, -102.09),
                new SampleDataThing(DateTime.Parse("2015-10-20"), 25.42, -101),
                new SampleDataThing(DateTime.Parse("2015-10-20"), 25.42, -101),
                new SampleDataThing(DateTime.Parse("2015-10-20"), 25.42, -101),
                new SampleDataThing(DateTime.Parse("2015-10-20"), 32.84, -79.72),
                new SampleDataThing(DateTime.Parse("2015-10-20"), 27.01, -101.88),
                new SampleDataThing(DateTime.Parse("2015-10-20"), 25.67, -100.3),
                new SampleDataThing(DateTime.Parse("2015-10-20"), 32.08, -81.11),
                new SampleDataThing(DateTime.Parse("2015-10-19"), 35.64, -101.6),
                new SampleDataThing(DateTime.Parse("2015-10-19"), 35.59, -82.56),
                new SampleDataThing(DateTime.Parse("2015-10-19"), 25.68, -100.45),
                new SampleDataThing(DateTime.Parse("2015-10-19"), 26.97, -102.08),
                new SampleDataThing(DateTime.Parse("2015-10-19"), 27.31, -102.4),
                new SampleDataThing(DateTime.Parse("2015-10-19"), 27.04, -101.7),
                new SampleDataThing(DateTime.Parse("2015-10-18"), 27.83, -97.22),
                new SampleDataThing(DateTime.Parse("2015-10-18"), 30.45, -86.63),
                new SampleDataThing(DateTime.Parse("2015-10-18"), 29.73, -99.97),
                new SampleDataThing(DateTime.Parse("2015-10-18"), 25.78, -103.42),
                new SampleDataThing(DateTime.Parse("2015-10-18"), 33.06, -96.73),
                new SampleDataThing(DateTime.Parse("2015-10-18"), 32.76, -79.86),
                new SampleDataThing(DateTime.Parse("2015-10-18"), 25.44, -102.18),
                new SampleDataThing(DateTime.Parse("2015-10-18"), 25.91, -102.37),
                new SampleDataThing(DateTime.Parse("2015-10-18"), 28.23, -97.02),
                new SampleDataThing(DateTime.Parse("2015-10-18"), 30.62, -99.66),
                new SampleDataThing(DateTime.Parse("2015-10-18"), 30.41, -99.58),
                new SampleDataThing(DateTime.Parse("2015-10-18"), 26.29, -101.35),
                new SampleDataThing(DateTime.Parse("2015-10-17"), 30.06, -95.38),
                new SampleDataThing(DateTime.Parse("2015-10-17"), 29.85, -100.88),
                new SampleDataThing(DateTime.Parse("2015-10-17"), 25.42, -101),
                new SampleDataThing(DateTime.Parse("2015-10-17"), 31.99, -102.08),
                new SampleDataThing(DateTime.Parse("2015-10-17"), 27.94, -101.22),
                new SampleDataThing(DateTime.Parse("2015-10-17"), 25.68, -100.45),
                new SampleDataThing(DateTime.Parse("2015-10-16"), 25.78, -103.35),
                new SampleDataThing(DateTime.Parse("2015-10-16"), 32.45, -103.22),
                new SampleDataThing(DateTime.Parse("2015-10-16"), 39.57, -74.23),
                new SampleDataThing(DateTime.Parse("2015-10-16"), 29.02, -102.12),
                new SampleDataThing(DateTime.Parse("2015-10-16"), 30.68, -102.8),
                new SampleDataThing(DateTime.Parse("2015-10-16"), 33.79, -83.36),
                new SampleDataThing(DateTime.Parse("2015-10-15"), 37.25, -97.37),
                new SampleDataThing(DateTime.Parse("2015-10-15"), 30.41, -99.58),
                new SampleDataThing(DateTime.Parse("2015-10-15"), 33.18, -97.3),
                new SampleDataThing(DateTime.Parse("2015-10-15"), 28.49, -100.92),
                new SampleDataThing(DateTime.Parse("2015-10-14"), 35.2, -101.85),
                new SampleDataThing(DateTime.Parse("2015-10-14"), 28.51, -100.53),
                new SampleDataThing(DateTime.Parse("2015-10-14"), 26.99, -102.07),
                new SampleDataThing(DateTime.Parse("2015-10-14"), 27.88, -101.52),
                new SampleDataThing(DateTime.Parse("2015-10-14"), 26.96, -101.4),
                new SampleDataThing(DateTime.Parse("2015-10-13"), 33.59, -101.85),
                new SampleDataThing(DateTime.Parse("2015-10-13"), 30.41, -99.58),
                new SampleDataThing(DateTime.Parse("2015-10-13"), 27.88, -101.52),
                new SampleDataThing(DateTime.Parse("2015-10-13"), 30.03, -99.09),
                new SampleDataThing(DateTime.Parse("2015-10-13"), 27.86, -101.12),
                new SampleDataThing(DateTime.Parse("2015-10-13"), 34.69, -101.74),
                new SampleDataThing(DateTime.Parse("2015-10-13"), 33.06, -96.73),
                new SampleDataThing(DateTime.Parse("2015-10-13"), 27.86, -101.12),
                new SampleDataThing(DateTime.Parse("2015-10-13"), 28.51, -100.53),
                new SampleDataThing(DateTime.Parse("2015-10-13"), 29.65, -99.77),
                new SampleDataThing(DateTime.Parse("2015-10-13"), 29.52, -100.91),
                new SampleDataThing(DateTime.Parse("2015-10-13"), 29.86, -99.8),
                new SampleDataThing(DateTime.Parse("2015-10-13"), 33.58, -91.79),
                new SampleDataThing(DateTime.Parse("2015-10-13"), 28.22, -100.72),
                new SampleDataThing(DateTime.Parse("2015-10-13"), 29.57, -99.57),
                new SampleDataThing(DateTime.Parse("2015-10-13"), 29.68, -100.03),
                new SampleDataThing(DateTime.Parse("2015-10-13"), 29.77, -99.35),
                new SampleDataThing(DateTime.Parse("2015-10-13"), 29.32, -100.93),
                new SampleDataThing(DateTime.Parse("2015-10-13"), 27.86, -101.12),
                new SampleDataThing(DateTime.Parse("2015-10-13"), 29.32, -100.93),
                new SampleDataThing(DateTime.Parse("2015-10-13"), 29.28, -100.57),
                new SampleDataThing(DateTime.Parse("2015-10-13"), 39.57, -74.23),
                new SampleDataThing(DateTime.Parse("2015-10-13"), 35.48, -79.18),
                new SampleDataThing(DateTime.Parse("2015-10-12"), 30.41, -99.58),
                new SampleDataThing(DateTime.Parse("2015-10-12"), 30.84, -98.26),
                new SampleDataThing(DateTime.Parse("2015-10-12"), 30.41, -99.58),
                new SampleDataThing(DateTime.Parse("2015-10-12"), 29.92, -100.97),
                new SampleDataThing(DateTime.Parse("2015-10-12"), 35.25, -80.83),
                new SampleDataThing(DateTime.Parse("2015-10-12"), 41.64, -71.05),
                new SampleDataThing(DateTime.Parse("2015-10-12"), 41.6, -73.88),
                new SampleDataThing(DateTime.Parse("2015-10-12"), 32.79, -96.8),
                new SampleDataThing(DateTime.Parse("2015-10-12"), 37.06, -122.16),
                new SampleDataThing(DateTime.Parse("2015-10-11"), 38.03, -100.88),
                new SampleDataThing(DateTime.Parse("2015-10-11"), 30.41, -99.58),
                new SampleDataThing(DateTime.Parse("2015-10-10"), 36, -96.74),
                new SampleDataThing(DateTime.Parse("2015-10-10"), 30.57, -100.64),
                new SampleDataThing(DateTime.Parse("2015-10-10"), 33.64, -96.55),
                new SampleDataThing(DateTime.Parse("2015-10-10"), 35.43, -97.52),
                new SampleDataThing(DateTime.Parse("2015-10-10"), 30.41, -99.58),
                new SampleDataThing(DateTime.Parse("2015-10-10"), 30.57, -100.64),
                new SampleDataThing(DateTime.Parse("2015-10-10"), 33.05, -91.58),
                new SampleDataThing(DateTime.Parse("2015-10-10"), 35.68, -97.58),
                new SampleDataThing(DateTime.Parse("2015-10-10"), 35.68, -97.58),
                new SampleDataThing(DateTime.Parse("2015-10-10"), 29.77, -99.35),
                new SampleDataThing(DateTime.Parse("2015-10-10"), 33.19, -91.99),
                new SampleDataThing(DateTime.Parse("2015-10-10"), 40.62, -73.26),
                new SampleDataThing(DateTime.Parse("2015-10-10"), 32.53, -92.1),
                new SampleDataThing(DateTime.Parse("2015-10-10"), 32.55, -96.86),
                new SampleDataThing(DateTime.Parse("2015-10-09"), 37.43, -79.93),
                new SampleDataThing(DateTime.Parse("2015-10-09"), 31.88, -100.53),
                new SampleDataThing(DateTime.Parse("2015-10-09"), 33.32, -111.87),
                new SampleDataThing(DateTime.Parse("2015-10-09"), 35.84, -97.48),
                new SampleDataThing(DateTime.Parse("2015-10-09"), 34.34, -86.43),
                new SampleDataThing(DateTime.Parse("2015-10-09"), 32.77, -91.71),
                new SampleDataThing(DateTime.Parse("2015-10-09"), 38.49, -101.36),
                new SampleDataThing(DateTime.Parse("2015-10-09"), 35.23, -82.87),
                new SampleDataThing(DateTime.Parse("2015-10-09"), 38.1, -78.44),
                new SampleDataThing(DateTime.Parse("2015-10-08"), 35.26, -99.23),
                new SampleDataThing(DateTime.Parse("2015-10-08"), 38.39, -98.83),
                new SampleDataThing(DateTime.Parse("2015-10-08"), 35.35, -82.79),
                new SampleDataThing(DateTime.Parse("2015-10-08"), 36.02, -78.7),
                new SampleDataThing(DateTime.Parse("2015-10-08"), 35.16, -89.78),
                new SampleDataThing(DateTime.Parse("2015-10-08"), 33.52, -111.91),
                new SampleDataThing(DateTime.Parse("2015-10-08"), 33.37, -99.88),
                new SampleDataThing(DateTime.Parse("2015-10-08"), 36.11, -80.2),
                new SampleDataThing(DateTime.Parse("2015-10-07"), 31.88, -100.53),
                new SampleDataThing(DateTime.Parse("2015-10-07"), 38.8, -104.53),
                new SampleDataThing(DateTime.Parse("2015-10-07"), 39.79, -101.84),
                new SampleDataThing(DateTime.Parse("2015-10-07"), 40.59, -102.22),
                new SampleDataThing(DateTime.Parse("2015-10-07"), 32.13, -97.85),
                new SampleDataThing(DateTime.Parse("2015-10-07"), 40.62, -73.26),
                new SampleDataThing(DateTime.Parse("2015-10-07"), 38.06, -76.33),
                new SampleDataThing(DateTime.Parse("2015-10-07"), 39.79, -101.84),
                new SampleDataThing(DateTime.Parse("2015-10-07"), 39.77, -101.8),
                new SampleDataThing(DateTime.Parse("2015-10-07"), 30.84, -98.26),
                new SampleDataThing(DateTime.Parse("2015-10-07"), 35.06, -82.78),
                new SampleDataThing(DateTime.Parse("2015-10-06"), 39.24, -99.28),
                new SampleDataThing(DateTime.Parse("2015-10-06"), 38.98, -104.53),
                new SampleDataThing(DateTime.Parse("2015-10-06"), 32.13, -97.85),
                new SampleDataThing(DateTime.Parse("2015-10-06"), 32.82, -101.09),
                new SampleDataThing(DateTime.Parse("2015-10-06"), 35.59, -82.56),
                new SampleDataThing(DateTime.Parse("2015-10-06"), 38.83, -104.82),
                new SampleDataThing(DateTime.Parse("2015-10-06"), 40.79, -77.9),
                new SampleDataThing(DateTime.Parse("2015-10-05"), 32.48, -99.68),
                new SampleDataThing(DateTime.Parse("2015-10-05"), 32.13, -97.85),
                new SampleDataThing(DateTime.Parse("2015-10-05"), 31.9, -100.48),
                new SampleDataThing(DateTime.Parse("2015-10-04"), 41.12, -76.84),
                new SampleDataThing(DateTime.Parse("2015-10-04"), 32.48, -99.68),
                new SampleDataThing(DateTime.Parse("2015-10-04"), 32.79, -96.8),
                new SampleDataThing(DateTime.Parse("2015-10-04"), 33.38, -99.84),
                new SampleDataThing(DateTime.Parse("2015-10-04"), 33.64, -96.55),
                new SampleDataThing(DateTime.Parse("2015-10-03"), 33.08, -99.96),
                new SampleDataThing(DateTime.Parse("2015-10-02"), 35.26, -99.23),
                new SampleDataThing(DateTime.Parse("2015-10-02"), 35.33, -99.66),
                new SampleDataThing(DateTime.Parse("2015-10-01"), 33.85, -94.78),
                new SampleDataThing(DateTime.Parse("2015-10-01"), 35.59, -82.56),
                new SampleDataThing(DateTime.Parse("2015-09-30"), 33.8, -96.7),
                new SampleDataThing(DateTime.Parse("2015-09-30"), 35.55, -97.96),
                new SampleDataThing(DateTime.Parse("2015-09-30"), 35.28, -99.13),
                new SampleDataThing(DateTime.Parse("2015-09-30"), 38.39, -98.83),
                new SampleDataThing(DateTime.Parse("2015-09-30"), 39.77, -101.8),
                new SampleDataThing(DateTime.Parse("2015-09-29"), 38.55, -90.38),
                new SampleDataThing(DateTime.Parse("2015-09-29"), 35.68, -97.58),
                new SampleDataThing(DateTime.Parse("2015-09-29"), 35.68, -97.58),
                new SampleDataThing(DateTime.Parse("2015-09-28"), 38.17, -91.22),
                new SampleDataThing(DateTime.Parse("2015-09-28"), 41.26, -95.93),
                new SampleDataThing(DateTime.Parse("2015-09-28"), 38.62, -90.28),
                new SampleDataThing(DateTime.Parse("2015-09-28"), 40.84, -98.98),
                new SampleDataThing(DateTime.Parse("2015-09-27"), 43.09, -89.33),
                new SampleDataThing(DateTime.Parse("2015-09-27"), 41.26, -95.93),
                new SampleDataThing(DateTime.Parse("2015-09-27"), 35.97, -83.62),
                new SampleDataThing(DateTime.Parse("2015-09-27"), 36.06, -112.14),
                new SampleDataThing(DateTime.Parse("2015-09-27"), 34.72, -112.88),
                new SampleDataThing(DateTime.Parse("2015-09-27"), 36.07, -89.42),
                new SampleDataThing(DateTime.Parse("2015-09-27"), 35.21, -93.05),
                new SampleDataThing(DateTime.Parse("2015-09-26"), 37.57, -97.38),
                new SampleDataThing(DateTime.Parse("2015-09-26"), 36.8, -98.67),
                new SampleDataThing(DateTime.Parse("2015-09-26"), 37.69, -97.33),
                new SampleDataThing(DateTime.Parse("2015-09-26"), 35.63, -83.78),
                new SampleDataThing(DateTime.Parse("2015-09-26"), 39.67, -78.78),
                new SampleDataThing(DateTime.Parse("2015-09-26"), 35.78, -95.21),
                new SampleDataThing(DateTime.Parse("2015-09-25"), 38.68, -93.26),
                new SampleDataThing(DateTime.Parse("2015-09-25"), 39.1, -94.6),
                new SampleDataThing(DateTime.Parse("2015-09-25"), 39.1, -94.6),
                new SampleDataThing(DateTime.Parse("2015-09-25"), 38.97, -94.62),
                new SampleDataThing(DateTime.Parse("2015-09-25"), 43.55, -96.73),
                new SampleDataThing(DateTime.Parse("2015-09-25"), 39.21, -94.57),
                new SampleDataThing(DateTime.Parse("2015-09-25"), 42.07, -91.57),
                new SampleDataThing(DateTime.Parse("2015-09-24"), 43.7, -79.42),
                new SampleDataThing(DateTime.Parse("2015-09-24"), 36.76, -98.37),
                new SampleDataThing(DateTime.Parse("2015-09-24"), 38.96, -94.79),
                new SampleDataThing(DateTime.Parse("2015-09-24"), 36.18, -83.26),
                new SampleDataThing(DateTime.Parse("2015-09-23"), 43.59, -79.51),
                new SampleDataThing(DateTime.Parse("2015-09-23"), 43.43, -95.15),
                new SampleDataThing(DateTime.Parse("2015-09-23"), 41.97, -91.66),
                new SampleDataThing(DateTime.Parse("2015-09-23"), 37.94, -91.77),
                new SampleDataThing(DateTime.Parse("2015-09-23"), 43.72, -79.22),
                new SampleDataThing(DateTime.Parse("2015-09-23"), 42.67, -81.22),
                new SampleDataThing(DateTime.Parse("2015-09-23"), 38.25, -90.59),
                new SampleDataThing(DateTime.Parse("2015-09-23"), 41.91, -93.41),
                new SampleDataThing(DateTime.Parse("2015-09-23"), 43.17, -95.8),
                new SampleDataThing(DateTime.Parse("2015-09-23"), 43.7, -79.42),
                new SampleDataThing(DateTime.Parse("2015-09-23"), 37.69, -97.33),
                new SampleDataThing(DateTime.Parse("2015-09-23"), 38.24, -92.46),
                new SampleDataThing(DateTime.Parse("2015-09-23"), 42.62, -91.91),
                new SampleDataThing(DateTime.Parse("2015-09-22"), 38.5, -92.15),
                new SampleDataThing(DateTime.Parse("2015-09-22"), 42.08, -83.19),
                new SampleDataThing(DateTime.Parse("2015-09-22"), 41.26, -95.93),
                new SampleDataThing(DateTime.Parse("2015-09-22"), 43.78, -79.25),
                new SampleDataThing(DateTime.Parse("2015-09-22"), 42.07, -92.94),
                new SampleDataThing(DateTime.Parse("2015-09-22"), 42.66, -81.17),
                new SampleDataThing(DateTime.Parse("2015-09-22"), 42.65, -80.82),
                new SampleDataThing(DateTime.Parse("2015-09-22"), 38.5, -92.15),
                new SampleDataThing(DateTime.Parse("2015-09-21"), 38.63, -90.19),
                new SampleDataThing(DateTime.Parse("2015-09-21"), 38.63, -90.47),
                new SampleDataThing(DateTime.Parse("2015-09-21"), 42.67, -81.22),
                new SampleDataThing(DateTime.Parse("2015-09-21"), 42.41, -82.89),
                new SampleDataThing(DateTime.Parse("2015-09-21"), 40.17, -92.58),
                new SampleDataThing(DateTime.Parse("2015-09-21"), 38.94, -74.96),
                new SampleDataThing(DateTime.Parse("2015-09-21"), 38.72, -123.45),
                new SampleDataThing(DateTime.Parse("2015-09-21"), 40.63, -73.22),
                new SampleDataThing(DateTime.Parse("2015-09-21"), 45.43, -94.74),
                new SampleDataThing(DateTime.Parse("2015-09-20"), 40.79, -74.33),
                new SampleDataThing(DateTime.Parse("2015-09-20"), 44.63, -75.95),
                new SampleDataThing(DateTime.Parse("2015-09-20"), 43.7, -79.42),
                new SampleDataThing(DateTime.Parse("2015-09-20"), 42.63, -70.69),
                new SampleDataThing(DateTime.Parse("2015-09-20"), 41.21, -73.13),
                new SampleDataThing(DateTime.Parse("2015-09-20"), 43.78, -79.25),
                new SampleDataThing(DateTime.Parse("2015-09-20"), 43.7, -79.42),
                new SampleDataThing(DateTime.Parse("2015-09-20"), 40.67, -73.04),
                new SampleDataThing(DateTime.Parse("2015-09-20"), 40.62, -73.26),
                new SampleDataThing(DateTime.Parse("2015-09-20"), 40.62, -73.26),
                new SampleDataThing(DateTime.Parse("2015-09-19"), 40.48, -89.49),
                new SampleDataThing(DateTime.Parse("2015-09-19"), 42.79, -76.24),
                new SampleDataThing(DateTime.Parse("2015-09-19"), 38.97, -76.14),
                new SampleDataThing(DateTime.Parse("2015-09-19"), 44.86, -93.67),
                new SampleDataThing(DateTime.Parse("2015-09-19"), 44.65, -83.36),
                new SampleDataThing(DateTime.Parse("2015-09-19"), 38.39, -98.83),
                new SampleDataThing(DateTime.Parse("2015-09-19"), 40.13, -88.18),
                new SampleDataThing(DateTime.Parse("2015-09-19"), 42.46, -81.7),
                new SampleDataThing(DateTime.Parse("2015-09-19"), 38.94, -74.9),
                new SampleDataThing(DateTime.Parse("2015-09-19"), 38.03, -98.09),
                new SampleDataThing(DateTime.Parse("2015-09-19"), 41.45, -74.25),
                new SampleDataThing(DateTime.Parse("2015-09-19"), 41.76, -93.99),
                new SampleDataThing(DateTime.Parse("2015-09-19"), 40.62, -73.26),
                new SampleDataThing(DateTime.Parse("2015-09-18"), 40.54, -77.76),
                new SampleDataThing(DateTime.Parse("2015-09-18"), 43.9, -69.63),
                new SampleDataThing(DateTime.Parse("2015-09-18"), 36.58, -98.88),
                new SampleDataThing(DateTime.Parse("2015-09-18"), 37.69, -97.33),
                new SampleDataThing(DateTime.Parse("2015-09-18"), 40.48, -89.49),
                new SampleDataThing(DateTime.Parse("2015-09-18"), 37.69, -97.33),
                new SampleDataThing(DateTime.Parse("2015-09-18"), 37.69, -97.33),
                new SampleDataThing(DateTime.Parse("2015-09-18"), 40.77, -80.37),
                new SampleDataThing(DateTime.Parse("2015-09-18"), 38.39, -98.83),
                new SampleDataThing(DateTime.Parse("2015-09-18"), 41.92, -82.51),
                new SampleDataThing(DateTime.Parse("2015-09-18"), 40.28, -77.28),
                new SampleDataThing(DateTime.Parse("2015-09-18"), 43.78, -79.25),
                new SampleDataThing(DateTime.Parse("2015-09-18"), 41.68, -111.65),
                new SampleDataThing(DateTime.Parse("2015-09-17"), 42.52, -86.2),
                new SampleDataThing(DateTime.Parse("2015-09-17"), 41.51, -96.79),
                new SampleDataThing(DateTime.Parse("2015-09-17"), 41.37, -81.92),
                new SampleDataThing(DateTime.Parse("2015-09-17"), 41.37, -81.92),
                new SampleDataThing(DateTime.Parse("2015-09-17"), 40.48, -89.49),
                new SampleDataThing(DateTime.Parse("2015-09-17"), 41.14, -95.89),
                new SampleDataThing(DateTime.Parse("2015-09-17"), 41.51, -83.58),
                new SampleDataThing(DateTime.Parse("2015-09-17"), 39.93, -77.67),
                new SampleDataThing(DateTime.Parse("2015-09-17"), 38.39, -98.83),
                new SampleDataThing(DateTime.Parse("2015-09-17"), 40.56, -98.37),
                new SampleDataThing(DateTime.Parse("2015-09-17"), 42.97, -76.32),
                new SampleDataThing(DateTime.Parse("2015-09-17"), 41.32, -81.44),
                new SampleDataThing(DateTime.Parse("2015-09-17"), 40.73, -88.52),
                new SampleDataThing(DateTime.Parse("2015-09-17"), 43.99, -69.27),
                new SampleDataThing(DateTime.Parse("2015-09-17"), 40.05, -86.02),
                new SampleDataThing(DateTime.Parse("2015-09-16"), 39.37, -84.36),
                new SampleDataThing(DateTime.Parse("2015-09-16"), 39.3, -85.22),
                new SampleDataThing(DateTime.Parse("2015-09-16"), 43.74, -87.78),
                new SampleDataThing(DateTime.Parse("2015-09-16"), 40.48, -89.49),
                new SampleDataThing(DateTime.Parse("2015-09-16"), 41.51, -83.58),
                new SampleDataThing(DateTime.Parse("2015-09-16"), 41.38, -81.44),
                new SampleDataThing(DateTime.Parse("2015-09-16"), 42.67, -81.22),
                new SampleDataThing(DateTime.Parse("2015-09-16"), 41.97, -91.66),
                new SampleDataThing(DateTime.Parse("2015-09-16"), 41.38, -81.71),
                new SampleDataThing(DateTime.Parse("2015-09-16"), 43.1, -79.15),
                new SampleDataThing(DateTime.Parse("2015-09-16"), 41.38, -81.71),
                new SampleDataThing(DateTime.Parse("2015-09-16"), 41.63, -87.07),
                new SampleDataThing(DateTime.Parse("2015-09-16"), 41.26, -95.93),
                new SampleDataThing(DateTime.Parse("2015-09-16"), 43.78, -79.25),
                new SampleDataThing(DateTime.Parse("2015-09-16"), 39.35, -84.5),
                new SampleDataThing(DateTime.Parse("2015-09-16"), 41.68, -86.99),
                new SampleDataThing(DateTime.Parse("2015-09-16"), 40.19, -75.44),
                new SampleDataThing(DateTime.Parse("2015-09-16"), 44.22, -78.72),
                new SampleDataThing(DateTime.Parse("2015-09-16"), 38.94, -74.96),
                new SampleDataThing(DateTime.Parse("2015-09-16"), 39.8, -85.53),
                new SampleDataThing(DateTime.Parse("2015-09-16"), 38.03, -78.86),
                new SampleDataThing(DateTime.Parse("2015-09-15"), 41.21, -74.81),
                new SampleDataThing(DateTime.Parse("2015-09-15"), 42.52, -86.2),
                new SampleDataThing(DateTime.Parse("2015-09-15"), 40.16, -80.71),
                new SampleDataThing(DateTime.Parse("2015-09-15"), 41.66, -87.04),
                new SampleDataThing(DateTime.Parse("2015-09-15"), 42.52, -86.2),
                new SampleDataThing(DateTime.Parse("2015-09-15"), 41.48, -81.67),
                new SampleDataThing(DateTime.Parse("2015-09-15"), 40.48, -89.49),
                new SampleDataThing(DateTime.Parse("2015-09-15"), 41.48, -87.33),
                new SampleDataThing(DateTime.Parse("2015-09-15"), 39.79, -75.66),
                new SampleDataThing(DateTime.Parse("2015-09-15"), 41.68, -81.33),
                new SampleDataThing(DateTime.Parse("2015-09-15"), 41.77, -81.15),
                new SampleDataThing(DateTime.Parse("2015-09-15"), 41.49, -81.67),
                new SampleDataThing(DateTime.Parse("2015-09-15"), 41.85, -96.47),
                new SampleDataThing(DateTime.Parse("2015-09-15"), 39.43, -84.5),
                new SampleDataThing(DateTime.Parse("2015-09-15"), 41.52, -87.42),
                new SampleDataThing(DateTime.Parse("2015-09-15"), 39.96, -86.02),
                new SampleDataThing(DateTime.Parse("2015-09-15"), 44, -77.72),
                new SampleDataThing(DateTime.Parse("2015-09-15"), 41.97, -82.52),
                new SampleDataThing(DateTime.Parse("2015-09-15"), 39.86, -85.99),
                new SampleDataThing(DateTime.Parse("2015-09-15"), 43.45, -79.68),
                new SampleDataThing(DateTime.Parse("2015-09-14"), 41.89, -100.35),
                new SampleDataThing(DateTime.Parse("2015-09-14"), 44, -78.02),
                new SampleDataThing(DateTime.Parse("2015-09-14"), 41.44, -81.74),
                new SampleDataThing(DateTime.Parse("2015-09-14"), 44.63, -75.95),
                new SampleDataThing(DateTime.Parse("2015-09-14"), 43.78, -79.25),
                new SampleDataThing(DateTime.Parse("2015-09-14"), 38.55, -90.38),
                new SampleDataThing(DateTime.Parse("2015-09-14"), 43.78, -79.25),
                new SampleDataThing(DateTime.Parse("2015-09-14"), 41.49, -81.67),
                new SampleDataThing(DateTime.Parse("2015-09-14"), 42.67, -81.22),
                new SampleDataThing(DateTime.Parse("2015-09-14"), 39.83, -82.8),
                new SampleDataThing(DateTime.Parse("2015-09-14"), 41.44, -81.52),
                new SampleDataThing(DateTime.Parse("2015-09-14"), 41.97, -91.66),
                new SampleDataThing(DateTime.Parse("2015-09-14"), 40.28, -82.86),
                new SampleDataThing(DateTime.Parse("2015-09-14"), 44.37, -100.04),
                new SampleDataThing(DateTime.Parse("2015-09-14"), 36.94, -89.6),
                new SampleDataThing(DateTime.Parse("2015-09-14"), 40.46, -90.68),
                new SampleDataThing(DateTime.Parse("2015-09-13"), 41.49, -81.93),
                new SampleDataThing(DateTime.Parse("2015-09-13"), 41.32, -81.6),
                new SampleDataThing(DateTime.Parse("2015-09-13"), 42.43, -86.22),
                new SampleDataThing(DateTime.Parse("2015-09-13"), 41.92, -82.51),
                new SampleDataThing(DateTime.Parse("2015-09-13"), 39.59, -88.59),
                new SampleDataThing(DateTime.Parse("2015-09-13"), 41.42, -81.6),
                new SampleDataThing(DateTime.Parse("2015-09-13"), 40.13, -88.18),
                new SampleDataThing(DateTime.Parse("2015-09-12"), 39.3, 101.3),
                new SampleDataThing(DateTime.Parse("2015-09-12"), 41.55, -93.25),
                new SampleDataThing(DateTime.Parse("2015-09-12"), 41.49, -81.67),
                new SampleDataThing(DateTime.Parse("2015-09-12"), 41.49, -81.67),
                new SampleDataThing(DateTime.Parse("2015-09-11"), 43.79, -88.52),
                new SampleDataThing(DateTime.Parse("2015-09-11"), 40.16, -80.71),
                new SampleDataThing(DateTime.Parse("2015-09-11"), 44.65, -83.36),
                new SampleDataThing(DateTime.Parse("2015-09-11"), 41.52, -90.4),
                new SampleDataThing(DateTime.Parse("2015-09-11"), 43.84, -78.96),
                new SampleDataThing(DateTime.Parse("2015-09-10"), 42.52, -86.2),
                new SampleDataThing(DateTime.Parse("2015-09-10"), 41.64, -93.74),
                new SampleDataThing(DateTime.Parse("2015-09-09"), 43.09, -91.42),
                new SampleDataThing(DateTime.Parse("2015-09-09"), 44.63, -75.95),
                new SampleDataThing(DateTime.Parse("2015-09-09"), 38.83, -123.44),
                new SampleDataThing(DateTime.Parse("2015-09-08"), 44.52, -92.55),
                new SampleDataThing(DateTime.Parse("2015-09-07"), 44.52, -92.55),
                new SampleDataThing(DateTime.Parse("2015-09-07"), 41.58, -87.18),
                new SampleDataThing(DateTime.Parse("2015-09-07"), 44.52, -92.55),
                new SampleDataThing(DateTime.Parse("2015-09-06"), 44.41, -85.15),
                new SampleDataThing(DateTime.Parse("2015-09-06"), 44.33, -96.64),
                new SampleDataThing(DateTime.Parse("2015-09-05"), 44.2, -86.19),
                new SampleDataThing(DateTime.Parse("2015-09-05"), 43.78, -86.43),
                new SampleDataThing(DateTime.Parse("2015-09-05"), 38.72, -87.68),
                new SampleDataThing(DateTime.Parse("2015-09-04"), 44, -86.44),
                new SampleDataThing(DateTime.Parse("2015-09-04"), 45.4, -93.27),
                new SampleDataThing(DateTime.Parse("2015-09-03"), 44.99, -93.27),
                new SampleDataThing(DateTime.Parse("2015-09-03"), 44.95, -93.43),
                new SampleDataThing(DateTime.Parse("2015-09-02"), 43.34, -93.91),
                new SampleDataThing(DateTime.Parse("2015-09-02"), 46.93, -96.85),
                new SampleDataThing(DateTime.Parse("2015-09-02"), 41.97, -91.66),
                new SampleDataThing(DateTime.Parse("2015-09-02"), 45.86, -84.63),
                new SampleDataThing(DateTime.Parse("2015-09-01"), 45.01, -93.46),
                new SampleDataThing(DateTime.Parse("2015-09-01"), 45.32, -92.7),
                new SampleDataThing(DateTime.Parse("2015-09-01"), 44.63, -93.24),
                new SampleDataThing(DateTime.Parse("2015-09-01"), 45.6, -94.25),
                new SampleDataThing(DateTime.Parse("2015-09-01"), 44.77, -89.71),
                new SampleDataThing(DateTime.Parse("2015-08-30"), 45.11, -92.55),
                new SampleDataThing(DateTime.Parse("2015-08-30"), 44.99, -93.27),
                new SampleDataThing(DateTime.Parse("2015-08-30"), 44.76, -93.94),
                new SampleDataThing(DateTime.Parse("2015-08-29"), 44.76, -93.51),
                new SampleDataThing(DateTime.Parse("2015-08-29"), 44.74, -94.29),
                new SampleDataThing(DateTime.Parse("2015-08-29"), 42.62, -91.91),
                new SampleDataThing(DateTime.Parse("2015-08-28"), 45.11, -92.55),
                new SampleDataThing(DateTime.Parse("2015-08-28"), 44.86, -86.04),
                new SampleDataThing(DateTime.Parse("2015-08-27"), 45.18, -92.55),
                new SampleDataThing(DateTime.Parse("2015-08-24"), 42.46, -81.7),
                new SampleDataThing(DateTime.Parse("2015-08-21"), 44.86, -88.79)
            };
        }

        static List<FirstLast> GetListOfFirstLastNames()
        {
            return new List<FirstLast>
            {
                 new FirstLast("Antoinette","Davis"),
                 new FirstLast("Melba","Rice"),
                 new FirstLast("Jordan","Taylor"),
                 new FirstLast("Duane","Pena"),
                 new FirstLast("Paulette","Lowe"),
                 new FirstLast("Cecelia","Hampton"),
                 new FirstLast("Amelia","Hicks"),
                 new FirstLast("Joe","Tate"),
                 new FirstLast("Lynette","Woods"),
                 new FirstLast("Harvey","Russell"),
                 new FirstLast("Margie","Wells"),
                 new FirstLast("Lewis","Harvey"),
                 new FirstLast("Gustavo","Warren"),
                 new FirstLast("Constance","Lambert"),
                 new FirstLast("Alexis","Robinson"),
                 new FirstLast("Inez","Hale"),
                 new FirstLast("Sheryl","Barber"),
                 new FirstLast("Rose","Moreno"),
                 new FirstLast("Erick","Lucas"),
                 new FirstLast("Bruce","Sanchez"),
                 new FirstLast("Heather","Gordon"),
                 new FirstLast("Patti","Edwards"),
                 new FirstLast("Dave","Hunter"),
                 new FirstLast("William","Cook"),
                 new FirstLast("Joshua","Cain"),
                 new FirstLast("Billy","Torres"),
                 new FirstLast("Carolyn","Soto"),
                 new FirstLast("Archie","Lawrence"),
                 new FirstLast("Elizabeth","Barnett"),
                 new FirstLast("Ana","Lee"),
                 new FirstLast("Jim","Sutton"),
                 new FirstLast("Lula","May"),
                 new FirstLast("Dianne","Clarke"),
                 new FirstLast("Monique","Berry"),
                 new FirstLast("Brandon","Powers"),
                 new FirstLast("Myron","Owen"),
                 new FirstLast("Audrey","Jordan"),
                 new FirstLast("Bryant","Vargas"),
                 new FirstLast("Terrell","Marshall"),
                 new FirstLast("Ruben","Doyle"),
                 new FirstLast("Ricky","Huff"),
                 new FirstLast("Hubert","Romero"),
                 new FirstLast("Philip","Mccoy"),
                 new FirstLast("Willie","Bryan"),
                 new FirstLast("Mindy","Perry"),
                 new FirstLast("Lydia","Murphy"),
                 new FirstLast("Bill","Hill"),
                 new FirstLast("Michael","Guerrero"),
                 new FirstLast("Bessie","Castillo"),
                 new FirstLast("Shannon","Yates"),
                 new FirstLast("Stephen","Walton"),
                 new FirstLast("Francis","Andrews"),
                 new FirstLast("Kelvin","Paul"),
                 new FirstLast("Tommie","Roy"),
                 new FirstLast("Lisa","Vega"),
                 new FirstLast("Elbert","Kelley"),
                 new FirstLast("Clark","King"),
                 new FirstLast("Tammy","Wong"),
                 new FirstLast("Geraldine","Martin"),
                 new FirstLast("Dean","Walters"),
                 new FirstLast("Renee","Keller"),
                 new FirstLast("Curtis","Frazier"),
                 new FirstLast("Shane","Jimenez"),
                 new FirstLast("Rodney","Cunningham"),
                 new FirstLast("Aubrey","Rogers"),
                 new FirstLast("Tricia","Payne"),
                 new FirstLast("Norma","Garza"),
                 new FirstLast("Marsha","Saunders"),
                 new FirstLast("Wendy","Morrison"),
                 new FirstLast("Jenny","Howard"),
                 new FirstLast("Tabitha","Clark"),
                 new FirstLast("Earnest","Greer"),
                 new FirstLast("Randall","Mason"),
                 new FirstLast("Hazel","Rodriquez"),
                 new FirstLast("Kent","Bennett"),
                 new FirstLast("Julia","Bowman"),
                 new FirstLast("Alicia","Wolfe"),
                 new FirstLast("Robert","Cortez"),
                 new FirstLast("Felipe","Banks"),
                 new FirstLast("Emily","Morales"),
                 new FirstLast("Carlton","Fleming"),
                 new FirstLast("Herbert","Caldwell"),
                 new FirstLast("Wilbur","Williams"),
                 new FirstLast("Frankie","Brock"),
                 new FirstLast("Paul","Ruiz"),
                 new FirstLast("Nina","Peters"),
                 new FirstLast("Beverly","Leonard"),
                 new FirstLast("Kathleen","Franklin"),
                 new FirstLast("Jack","Barton"),
                 new FirstLast("Victoria","Swanson"),
                 new FirstLast("Jody","Thornton"),
                 new FirstLast("Mona","Holmes"),
                 new FirstLast("Marilyn","Sanders"),
                 new FirstLast("Chester","Campbell"),
                 new FirstLast("Manuel","Daniel"),
                 new FirstLast("Bob","Alvarez"),
                 new FirstLast("Josefina","Wheeler"),
                 new FirstLast("Mark","Sparks"),
                 new FirstLast("Kyle","Clayton"),
                 new FirstLast("Brian","Johnston")
            };
        }

        static List<string> GetListOfRandomStreetNames()
        {
            return new List<string>
            {
                "College Street",
                "Laurel Lane",
                "Overlook Circle",
                "Euclid Avenue",
                "Route 64",
                "Hanover Court",
                "Pin Oak Drive",
                "Strawberry Lane",
                "Fulton Street",
                "King Street",
                "Hillside Drive",
                "Briarwood Court",
                "Chestnut Avenue",
                "West Street",
                "Riverside Drive",
                "Route 2",
                "Park Avenue",
                "Chapel Street",
                "5th Street West",
                "York Street",
                "Linda Lane",
                "George Street",
                "Brown Street",
                "Canterbury Drive",
                "4th Street",
                "9th Street West",
                "Highland Avenue",
                "8th Street West",
                "Route 41",
                "Queen Street",
                "6th Street",
                "Street Road",
                "Elm Street",
                "5th Avenue",
                "Spruce Street",
                "Forest Street",
                "Cardinal Drive",
                "Buttonwood Drive",
                "Edgewood Road",
                "Lincoln Avenue",
                "Valley Drive",
                "Summit Avenue",
                "Marshall Street",
                "Route 202",
                "4th Street South",
                "Union Street",
                "Mechanic Street",
                "Mill Street",
                "Madison Court",
                "Jefferson Street",
                "5th Street East",
                "Sunset Drive",
                "Hillcrest Drive",
                "Mulberry Lane",
                "Garfield Avenue",
                "Cherry Street",
                "Willow Street",
                "Grove Avenue",
                "Summer Street",
                "South Street",
                "Cleveland Street",
                "Schoolhouse Lane",
                "Ivy Court",
                "Oak Street",
                "3rd Street West",
                "Railroad Avenue",
                "Oak Avenue",
                "Berkshire Drive",
                "8th Street",
                "Church Street",
                "Holly Drive",
                "Heather Court",
                "Route 4",
                "Windsor Court",
                "2nd Street North",
                "8th Avenue",
                "8th Street South",
                "Lafayette Street",
                "Howard Street",
                "Belmont Avenue",
                "Jones Street",
                "7th Street",
                "Heritage Drive",
                "Ashley Court",
                "Surrey Lane",
                "Westminster Drive",
                "Manor Drive",
                "Park Place",
                "Hamilton Road",
                "Fawn Court",
                "Glenwood Drive",
                "Vine Street",
                "2nd Street West",
                "York Road",
                "Fawn Lane",
                "Hawthorne Lane",
                "Franklin Avenue",
                "Market Street",
                "Walnut Avenue",
                "11th Street",
                "Taylor Street",
                "Clark Street",
                "Grove Street",
                "1st Avenue",
                "Lakeview Drive",
                "6th Street North",
                "Jefferson Avenue",
                "Ridge Avenue",
                "Brandywine Drive",
                "Woodland Road",
                "Creekside Drive",
                "Elmwood Avenue",
                "Pearl Street",
                "Highland Drive",
                "Oxford Court",
                "Summit Street",
                "Hamilton Street",
                "Cedar Lane",
                "Walnut Street",
                "Roberts Road",
                "5th Street South",
                "Charles Street",
                "Bank Street",
                "Durham Road",
                "Roosevelt Avenue",
                "William Street",
                "Route 10",
                "Evergreen Drive",
                "5th Street",
                "Broad Street",
                "Route 1",
                "Main Street North",
                "North Street",
                "Lawrence Street",
                "John Street",
                "Sycamore Lane",
                "Madison Avenue",
                "Buckingham Drive",
                "State Street East",
                "Main Street South",
                "Henry Street",
                "Essex Court",
                "Hartford Road",
                "2nd Street East",
                "Creek Road",
                "Dogwood Drive",
                "Somerset Drive",
                "Route 32",
                "Bayberry Drive",
                "Rosewood Drive",
                "Lake Street",
                "Court Street",
                "Mill Road",
                "Maiden Lane",
                "Magnolia Drive",
                "Dogwood Lane",
                "Front Street South",
                "Magnolia Court",
                "Forest Drive",
                "Parker Street",
                "Orange Street",
                "River Street",
                "Victoria Court",
                "2nd Avenue",
                "Devon Road",
                "Monroe Drive",
                "Meadow Street",
                "Sheffield Drive",
                "Grand Avenue",
                "Orchard Street",
                "7th Avenue",
                "Laurel Drive",
                "Washington Avenue",
                "Ridge Street",
                "Route 27",
                "Broad Street West",
                "Orchard Avenue",
                "Valley Road",
                "Franklin Court",
                "Cherry Lane",
                "Bay Street",
                "4th Street North",
                "6th Street West",
                "Oxford Road",
                "13th Street",
                "Heather Lane",
                "Andover Court",
                "Circle Drive",
                "Route 9",
                "Ivy Lane",
                "West Avenue",
                "Hill Street",
                "Jackson Street",
                "Cottage Street",
                "Virginia Avenue",
                "Pine Street",
                "Canterbury Court",
                "Smith Street",
                "Primrose Lane",
                "6th Avenue"
            };
        }

        static string GetRandomOrganization()
        {
            // lazy load the static random object
            if (rand == null)
                rand = new Random();
            // return a random org
            return Organizations[rand.Next(Organizations.Length - 1)];
        }

        static string GenerateRandomStreetAddress()
        {
            return "";
        }

        static string RandomPhone()
        {
            // lazy load the static random object
            if (rand == null)
                rand = new Random();

            // first three digits is the same random number 1-9
            int areaCodeNum = rand.Next(1, 9);
            string areaCode = string.Format("{0}{1}{2}", areaCodeNum, areaCodeNum, areaCodeNum);
            string phoneNumber1 = string.Format("{0:D3}", rand.Next(1,999));
            string phoneNumber2 = string.Format("{0:D4}", rand.Next(1, 999));
            return string.Format("{0}-{1}-{2}", areaCode, phoneNumber1, phoneNumber2);
        }

        static IEnumerable<GoogleAddress> GetGeocodingResult(GoogleGeocoder geocoder, double latitude, double longitude)
        {
            Thread.Sleep(200);
            try
            {
                return geocoder.ReverseGeocode(latitude, longitude);
            }
            catch (GoogleGeocodingException e)
            {
                //Console.WriteLine(e.Message);
                return GetGeocodingResult(geocoder, latitude, longitude);
            }
        }

        static void Main(string[] args)
        {


            GoogleGeocoder geocoder = new GoogleGeocoder();
            var sampleData = new List<SampleDataThing> { GetSampleData().First(), GetSampleData().Last() };

            var firstLastNames = GetListOfFirstLastNames();
            var randomStreets = GetListOfRandomStreetNames();
            var cityStates = new HashSet<CityState>();

            var reporters = new List<Reporter>();
            var humanSightings = new List<HumanSighting>();
            
            foreach (var data in sampleData)
            {

                // call google geocoding API to reverse geocode the a latitude and longitude set
                var addresses = GetGeocodingResult(geocoder, data.Latitude, data.Longitude);
                
                // create a list components 
                var components = addresses.First().Components;

                // iterate through all components
                string city = "";
                string state = "";
                string postalCode = "";
                string country = "";
                foreach (var comp in components)
                {
                    
                    // for each GoogleAddressType of the component
                    foreach (var type in comp.Types)
                    {
                        // If there's a city assign it
                        if (type.Equals(GoogleAddressType.Locality))
                        {
                            if (string.IsNullOrEmpty(city))
                                city = comp.LongName;
                        }

                        // if there's a state, assign it
                        if (type.Equals(GoogleAddressType.AdministrativeAreaLevel1))
                        {
                            if (string.IsNullOrEmpty(state))
                                state = comp.LongName;
                        }

                        if (type.Equals(GoogleAddressType.PostalCode))
                        {
                            if (string.IsNullOrEmpty(postalCode))
                                postalCode = comp.LongName;
                        }

                        if (type.Equals(GoogleAddressType.Country))
                        {
                            if (string.IsNullOrEmpty(country))
                                country = comp.LongName;
                        }
                    } // foreach (var type in comp.Types)


                    
                } // foreach (var comp in components)

                // create a new City State struct
                var newCityState = new CityState(city, state);

                // then see if it's in the hashset
                if (!cityStates.Contains(newCityState))
                {
                    cityStates.Add(newCityState);

                    // get a random index
                    if (rand == null)
                        rand = new Random();
                    int nameIndex = rand.Next(firstLastNames.Count - 1);
                    // get the name
                    string name = firstLastNames[nameIndex].First + " " + firstLastNames[nameIndex].Last;
                    // then remove the name from the list
                    firstLastNames.RemoveAt(nameIndex);

                    int streetIndex = rand.Next(randomStreets.Count - 1);
                    string streetName = randomStreets[streetIndex];
                    randomStreets.RemoveAt(streetIndex);

                    reporters.Add
                    (
                        new Reporter
                        {
                            Name = name,
                            UserName = string.Format("{0}@email.com", name.ToLower().Replace(" ", "")),
                            CellPhone = RandomPhone(),
                            HomePhone = RandomPhone(),
                            PostalCode = postalCode,
                            Organization = GetRandomOrganization(),
                            StreetAddress = string.Format("{0} {1}", rand.Next(1, 999), streetName)
                        }
                    );

                    humanSightings.Add
                    (
                        new HumanSighting
                        {
                            UserName = string.Format("{0}@email.com", name.ToLower().Replace(" ", "")),
                            City = city,
                            StateProvince = state,
                            Country = country,
                            Latitude = data.Latitude,
                            Longitude = data.Latitude,
                            DateTime = data.DateTime,
                            Species = "Monarch"
                        }
                    );
                }
                else // if the city state already exists
                {
                    var reporter = reporters.Where(e => e.PostalCode.Equals(postalCode)).First();
                    humanSightings.Add
                    (
                        new HumanSighting
                        {
                            UserName = reporter.UserName,
                            City = city,
                            StateProvince = state,
                            Country = country,
                            Latitude = data.Latitude,
                            Longitude = data.Latitude,
                            DateTime = data.DateTime,
                            Species = "Monarch"
                        }
                    );
                }

            }

            foreach (var sighting in humanSightings)
                Console.WriteLine(sighting);

            foreach (var reporter in reporters)
                Console.WriteLine(reporter);

            Regex digitsOnly = new Regex(@"[^\d]"); // this to remove non-numerical characters for phone numbers
            int dummyInt; // dummy int for int.TryParse(...)
            double dummyDouble; // dummy double for long.TryParse(...)
            DateTime dummyDate; // dummy date for DateTime.TryParse(...)

            // create a new FixedWidthFile
            var sightingsFile = new FixedWidthParser
            (
                filePath: "sightings.txt",
                columnDefintions: new List<dynamic> // note this list is defined by the dynamic keyword
                {
                    new FixedWidthColumn<string>
                    (
                        key: "Event",
                        length: 2,
                        conversionFromStringToDataType: dataString => dataString,
                        conversionFromDataToString: data => data,
                        conformanceTest: stringToTest => true
                    ),
                    new FixedWidthColumn<string>
                    (
                        key: "UserName",
                        length: 30,
                        conversionFromStringToDataType: dataString => dataString,
                        conversionFromDataToString: data => data,
                        conformanceTest: stringToTest => true
                    ),
                    new FixedWidthColumn<DateTime>
                    (
                        key: "DateTime",
                        length: 19,
                        conversionFromStringToDataType: dataString => DateTime.Parse(dataString),
                        conversionFromDataToString: data => data.ToString(@"yyyy-MM-dd H:mm:ss "),
                        conformanceTest: stringToTest => DateTime.TryParse(stringToTest, out dummyDate)
                        //nullable: false
                    ),
                    new FixedWidthColumn<double>
                    (
                        key: "Latitude",
                        length: 11,
                        conversionFromStringToDataType: dataString => double.Parse(dataString),
                        conversionFromDataToString: data => string.Format("{0:+000.000000;-000.000000}", data),
                        conformanceTest: stringToTest => double.TryParse(digitsOnly.Replace(stringToTest, ""), out dummyDouble)
                        //nullable: false
                    ),
                    new FixedWidthColumn<double>
                    (
                        key: "Longitude",
                        length: 11,
                        conversionFromStringToDataType: dataString => double.Parse(dataString),
                        conversionFromDataToString: data => string.Format("{0:+000.000000;-000.000000}", data),
                        conformanceTest: stringToTest => double.TryParse(digitsOnly.Replace(stringToTest, ""), out dummyDouble)
                        //nullable: false
                    ),
                    new FixedWidthColumn<string>
                    (
                        key: "City",
                        length: 30,
                        conversionFromStringToDataType: dataString => dataString,
                        conversionFromDataToString: data => " " + data,
                        conformanceTest: stringToTest => true
                    ),
                    new FixedWidthColumn<string>
                    (
                        key: "State",
                        length: 30,
                        conversionFromStringToDataType: dataString => dataString,
                        conversionFromDataToString: data => data,
                        conformanceTest: stringToTest => true
                    ),
                    new FixedWidthColumn<string>
                    (
                        key: "Country",
                        length: 30,
                        conversionFromStringToDataType: dataString => dataString,
                        conversionFromDataToString: data => data,
                        conformanceTest: stringToTest => true
                    ),
                    new FixedWidthColumn<string>
                    (
                        key: "Species",
                        length: 20,
                        conversionFromStringToDataType: dataString => dataString,
                        conversionFromDataToString: data => data,
                        conformanceTest: stringToTest => true
                    ),
                    new FixedWidthColumn<int>
                    (
                        key: "Tag",
                        length: 11,
                        conversionFromStringToDataType: dataString => int.Parse(dataString),
                        conversionFromDataToString: data => data.ToString(),
                        conformanceTest: stringToTest => int.TryParse(stringToTest, out dummyInt)
                    ),
                }
            );


            foreach (var sighting in humanSightings)
            {
                sightingsFile.Add
                (
                    keys:
                        new string[] { "Event", "UserName", "Latitude", "Longitude",
                        "Species", "State", "City", "Country", "DateTime" },
                    values:
                        new object[] { "S", sighting.UserName, sighting.Latitude,
                        sighting.Longitude, sighting.Species, sighting.StateProvince,
                        sighting.City, sighting.Country, sighting.DateTime }
                );
            }
            sightingsFile.HeaderLead = "HD";
            sightingsFile.Write();

        }
    }
}

