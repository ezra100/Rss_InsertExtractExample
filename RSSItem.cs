using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DTO
{
    [ElasticsearchType(Name = "rss_item")]
    public class RSSItem
    {

        [Text(Name = "title")]
        public string Title { get; set; }
        [Text (Name = "desc")]
        public string Description { get; set; }


    }
}
