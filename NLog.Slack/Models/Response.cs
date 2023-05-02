using System.Runtime.Serialization;

namespace NLog.Slack.Models
{
    [DataContract]
    public class Response
    {
        //// ----------------------------------------------------------------------------------------------------------

        [DataMember(Name = "ok")]
        public bool Ok { get; set; }

        //// ----------------------------------------------------------------------------------------------------------

        [DataMember(Name = "error")]
        public string Error { get; set; }

        //// ----------------------------------------------------------------------------------------------------------

        public bool HasError
        {
            get
            {
                return !Ok || string.IsNullOrWhiteSpace(this.Error);
            }
        }

        //// ----------------------------------------------------------------------------------------------------------
    }
}