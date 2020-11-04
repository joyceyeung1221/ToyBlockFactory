using System;
namespace ToyBlockFactory
{
    public class Header
    {
        private string _reportName;
        public Header(string reportName)
        {
            _reportName = reportName;
        }

        public string GetPrintableString()
        {
            return $"Your {_reportName} has been generated:";
        }
    }
}
