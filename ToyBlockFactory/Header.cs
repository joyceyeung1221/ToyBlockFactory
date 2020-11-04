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

        public string PrintString()
        {
            return $"Your {_reportName.ToLower()} has been generated:";
        }
    }
}
