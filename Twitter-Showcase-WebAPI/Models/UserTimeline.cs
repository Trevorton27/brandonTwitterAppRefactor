using System;

namespace Twitter_Showcase_WebAPI.Models
{
    public class UserTimeline
    {
        public TweetData[] Data { get; set; }
        public Includes Includes { get; set; }
        public Metadata Meta { get; set; }
    }

    // data
    public class TweetData
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public DateTime Created_at { get; set; }
        public string Author_id { get; set; }
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public Attachments? Attachments { get; set; }
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public TweetPublicMetrics Public_metrics { get; set; }
    }

    public class TweetPublicMetrics
    {
        public int Retweet_count { get; set; }
        public int Reply_count { get; set; }
        public int Like_count { get; set; }
        public int Quote_count { get; set; }
    }


    public class Attachments
    {
        public string[] Media_keys { get; set; }

        public string[] Poll_ids { get; set; }
    }


    // includes
    public class Includes
    {
        public UserData[] Users { get; set; }
        public MediaData[] Media { get; set; }
    }

    public class MediaData
    {
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public string? Preview_image_url { get; set; }
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public string? Url { get; set; }
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public string Media_key { get; set; }
        public string Type { get; set; }
    }

    public class UserData
    {
        public string Username { get; set; }
        public string Profile_image_url { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }

    // metadata
    public class Metadata
    {
        public string Oldest_id { get; set; }
        public string Newest_id { get; set; }
        public int Result_count { get; set; }
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public string? Next_token { get; set; }
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public string? Previous_token { get; set; }
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    }
}