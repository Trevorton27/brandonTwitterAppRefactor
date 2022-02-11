using System;
using System.Collections.Generic;
using System.Linq;
using Twitter_Showcase_WebAPI.Models;

namespace Twitter_Showcase_WebAPI.Services
{
    public class FormatTweetService : IFormatTweetService
    {

        public List<TweetObject> GetTweets(UserTimeline timeline)
        {
            List<TweetObject> tweets = timeline.Data.Select(x =>
            {
                UserData currentUser = this.GetCurrentUser(timeline, x);

                List<string> images = new List<string>();
                List<string> videos = new List<string>();

                this.SetVideoAndImageUrls(timeline, x, images, videos);

                TweetObject tweet = new TweetObject(x.Text, FormatDate(x.Created_at), x.Public_metrics.Like_count, x.Public_metrics.Reply_count, x.Public_metrics.Retweet_count, currentUser.Profile_image_url, currentUser.Name, currentUser.Username, images, videos);
                return tweet;
            }).ToList();

            return tweets;
        }

        public UserData GetCurrentUser(UserTimeline timeline, TweetData currentTweet)
        {
            UserData currentUser = timeline.Includes.Users.First(user => user.Id == currentTweet.Author_id);
            return currentUser;
        }


        public void SetVideoAndImageUrls(UserTimeline timeline, TweetData data, List<string> images, List<string> videos)
        {
            if (data.Attachments != null)
            {
                if (data.Attachments.Poll_ids != null)
                {
                    data.Attachments.Poll_ids = null;
                }

                if (data.Attachments.Media_keys != null)
                {
                    foreach (string key in data.Attachments.Media_keys)
                    {
                        foreach (MediaData m in timeline.Includes.Media)
                        {
                            if (m.Media_key == key)
                            {
                                if (m.Type == "photo")
                                {
                                    images.Add(m.Url);
                                }

                                if (m.Type == "video")
                                {
                                    videos.Add(m.Preview_image_url);
                                }
                            }
                        }
                    }
                } 
            }
            else
            {
                images = null;
                videos = null;
            }
        }

        public List<TweetObject> GetRandomTweets(UserTimeline timeline)
        {
            List<TweetObject> randomTweets = new List<TweetObject>();

            List<TweetObject> tweets = this.GetTweets(timeline);

            while (randomTweets.Count != 15)
            {
                Random rand = new Random();
                int randomInt = rand.Next(0, tweets.Count);

                if (!randomTweets.Contains(tweets[randomInt]))
                {
                    randomTweets.Add(tweets[randomInt]);
                }
            }

            return randomTweets;

        }

        public string FormatDate(DateTime createdAt)
        {
            return createdAt.ToString("g");
        }
    }
}
