﻿using System;
using ToyBlockFactory;
using Xunit;

namespace ToyBlockFactoryTests
{
    public class ConsoleReportFormatterTest
    {
        private ConsoleReportFormatter formatter;

        [Fact]
        public void ShouldConvertNonTableDataInPaintingReportIntoASpecificString()
        {
            var formatter = new ConsoleReportFormatter(new EmptyTableFormatter());
            var report = new PaintingReport(TestData.TestOrder);
            var result = formatter.ConvertToString(report);

            var expected = "Your painting report has been generated:" + "\n" +
                            "Name: Mark Pearl Address: 1 Bob Avenue, Auckland Due Date: 19 Jan 2019 Order #: 0001" + "\n" +
                            "";

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ShouldConvertNonTableDataInInvoiceReportIntoASpecificString()
        {
            var formatter = new ConsoleReportFormatter(new EmptyTableFormatter());
            var report = new InvoiceReport(TestData.TestOrder);
            var result = formatter.ConvertToString(report);

            var expected = "Your invoice report has been generated:" + "\n" +
                            "Name: Mark Pearl Address: 1 Bob Avenue, Auckland Due Date: 19 Jan 2019 Order #: 0001" + "\n" +
                            "" +
                            "Circles,5 @ $3 ppi = $15\n" +
                            "Squares,1 @ $1 ppi = $1\n" +
                            "Triangles,1 @ $2 ppi = $2\n" +
                            "Red color surcharges,2 @ $1 ppi = $2\n";

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ShouldConvertNonTableDataInCuttingReportIntoASpecificString()
        {
            var formatter = new ConsoleReportFormatter(new EmptyTableFormatter());
            var report = new CuttingListReport(TestData.TestOrder);
            var result = formatter.ConvertToString(report);

            var expected = "Your cutting list has been generated:\n" +
                                "Name: Mark Pearl Address: 1 Bob Avenue, Auckland Due Date: 19 Jan 2019 Order #: 0001\n" +
                                "";

            Assert.Equal(expected, result);
        }




    }

    public class TestTableFormatter : ITableFormatter
    {
        public string ConvertTable(ReportTable table)
        {
            var stringToOutput = " ," + String.Join(",", table.Header) + "\n";
            foreach (var row in table.Body)
            {
                stringToOutput += row.Key + ",";
                foreach (var number in row.Value)
                {
                    stringToOutput += (number == 0 ? "-" : number.ToString()) + ",";
                }
                stringToOutput = stringToOutput.Remove(stringToOutput.Length - 1, 1) + "\n";
            }

            return stringToOutput;
        }
    }

    public class EmptyTableFormatter : ITableFormatter
    {
        public string ConvertTable(ReportTable table)
        {
            return "";
        }
    }
}
