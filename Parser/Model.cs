using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    class Model
    {
        private string id;
        private string name;
        private List<Generation> generations;

        public string ID { get { return id; } set { } }
        public string Name { get { return name; } set { } }
        public List<Generation> Generations { get { return generations; } set { } }

        public Model(string _id, string _name)
        {
            id = _id;
            name = _name;
            generations = new List<Generation>();
        }

        public Model(string _id, string _name, List<Generation> _generations)
        {
            id = _id;
            name = _name;
            generations = _generations;
        }
    }
}
