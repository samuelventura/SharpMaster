namespace SharpMaster.Tools
{
    public class Named
    {
        private readonly string name;
        private readonly object payload;

        public Named(string name, object payload = null)
        {
            this.name = name;
            this.payload = payload;
        }

        public string Name
        {
            get { return name; }
        }

        public object Payload
        {
            get { return payload; }
        }
    }
}