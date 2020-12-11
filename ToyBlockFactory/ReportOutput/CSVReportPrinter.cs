using System;
using System.IO;

namespace ToyBlockFactory
{
    public class CSVReportPrinter : IReportPrinter
    {
        private readonly string fileName = "/Users/Joyce.Yeung/Projects/ToyBlockFactory/ToyBlockFactory/Sample/output.csv";

        public void Print(string report)
        {
            if (File.Exists(fileName))
            {
                var splitReport = report.Split('\n');
                File.AppendAllText(fileName, splitReport[1]);
                return;
            }
            File.WriteAllText(fileName, report);

        }
    }
}
