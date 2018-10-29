using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary;
using NUnit.Framework;
using System.Globalization;

namespace BookLibrary.Tests
{
    [TestFixture]
    public class BookLibraryTests
    {
        [TestCase("F", "en-US", "C# in Depth", "Jon Skeet", "2019", "Manning", "4", "900", "40$", ExpectedResult = "Book record: C# in Depth, Jon Skeet, 2019, Manning, 4, 900, 40$")]
        [TestCase(null, "en-US", "C# in Depth", "Jon Skeet", "2019", "Manning", "4", "900", "40$", ExpectedResult = "Book record: C# in Depth, Jon Skeet, 2019, Manning, 4, 900, 40$")]
        [TestCase("BA", "ru-RU", "C# in Depth", "Jon Skeet", "2019", "Manning", "4", "900", "40$", ExpectedResult = "Book record: C# in Depth, Jon Skeet")]
        [TestCase("BAY", "en-US", "C# in Depth", "Jon Skeet", "2019", "Manning", "4", "900", "40$", ExpectedResult = "Book record: C# in Depth, Jon Skeet, 2019")]
        [TestCase("BAYPEP", "en-US", "C# in Depth", "Jon Skeet", "2019", "Manning", "4", "900", "40$", ExpectedResult = "Book record: C# in Depth, Jon Skeet, 2019, Manning, 4, 900")]
        [TestCase("AP", "en-US", "C# in Depth", "Jon Skeet", "2019", "Manning", "4", "900", "40$", ExpectedResult = "Book record: Jon Skeet, Manning")]
        public string Check_With_Specificators_ToString(string format, string culture, string Title, string Author, string Year,
           string PublishingHous, string Edition,
           string Pages, string Price)
        {

            Book person = new Book(Title, Author, Year, PublishingHous, Edition, Pages, Price);
            return person.ToString(format, CultureInfo.CreateSpecificCulture(culture));
        }

        [TestCase("F", "C# in Depth", "Jon Skeet", "2019", "Manning", "4", "900", "40$", ExpectedResult = "Book record: C# in Depth, Jon Skeet, 2019, Manning, 4, 900, 40$")]
        [TestCase(null, "C# in Depth", "Jon Skeet", "2019", "Manning", "4", "900", "40$", ExpectedResult = "Book record: C# in Depth, Jon Skeet, 2019, Manning, 4, 900, 40$")]
        [TestCase("BA", "C# in Depth", "Jon Skeet", "2019", "Manning", "4", "900", "40$", ExpectedResult = "Book record: C# in Depth, Jon Skeet")]
        [TestCase("BAY", "C# in Depth", "Jon Skeet", "2019", "Manning", "4", "900", "40$", ExpectedResult = "Book record: C# in Depth, Jon Skeet, 2019")]
        [TestCase("BAYPEP", "C# in Depth", "Jon Skeet", "2019", "Manning", "4", "900", "40$", ExpectedResult = "Book record: C# in Depth, Jon Skeet, 2019, Manning, 4, 900")]
        [TestCase("AP", "C# in Depth", "Jon Skeet", "2019", "Manning", "4", "900", "40$", ExpectedResult = "Book record: Jon Skeet, Manning")]
        public string Check_With_Specificators_FormatOnly(string format, string Title, string Author, string Year,
           string PublishingHous, string Edition,
           string Pages, string Price)
        {
            Book person = new Book(Title, Author, Year, PublishingHous, Edition, Pages, Price);
            return person.ToString(format);
        }
    }
}
