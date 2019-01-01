using System;
using System.Collections.Generic;

namespace xspec
{
    public class DescribeScope
    {
        public string Description { get; set; }
        public IList<Action> BeforeAlls { get; } = new List<Action>();
        public IList<Action> AfterAlls { get; } = new List<Action>();
        public IList<Action> BeforeEaches { get; } = new List<Action>();
        public IList<Action> AfterEaches { get; } = new List<Action>();

    }
}