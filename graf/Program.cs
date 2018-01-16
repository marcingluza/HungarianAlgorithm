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
        int weight;

        public Edge(string _id, string _from, string _to, int _weight)
        {
            this.id = _id;
            this.from = _from;
            this.to = _to;
            this.Weight = _weight;
        }

        public string Id { get => id; set => id = value; }
        public string From { get => from; set => from = value; }
        public string To { get => to; set => to = value; }
        public int Weight { get => weight; set => weight = value; }
    }
    class Program
    {           
        static void Main(string[] args)
        {
            
            List<Edge> listOfEdges = new List<Edge>();
            List<String> listOfNodes = new List<String>();

            int nodesCount = 0;
            int edgesCount = 0;

            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode_node, xmlnode_edge;
            int i = 0;
            FileStream fs = new FileStream(@"graf.xml", FileMode.Open, FileAccess.Read);
            Console.WriteLine("Otwieranie graf.xml");
            xmldoc.Load(fs);
            xmlnode_node = xmldoc.GetElementsByTagName("node");
            xmlnode_edge = xmldoc.GetElementsByTagName("edge");

            for (i = 0; i <= xmlnode_node.Count - 1; i++)
            {
                string str_id = xmlnode_node[i].Attributes["id"].Value;
                listOfNodes.Add(str_id);
            }
            nodesCount = xmlnode_node.Count - 1;
            Console.WriteLine("Ilosc wezłow: {0}", nodesCount+1);

            string[] manArray = new string[xmlnode_node.Count/2];
            string[] womanArray = new string[xmlnode_node.Count/2];

            for(int l=0; l< xmlnode_node.Count / 2; l++)
            {
                manArray[l] = listOfNodes[l];
                Console.WriteLine("Wezel meski nr {0} {1}", l, manArray[l]);
                womanArray[l] = listOfNodes[l + xmlnode_node.Count / 2];
                Console.WriteLine("Wezel zenski nr {0} {1}", l, womanArray[l]);
            }

            Console.WriteLine();
            Console.WriteLine("Ilosc sciezek: " + xmlnode_edge.Count);

            for (i = 0; i <= xmlnode_edge.Count - 1; i++)
            {
                string str_id = xmlnode_edge[i].Attributes["id"].Value;
                string str_from = xmlnode_edge[i].Attributes["from"].Value;
                string str_to = xmlnode_edge[i].Attributes["to"].Value;
                int int_weight = Convert.ToInt16(xmlnode_edge[i].Attributes["weight"].Value);
                Edge Temp = new Edge(str_id, str_from, str_to, int_weight);
                Console.WriteLine("Sciezka nr {0} {1} od: {2}  do: {3}  waga: {4}", i, str_id, str_from, str_to, int_weight);
                listOfEdges.Add(Temp);
                
            }
            edgesCount = xmlnode_edge.Count - 1;

            int[,] costMatrix = new int[xmlnode_node.Count / 2, xmlnode_node.Count / 2];
            int xAxis = 0;
            int yAxis = 0;

            for (int k = 0; k < edgesCount+1; k++)
            {

                for (int j = 0; j < xmlnode_node.Count / 2; j++)
                {
                    if (listOfEdges[k].From == manArray[j])
                        xAxis = j;
                    if (listOfEdges[k].To == womanArray[j])
                        yAxis = j;
                }
                costMatrix[xAxis, yAxis] = listOfEdges[k].Weight;
                
            }
            HungarianAlgorithm HunAlg = new HungarianAlgorithm(costMatrix);
            int[] matchX =HunAlg.Run();

            Console.WriteLine();
            Console.WriteLine("Najlepsze dopasowanie: ");

            for(int m = 0; m< matchX.Length; m++)
            {
                Console.WriteLine("Mezczyzna: {0}    Kobieta: {1}", manArray[m], womanArray[matchX[m]]);
            }
           
        }
       

    }
}
