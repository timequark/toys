using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Common.Entity;
using Sample.Common.ES;

/*
 * https://stackoverflow.com/questions/48813514/elasticsearch-nest-defaultmappingfor-usage
 * 
 * [5.4.0]
 * Install-Package Elasticsearch.Net -Version 5.4.0
 * Install-Package NEST -Version 5.4.0
 * http://www.voidcn.com/article/p-zbxtfypg-bcr.html
 * 
 * 
 **/
namespace Sample.Common
{
    public class ESHelper
    {
        private static readonly string ES_URL = "http://101.132.39.197:9200";
        private static readonly string ES_DEFAULT_INDEX = "mall_patent";
        private static readonly string ES_DEFAULT_TYPE  = "all";
        private static ElasticClient esClient = null;

        static ESHelper()
        {
            //var settings = new ConnectionSettings(new Uri(ES_URL));
            //settings.InferMappingFor<Patent>(i => i
            //.IndexName(ES_DEFAULT_INDEX)
            //.TypeName(ES_DEFAULT_TYPE));
            //settings.PrettyJson();
            //esClient = new ElasticClient(settings);
        }
        //public static void GetIndices()
        //{
        //    var resp = esClient.Cat.Indices(e => e.AllIndices().Format("JSON"));
        //    Console.WriteLine();
        //}

        //public static void IndexDoc(string id)
        //{
        //    Pantent p = new Pantent() { id = id };
        //    var resp = esClient.IndexDocument(p);
        //    Console.WriteLine();
        //}

        //public static void SearchDoc(string id)
        //{
        //    //var resp = esClient.Search<Pantent>(e => e.Query(f => f.Match(m => m.Field(t => t.id).Query(id))));

        //    Console.WriteLine();
        //}

        public static void GetIndices()
        {
            esClient = ESClientFactory.newClient<Patent>();

            var resp = esClient.CatIndices(e => e.AllIndices());
            Console.WriteLine();
        }

        public static void GetDoc(string id)
        {
            esClient = ESClientFactory.newClient<Patent>();

            Patent p = new Patent() { id = id };
            var resp = esClient.Get(new DocumentPath<Patent>(p));
            Console.WriteLine();
        }

        public static void SearchDoc(string id)
        {
            esClient = ESClientFactory.newClient<Patent>();

            var resp = esClient.Search<Patent>(e => e.Query(f => f.Match(m => m.Field(t => t.id).Query(id))));

            Console.WriteLine();
        }
    }
}
