using System;
using UWP_Project2017.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;

namespace UWP_Project2017.DAL
{
   
    static class EsCRUD
    {
        
        public static void create(RSSChannel doc)
        {
            EsClient.Current.Index(doc);
        }
        public static List<RSSChannel> QueryById(string id)
        {
            QueryContainer queryById = new TermQuery() { Field = "_id", Value = id };

            var hits = EsClient.Current
                                   .Search<DTO.RSSChannel>(s => s.Query(q => q.MatchAll() && queryById))
                                   .Hits;

            List<RSSChannel> typedList = hits.Select(hit => hit.Source).ToList();

            return typedList;
        }

        public static List<RSSChannel> QueryAll()
        {
            var hits = EsClient.Current
                                   .Search<RSSChannel>(s => s.Query(q => q.MatchAll()))
                                   .Hits;

            List<RSSChannel> typedList = hits.Select(hit => hit.Source).ToList();

            return typedList;
        }
    }
}
