namespace Twitter_Showcase_WebAPI.Models
{
    public class UserDetails
    {
        public Data Data { get; set; }
    }

    public class Data
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
    }
}
