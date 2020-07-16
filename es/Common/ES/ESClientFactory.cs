using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;
using Sample.Entity.Attrib;

namespace Sample.Common.ES
{
    public class ESClientFactory
    {
        private static Dictionary<string, Uri> MAP_ES_URLS = new Dictionary<string, Uri>() {
            { "es1", new Uri("http://101.132.39.197:9200")},
            { "es2", new Uri("http://101.132.39.197:9200")}
        };

        static ESClientFactory()
        {

        }

        public static ElasticClient newClient<T>() where T:class
        {
            string esTag = "";
            string indexName = "";
            string typeName = "";

            Type t = typeof(T);
            object[] objs = t.GetCustomAttributes(typeof(ESConfAttribute), true);
            if (objs.Length <= 0)
            {
                throw new Exception("实体类没有标识ESConfAttribute属性");
            }
            else
            {
                object obj = objs[0];
                ESConfAttribute conf = (ESConfAttribute)obj;
                esTag = conf.esTag;
                indexName = conf.indexName;
                typeName = conf.typeName;
            }

            Uri uri = MAP_ES_URLS[esTag];
            var settings = new ConnectionSettings(uri);
            settings.InferMappingFor<T>(i => i
            .IndexName(indexName)
            .TypeName(typeName));
            settings.PrettyJson();
            return new ElasticClient(settings);
        }
    }
}
