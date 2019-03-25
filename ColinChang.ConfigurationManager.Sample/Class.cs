using System.Collections.Generic;

namespace ColinChang.ConfigurationManager.Sample
{
    public class Class
    {
        public string ClassName { get; set; }

        public Person Master { get; set; }

        public IEnumerable<Person> Students { get; set; }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}