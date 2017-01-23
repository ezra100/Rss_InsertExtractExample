using Nest;
using System;
using Elasticsearch;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP_Project2017.DAL
{
    static class EsClient
    {
        #region [[Properties]]

        /// <summary>
        /// URI 
        /// </summary>
        private const string ES_URI = "http://localhost:9200";

        /// <summary>
        /// Elastic settings
        /// </summary>
        private static ConnectionSettings _settings;

        /// <summary>
        /// Current instantiated client
        /// </summary>
        public static ElasticClient Current { get; set; }

        #endregion

        #region [[Constructors]]

        /// <summary>
        /// Constructor
        /// </summary>
        static EsClient()
        {
            var node = new Uri(ES_URI);

            _settings = new ConnectionSettings(node);
            _settings.DefaultIndex(DTO.Constants.DEFAULT_INDEX);
            _settings.MapDefaultTypeNames(m => m.Add(typeof(DTO.RSSItem), DTO.Constants.DEFAULT_INDEX_TYPE));
            Current = new ElasticClient(_settings);
            Current.Map<DTO.RSSItem>(m => m.AutoMap());
            var descriptor = new CreateIndexDescriptor("myIndex").
                Mappings(
                ms => ms.Map<DTO.RSSItem>(
                    m => m.AutoMap()
                    )
                    );
        }



        #endregion
    }
}
