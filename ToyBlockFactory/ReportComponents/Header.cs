using System;
namespace ToyBlockFactory
{
    public class Header
    {
        public Header()
        {
        }

        public string GenerateString(string reportName)
        {
            return $"Your {reportName.ToLower()} has been generated:";
        }
    }
}
