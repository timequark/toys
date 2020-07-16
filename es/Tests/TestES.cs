using Nest;
using Sample.Common.ES;
using Sample.Entity.ES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class TestES
    {
        //string DOC_ID = "201820289117X";
        private static string DOC_ID = "2018200950845";

        public static void run()
        {
            testCatIndices();
            testGetDoc(DOC_ID);
            testSearchDoc(DOC_ID);
        }

        private static void testCatIndices()
        {
            ElasticClient esClient = ESClientFactory.newClient<Patent>();

            var resp = esClient.CatIndices(e => e.AllIndices());
            Console.WriteLine();
        }

        private static void testGetDoc(string id)
        {
            ElasticClient esClient = ESClientFactory.newClient<Patent>();

            Patent p = new Patent() { id = id };
            var resp = esClient.Get(new DocumentPath<Patent>(p));
            Console.WriteLine();
        }

        private static void testSearchDoc(string id)
        {
            ElasticClient esClient = ESClientFactory.newClient<Patent>();

            var resp = esClient.Search<Patent>(e => e.Query(f => f.Match(m => m.Field(t => t.id).Query(id))));
            Console.WriteLine();
        }
    }
}
