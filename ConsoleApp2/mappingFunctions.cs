using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ConsoleApp2
{
    internal class mappingFunctions
    {
        static public Dictionary<int, string[]> IdToNouns = new Dictionary<int, string[]>(); //Θ(1)
        static public Dictionary<string,List<int>> NounToIDS = new Dictionary<string, List<int>>(); //Θ(1)
        static public string[] SynsetIDToNouns(int ID) // Complexity of function Θ(1)
        {

            string[] Nouns = IdToNouns[ID]; //Θ(1)
            return Nouns; //Θ(1)

        }
        static public List<int> NounToSynsetIDS(string noun) // Complexity of function Θ(1)
        {
            List<int> IDs = new List<int>(); //Θ(1)
            IDs = NounToIDS[noun]; //Θ(1)
            return IDs; //Θ(1)
        }
        public static void getData(string searchFile) // Complexity of function O(n*m*k^2)
        {
            FileStream file = new FileStream(searchFile, FileMode.Open, FileAccess.Read); //Θ(1)
            StreamReader sr = new StreamReader(file); //Θ(1)
            string line; //Θ(1)

            while (!sr.EndOfStream) // num of iterations = n [ num of synsets in file ] Complexity = O(n*m*k^2)
            {
                line = sr.ReadLine(); //Θ(1)
                string[] lineParts = line.Split(new char[] { ',' }); //O(m) as m = 3 => O(1) fixed number
                string[] synset = lineParts[1].Split(new char[] { ' ' }); //Θ(m) m = num of nouns in synset [ synset.Length]
                int id = int.Parse(lineParts[0]); //Θ(1)
                IdToNouns.Add(id, synset);  //Θ(1)
                foreach (var syn in synset) // num of iterations = m [synset.Length]  Complexity = O(m*k^2)
                {
                    List<int> ids = new List<int>(); //Θ(1)
                    // Complexity of IF Condition is O(k^2)
                    if (NounToIDS.ContainsKey(syn)) //O(k^2) k is NounToIDS.Count
                    {
                        ids = NounToIDS[syn]; //Θ(1)
                        NounToIDS.Remove(syn); //O(k) k is NounToIDS.Count 
                        ids.Add(id); //Θ(1)
                        NounToIDS.Add(syn, ids); //Θ(1)

                    }
                    else
                    {
                        ids.Add(id); //Θ(1)
                        NounToIDS.Add(syn, ids); //Θ(1)

                    }

                }

               
            }
           
                sr.Close(); //Θ(1)
                file.Close(); //Θ(1)
        }
    }
}
