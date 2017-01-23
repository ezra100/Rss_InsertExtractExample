using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;

namespace UWP_Project2017.DTO
{
    [ElasticsearchType(Name = "rss_channel")]
    public class RSSChannel
    {
        [Text(Name = "title")]
        public string Title { get; set; }
        [Text(Name = "description")]
        public string Description { get; set; }
        [Nested(Name = "items")]
        public List<RSSItem> Items { get; set; }
        public override string ToString()
        {
            string sum = "";
            foreach (RSSItem item in Items){
                sum += "\n" + item.ToString();
            }
            return String.Format("Title:\n\t{0}\nDescription:\n\t{1}\nItems:\n\t{2}",
                Title, Description, sum);
        }
    }
}
