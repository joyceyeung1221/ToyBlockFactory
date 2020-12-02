using System;
using System.Collections.Generic;

namespace ToyBlockFactory.Reports.ReportComponents
{
    public class ReportTable
    {
        public Dictionary<string, List<int>> Body = new Dictionary<string, List<int>>();
        public List<string> Header { get; private set; }

        public ReportTable(List<string> header)
        {
            Header = header;
        }


        public void AddRow(string header, List<int> quantities)
        {
            Body.Add( header, quantities);
        }
    }
}
