using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.HBase.Client;
using Microsoft.HBase;
using org.apache.hadoop.hbase.rest.protobuf.generated;

namespace HbaseApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var creds = new ClusterCredentials("","","");
            var client = new HBaseClient(creds);
            var tableschema = new TableSchema();
            tableschema.name = "ReallyBigtable";
            tableschema.columns.Add(new ColumnSchema() { name = "d" });
            tableschema.columns.Add(new ColumnSchema() { name = "f" });
            client.CreateTableAsync(tableschema).Wait();




        }
    }
}
