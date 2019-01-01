using System;
using System.Collections.Generic;

namespace xspec
{
    public class Test
    {
        public Action Action { get; set; }
        public List<DescribeScope> DescribeScopes { get; set; }
        public string[] Descriptions { get; set; }
        public Action[] BeforeEaches { get; set; }
        public Action[] AfterEaches { get; set; }
        public Action[] BeforeAlls { get; set; }
        public Action[] AfterAlls { get; set; }
        public string Description { get; set; }
    }
}