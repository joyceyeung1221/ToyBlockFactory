using System;
namespace ToyBlockFactory
{
    public class Header
    {
        private string _reportName;
        public Header()
        {
        }

        public string GenerateString(string reportName)
        {
            return $"Your {reportName.ToLower()} has been generated:";
        }
    }
}
