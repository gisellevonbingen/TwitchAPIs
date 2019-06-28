using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test
{
    public class TestStep
    {
        public string Name { get; }
        public List<TestStep> Children { get; }
        public List<TestAbstract> Tests { get; }

        public TestStep(string name)
        {
            this.Name = name;
            this.Children = new List<TestStep>();
            this.Tests = new List<TestAbstract>();
        }

        public override string ToString()
        {
            return this.Name;
        }

    }

}
