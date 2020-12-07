using System;
using System.IO;
using Xunit;
using ToyBlockFactory;

namespace ToyBlockFactoryTests
{
    public class CSVInputReaderTest
    {
        public CSVInputReaderTest()
        {
        }

        [Fact]
        public void ShouldThrowExceptionWhenFileDoesntExist()
        {
            string filePath = "/Users/Joyce.Yeung/Projects/ToyBlockFactory/ToyBlockFactory/NotExist/nofile.csv";
            var processor = new CSVInputReader(filePath);
            Action act = () => processor.GetInput();

            Assert.Throws<FileNotFoundException>(act);
        }

        [Fact]
        public void ShouldReturnAListContainTheSameNumberOfElementAsTheNumberOfRows()
        {
            string filePath = "/Users/Joyce.Yeung/Projects/ToyBlockFactory/ToyBlockFactory/SampleInput/sample_input.csv";
            var processor = new CSVInputReader(filePath);
            var result = processor.GetInput();

            Assert.Equal(3, result.Count);
        }

    }
}
