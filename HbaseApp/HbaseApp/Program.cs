using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.HBase.Client;
using Microsoft.HBase;
using org.apache.hadoop.hbase.rest.protobuf.generated;
using Microsoft.Practices.EnterpriseLibrary.TransientFaultHandling;


namespace HbaseApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();

            try
            {
                var creds = new ClusterCredentials(new Uri("https://x.azurehdinsight.net"), "", "");
                var client = new HBaseClient(creds);
                var version = client.GetVersionAsync().Result;
                Console.WriteLine(version);
                var tableschema = new TableSchema();
                tableschema.name = "ReallyBigtable";
                tableschema.columns.Add(new ColumnSchema() { name = "d" });
                tableschema.columns.Add(new ColumnSchema() { name = "f" });
                client.CreateTableAsync(tableschema).Wait();
            }
            catch(Exception ex)
            {

                Console.WriteLine(ex.Message.ToString());
            }
                Console.ReadLine();



        }
    }
}
