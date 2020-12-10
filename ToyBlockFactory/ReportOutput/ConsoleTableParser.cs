using System;
using System.Collections.Generic;
using ConsoleTables;
namespace ToyBlockFactory
{
    public class ConsoleTableParser : ITableParser
    {
        public string FormatTable(ReportTable reportTable)
        {
            var header = new List<string>(reportTable.Header); 
            header.Insert(0, " ");
            var table = new ConsoleTable(header.ToArray());

            foreach(var row in reportTable.Body)
            {
                object[] tableRow = new object[row.Value.Count + 1];
                tableRow[0] = row.Key;
                for(var i = 0; i < row.Value.Count; i++)
                {
                    tableRow[i + 1] = row.Value[i];
                };
                table.AddRow(tableRow);
            }

            return table.ToString() + "\n";
        }
    }
}
