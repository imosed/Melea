namespace Melea.Models
{
    public class Volume
    {
        public int Id { get; set; }
        public int Drops { get; set; }
        public int OilId { get; set; }
        public EssentialOil Oil { get; set; }
        public int BlendId { get; set; }
        public Blend Blend { get; set; }
    }
}