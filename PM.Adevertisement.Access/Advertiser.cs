using PM.Adevertisement.Access.Helpers;

namespace PM.Adevertisement.Access
{
    public class Advertiser : IDesrializeFromText<Advertiser>
    {
        public string Name { get; set; }

        public Advertiser DeserializeFromText(string line, char delimeter)
        {
            var fields = line.Split(delimeter);
            var advertiser = new Advertiser()
            {
                Name = fields[0].Trim()
            };

            return advertiser;
        }
    }
}