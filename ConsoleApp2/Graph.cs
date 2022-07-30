using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ConsoleApp2
{
    internal class Graph
    {
        static public int graphRoot; //O(1)
        static public Dictionary<int,List<int>> buildGraph(string hypernymsFile) // Complexity of function Θ(n*m)
        {
            Dictionary < int, List<int>> myGraph = new Dictionary< int, List<int>>(); //Θ(1)
            FileStream file = new FileStream(hypernymsFile, FileMode.Open, FileAccess.Read); //Θ(1)
            StreamReader sr = new StreamReader(file); //Θ(1)
            List<int> nodesList; //Θ(1)
            string line; //Θ(1)
            while (!sr.EndOfStream) // num of iterations = num of synsets in file => n complexity = Θ(n*m)
            {
                line = sr.ReadLine(); //Θ(1)
                string[] synsetParts = line.Split(new char[] { ',' }); //Θ(m+1) as m = synsetsParts.Length and 1 for synset id
                if (synsetParts.Length == 1) //Θ(1)
                    graphRoot = int.Parse(synsetParts[0]); //Θ(1)
                nodesList = new List<int>(synsetParts.Length - 1); //Θ(1)

                for (int i = 1; i< synsetParts.Length; i++) //Θ(m) as m = synsetParts.Length
                {
                    nodesList.Add(int.Parse(synsetParts[i])); //Θ(1)

                }

                myGraph.Add(int.Parse(synsetParts[0]),nodesList); //Θ(1)

            }
            sr.Close(); //Θ(1)
            file.Close(); //Θ(1)
            return myGraph; //Θ(1)

        }
    }
}
