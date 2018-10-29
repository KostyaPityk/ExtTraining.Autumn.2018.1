using System;
using System.Globalization;

namespace BookLibrary
{
    public class Book : IFormattable
    {
        #region Public fields
        public string Title { get; set; }
        public string Author { get; set; }
        public string Year { get; set; }
        public string PublishingHous { get; set; }
        public string Edition { get; set; }
        public string Pages { get; set; }
        public string Price { get; set; }
        #endregion

        /// <summary>
        /// Public constructor for initializing basic data of cutomer
        /// </summary>
        /// <param name="Title"></param>
        /// <param name="Author"></param>
        /// <param name="Year"></param>
        /// <param name="PublishingHous"></param>
        /// <param name="Edition"></param>
        /// <param name="Pages"></param>
        /// <param name="Price"></param>
        public Book(string Title, string Author, string Year, string PublishingHous, string Edition,
            string Pages, string Price)
        {
            this.Title = Title;
            this.Author = Author;
            this.Year = Year;
            this.PublishingHous = PublishingHous;
            this.Edition = Edition;
            this.Pages = Pages;
            this.Price = Price;
        }

        public string ToString(string format, IFormatProvider provider)
        {
            if (provider == null)
            {
                provider = CultureInfo.CurrentCulture;
            }
            if (String.IsNullOrEmpty(format))
            {
                format = "F";
            }
            
            switch(format.ToUpper())
            {
                case "F":
                    return string.Format(provider, "Book record: {0}, {1}, {2}, {3}, {4}, {5}, {6}", Title, Author, Year, PublishingHous,
                        Edition, Pages, Price);
                case "B":
                    return string.Format(provider, "Book record: {0}", Title);
                case "BA":
                    return string.Format(provider, "Book record: {0}, {1}", Title, Author);
                case "BY":
                    return string.Format(provider, "Book record: {0}, {1}", Title, Year);
                case "BP":
                    return string.Format(provider, "Book record: {0}, {1}", Title, PublishingHous);
                case "BE":
                    return string.Format(provider, "Book record: {0}, {1}", Title, Edition);
                case "BAY":
                    return string.Format(provider, "Book record: {0}, {1}, {2}", Title, Author, Year);
                case "BAYP":
                    return string.Format(provider, "Book record: {0}, {1}, {2}, {3}", Title, Author, Year, PublishingHous);
                case "BAYPE":
                    return string.Format(provider, "Book record: {0}, {1}, {2}, {3}, {4}}", Title, Author, Year, PublishingHous,
                        Edition);
                case "BAYPEP":
                    return string.Format(provider, "Book record: {0}, {1}, {2}, {3}, {4}, {5}", Title, Author, Year, PublishingHous,
                        Edition, Pages);
                case "A":
                    return string.Format(provider, "Book record: {0}", Author);
                case "AP":
                    return string.Format(provider, "Book record: {0}, {1}", Author, PublishingHous);
                case "AE":
                    return string.Format(provider, "Book record: {0}, {1}", Author, Edition);
                case "AY":
                    return string.Format(provider, "Book record: {0}, {1}", Author, Year);
                case "AYP":
                    return string.Format(provider, "Book record: {0}, {1}, {2}", Author, Year, PublishingHous);
                case "AYPE":
                    return string.Format(provider, "Book record: {0}, {1}, {2}, {3}}", Author, Year, PublishingHous,
                        Edition);
                case "AYPEP":
                    return string.Format(provider, "Book record: {0}, {1}, {2}, {3}, {4}",  Author, Year, PublishingHous,
                        Edition, Pages);
                case "Y":
                    return string.Format(provider, "Book record: {0}", Year);
                default:
                    throw new FormatException(String.Format("The {0} format string isn't declared yet!", format));
            }
        }

        /// <summary>
        /// Returns string representation of given object
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString()
        {
            return ToString("F", CultureInfo.CurrentCulture);
        }

        public string ToString(string format)
        {
            return ToString(format, CultureInfo.CurrentCulture);
        }
    }
}
