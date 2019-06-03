using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcer.Library
{
    public class Brand
    {
        private string id;
        private string name;
        private List<Model> models;

        public string ID { get { return id; } set { } }
        public string Name { get { return name; } set { } }
        public List<Model> Models { get { return models; } set { } }

        public Brand(string _id, string _name)
        {
            id = _id;
            name = _name;
            models = new List<Model>();
        }

        public Brand(string _id, string _name, List<Model> _models)
        {
            id = _id;
            name = _name;
            models = _models;
        }
    }
}
