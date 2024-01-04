namespace XsdToCsharp
{
    public class NsPair
    {
        public NsPair() { }
        public NsPair(string Xsd, string CSharp) 
        {
            this.Xsd = Xsd;
            this.CSharp = CSharp;
        }

        public string Xsd { get; set; }
        public string CSharp { get; set; }
    }
}
