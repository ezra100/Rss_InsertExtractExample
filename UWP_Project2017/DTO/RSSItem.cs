using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace UWP_Project2017.DTO
{
    [ElasticsearchType(Name = "rss_item")]
    public class RSSItem
    {

        [Text(Name = "title")]
        public string Title { get; set; }
        [Text (Name = "desc")]
        public string Description { get; set; }
        [Date (Name = "date")]
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return String.Format("Title:\n\t{0}\nDescription:\n\t{1}\nDate:\n\t{2}",
                Title, Description, Date.ToString());
        }
    }
}
    