using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using GraphAlgorithms;

namespace graf
{
    public class Edge
    {
        string id;
        string from;
        string to;

        public Edge(string _id, string _from, string _to)
        {
            this.id = _id;
            this.from = _from;
            this.to = _to;
        }

        public string Id { get => id; set => id = value; }
        public string From { get => from; set => from = value; }
        public string To { get => to; set => to = value; }
    }
    class Program
    {

        //String XmlString = @"P:\graf.xml";
        
        
        static void Main(string[] args)
        {
            List<Edge> listOfEdges = new List<Edge>();
            List<String> listOfNodes = new List<String>();

            int nodesCount = 0;
            int edgesCount = 0;

            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode_node, xmlnode_edge;
            int i = 0;
            FileStream fs = new FileStream(@"D:\\graf.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode_node = xmldoc.GetElementsByTagName("node");
            xmlnode_edge = xmldoc.GetElementsByTagName("edge");

            for (i = 0; i <= xmlnode_node.Count - 1; i++)
            {
                string str_id = xmlnode_node[i].Attributes["id"].Value;
                listOfNodes.Add(str_id);
            }
            nodesCount = xmlnode_node.Count - 1;

            for (i = 0; i <= xmlnode_edge.Count - 1; i++)
            {
                string str_id = xmlnode_edge[i].Attributes["id"].Value;
                string str_from = xmlnode_edge[i].Attributes["from"].Value;
                string str_to = xmlnode_edge[i].Attributes["to"].Value;
                Edge Temp = new Edge(str_id, str_from, str_to);
                listOfEdges.Add(Temp);
                
            }
            edgesCount = xmlnode_edge.Count - 1;

            int[,] costMatrix = new int[nodesCount, nodesCount];

            for(int k = 0; k < edgesCount; k++)
            {

                //UTWORZENIE MACIERZY KOSZTÓW
              

                    ///////////////////////TODO///////////////////////////////
            }
            int[,] array2D = new int[,] { { 2, 3, 5 }, { 5, 4, 3 }, { 3, 5, 4 } };
            HungarianAlgorithm Algorytm = new HungarianAlgorithm(array2D);
            Algorytm.Run();

        }
       

    }
}
