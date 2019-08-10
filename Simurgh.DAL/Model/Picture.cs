namespace Simurgh.DAL.Model
{
    public class Picture : BaseModel
    {
        public PictureType Type { get; set; }
        public string Url { get; set; }
    }
}
