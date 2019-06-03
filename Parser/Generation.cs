using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    class Generation
    {
        private string id;
        private string name;

        public string ID { get { return id; } set { } }
        public string Name { get { return name; } set { } }

        public Generation(string _id, string _name)
        {
            id = _id;
            name = _name;
        }
    }
}
