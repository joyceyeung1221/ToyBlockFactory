using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;

namespace ToyBlockFactory
{
    public class CSVInputReader
    {
        private string _filePath;

        public CSVInputReader(string filePath)
        {
            _filePath = filePath;
        }

        public List<string[]> GetInput()
        {
            var csvInput = new List<string[]>();
            try
            {
                using (TextFieldParser parser = new TextFieldParser(_filePath))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        csvInput.Add(fields);
                    }
                }
            }
            catch(Exception e)
            {
                throw e;
            }

            return csvInput;
        }
    }
}
