using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Common;

namespace Tests
{
    class Program
    {
        //string DOC_ID = "201820289117X";
        static string DOC_ID = "2018200950845";
        static void Main(string[] args)
        {
            ESHelper.GetIndices();
            ESHelper.GetDoc(DOC_ID);
            ESHelper.SearchDoc(DOC_ID);

            Console.WriteLine();
        }
    }
}
