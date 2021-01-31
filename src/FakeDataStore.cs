using System.Collections.Generic;

namespace WebApiWithCqrsMediatRExample
{
    public class FakeDataStore
    {
        private static List<string> _values;

        public FakeDataStore()
        {
            _values = new List<string>
            {
                "a",
                "b",
                "c"
            };
        }

        public void AddValue(string value)
        {
            _values.Add(value);
        }

        public IEnumerable<string> GetAllValues()
        {
            return _values;
        }
    }
}