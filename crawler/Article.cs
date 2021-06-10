namespace VuTruLink
{
    public class Article
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }

        public override string ToString()
        {
            return ($"url: {Url}, title: {Title}, Content: {Content}, image: {Image}");
        }
            }
}