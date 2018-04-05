using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.DataModel.Tools
{
    public static class RandomDataHelper
    {
        public static Random GetRandomizer()
        {
            System.Threading.Thread.Sleep(1);
            return new Random(DateTime.Now.Millisecond);
        }

        public static string GenerateShortName(bool female = false)
        {
            return string.Format("{0} {1}", GenerateFirstName(female), GenerateLastName());
        }

        public static string GenerateLongName(bool female = false)
        {
            return string.Format("{0} {1} {2} {3}", GenerateFirstName(female), GenerateFirstName(), GenerateLastName(), GenerateLastName());
        }

        public static string GenerateFirstName(bool female = false)
        {
            string[] fNames = { "Mary", "Patricia", "Judith", "Elizabeth", "Joana", "Paula", "Daniela"};
            string[] mNames = { "Francisco", "João", "Roberto", "Michael", "Mario", "William", "David", "Richard", "Charles", "Joseph",
                "Thomas", "Paulo", "Jose", "Frank", "Daniel", "Patricio", "Mark", "Felipe","Delmiro","Antonio","Manuel","Domingos"};

            return GetRandomValueFromStringArray(female ? fNames : mNames);
        }

        public static string GenerateLastName()
        {
            string[] lNames = { "De Carvalho", "Nunes", "Neto", "Antonio de Paula", "Frederico", "André", "Miller", "Wilson", "Moore", "Da Fonseca",
                "Camilo", "Thomas", "Neto", "Da Costa", "Rosales", "Martin", "Thompson", "Garcia", "Martinez", "Robinson"};

            return GetRandomValueFromStringArray(lNames);
        }

        public static string GenerateStreetNumber()
        {
            Random r = GetRandomizer();

            StringBuilder sB = new StringBuilder();

            for (int i = 0; i <= r.Next(2, 5); i++)
            {
                if (i == 0)
                {
                    // don't use a 0
                    sB.Append(r.Next(1, 9).ToString());
                }
                else
                {
                    sB.Append(r.Next(0, 9));
                }
            }

            return sB.ToString();
        }

        public static string GeneratePhoneNumber()
        {
            Random r = GetRandomizer();
            int areaCode = r.Next(100, 999);

            if (areaCode.ToString().EndsWith("11"))
            {
                areaCode = areaCode + 1;
            }

            return areaCode.ToString() + "-" + r.Next(100, 999).ToString() + "-" + r.Next(1000, 9999).ToString();
        }

        public static string GenerateStreetName()
        {
            string[] popularStreetNames = { "Second", "Third", "First", "Fourth", "Park", "Fifth", "Main", "Sixth", "Oak", "Seventh",
"Pine", "Maple", "Cedar", "Eighth", "Elm", "View", "Washington", "Ninth", "Wall" };
            string[] streetSuffixes = { "Dr", "St", "Pkwy", "Blvd" };

            return GetRandomValueFromStringArray(popularStreetNames) + " " + GetRandomValueFromStringArray(streetSuffixes);
        }

        public static string GenerateAptOrSuite()
        {
            Random r = GetRandomizer();

            string[] prefixes = { "Apt", "Ste", "Bldg" };
            string[] suffixes = { "A", "B", "C", "D" };
            int numericalVal = r.Next(1, 300);

            return GetRandomValueFromStringArray(prefixes) + " " + numericalVal.ToString() + GetRandomValueFromStringArray(suffixes);
        }

        public static string GenerateCity()
        {
            string[] cities = { "New York", "Los Angeles", "Chicago", "Houston", "Philadelphia", "Phoenix", "San Diego", "San Antonio", "Dallas", "Detroit",
"San Jose", "Indianapolis", "Jacksonville", "San Francisco", "Columbus", "Austin", "Memphis", "Baltimore", "Milwaukee", "Fort Worth",
"Charlotte", "El Paso", "Boston", "Seattle", "Washington", "Denver", "Portland", "Oklahoma", "Las Vegas", "Tucson",
"Long Beach", "Albuquerque", "New Orleans", "Cleveland", "Fresno", "Sacramento", "Mesa", "Atlanta" };

            return GetRandomValueFromStringArray(cities);
        }

        public static string GenerateState(bool abbreviationOnly)
        {
            string[] states = { "Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado", "Connecticut", "Delaware", "District of Columbia", "Florida",
"Georgia", "Hawaii", "Idaho", "Illinois", "Indiana", "Iowa", "Kansas", "Kentucky", "Louisiana", "Maine",
"Maryland", "Massachusetts", "Michigan", "Minnesota", "Mississippi", "Missouri", "Montana", "Nebraska", "Nevada", "New Hampshire",
"New Jersey", "New Mexico", "New York", "North Carolina", "North Dakota", "Ohio", "Oklahoma", "Oregon", "Pennsylvania", "Rhode Island",
"South Carolina", "South Dakota", "Tennessee", "Texas", "Utah", "Vermont", "Virginia", "Washington", "West Virginia", "Wisconsin",
"Wyoming" };
            string[] stateAbbr = { "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "DC", "FL",
"GA", "HI", "ID", "IL", "IN", "IA", "KS", "KT", "LA", "MN",
"MD", "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH",
"NJ", "NM", "NY", "NC", "ND", "OH", "OK", "OR", "PA", "RI",
"SC", "SD", "TN", "TX", "UT", "VT", "VA", "WA" };

            if (abbreviationOnly)
            {
                return GetRandomValueFromStringArray(stateAbbr);
            }
            else
            {
                return GetRandomValueFromStringArray(states);
            }
        }

        public static string GenerateZipCode()
        {
            Random r = GetRandomizer();

            return r.Next(10000, 99999).ToString();
        }

        public static string GetRandomValueFromStringArray(string[] sArray)
        {
            Random r = GetRandomizer();

            return sArray[r.Next(sArray.Length)];
        }

        public static T GetRandomValueFromArray<T>(T[] sArray)
        {
            Random r = GetRandomizer();

            return sArray[r.Next(sArray.Length)];
        }

        public static DateTime GenerateRandomDate(DateTime from, DateTime to)
        {
            Random r = GetRandomizer();
            var range = to - from;
            var randTimeSpan = new TimeSpan((long)(r.NextDouble() * range.Ticks));
            return from + randTimeSpan;
        }

        public static string GenerateRandomString(int size, bool firstUpercase = false)
        {
            StringBuilder builder = new StringBuilder();
            Random random = GetRandomizer();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            if (firstUpercase)
                builder[0] = char.ToUpper(builder[0]);

            return builder.ToString();
        }

        public static string GenerateRandomText(int numWord, bool firstUpercase = false)
        {
            Random r = GetRandomizer();
            string text = GenerateRandomString(r.Next(1, 12), firstUpercase);
            for (int i = 1; i < numWord; i++)
            {
                text += " " + GenerateRandomString(r.Next(1, 12), r.Next() % 9 == 0);
            }

            return text;
        }

        public static byte[] MyRandomMediaImagen()
        {
            string dirUrl = @"D:\My Projects\ZZImages\Media";
            //string dirUrl = @"K:\ZZImages\media";
            string[] files = Directory.GetFiles(dirUrl);
            byte[] img = File.ReadAllBytes(GetRandomValueFromStringArray(files));
            return img;
        }

        public static byte[] MyRandomPeopleImagen(bool female = false)
        {
            string dirUrl = female ? @"D:\My Projects\ZZImages\People\Female" : @"D:\My Projects\ZZImages\People\Male";
            //string dirUrl = female ? @"K:\ZZImages\People\Female" : @"K:\ZZImages\People\Male";
            string[] files = Directory.GetFiles(dirUrl);
            byte[] img = File.ReadAllBytes(GetRandomValueFromStringArray(files));
            return img;
        }

        public static string MyRandomPeopleImagenURI(bool female = false)
        {
            string dirUrl = female ? @"D:\My Projects\ZZImages\People\Female" : @"D:\My Projects\ZZImages\People\Male";
            //string dirUrl = female ? @"K:\ZZImages\People\Female" : @"K:\ZZImages\People\Male";
            string[] files = Directory.GetFiles(dirUrl);
            return GetRandomValueFromStringArray(files);
        }
    }
}
