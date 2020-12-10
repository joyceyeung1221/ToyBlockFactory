using System;
using System.Collections.Generic;
using ToyBlockFactory;

namespace ToyBlockFactoryTests
{
    public class MockInputReader : IInputReader
    {
        private string[] _header;
        private List<string[]> _csvBody;

        public MockInputReader(string[] header, List<string[]> csvBody)
        {
            _header = header;
            _csvBody = csvBody;
        }

        public List<string[]> GetInput()
        {
            var input = new List<string[]>
            {
                _header

            };
            input.AddRange(_csvBody);
            return input;
        }
    }
}
