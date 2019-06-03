
namespace Parcer.Library
{
    public class BodyType
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public BodyType()
        {
            ID = "";
            Name = "";
        }

        public BodyType(string id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
