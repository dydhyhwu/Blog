using System.Collections.Generic;

namespace Blog.Core.Domain
{
    public class StsClientCredentialConfig
    {
        public string SecretId { get; set; }
        public string SecretKey { get; set; }
        public int DurationSeconds { get; set; }
        public string Bucket { get; set; }
        public string Region { get; set; }
        public string[] AllowPrefixes { get; set; }
        public string[] AllowActions { get; set; }

        public Dictionary<string,object> AsDictionary()
        {
            var dictionary = new Dictionary<string, object>();
            dictionary.Add("secretId", SecretId);
            dictionary.Add("secretKey", SecretKey);
            dictionary.Add("durationSeconds", DurationSeconds);
            dictionary.Add("bucket", Bucket);
            dictionary.Add("region", Region);
            dictionary.Add("allowPrefixes", AllowPrefixes);
            dictionary.Add("allowActions", AllowActions);
            return dictionary;
        }
    }
}