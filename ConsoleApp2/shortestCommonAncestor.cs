using System;
using System.Collections.Generic;
using System.IO;
using WordNetSemantics;

namespace ConsoleApp2
{
    internal class shortestCommonAncestor
    {
        struct graphNode
        {
            public int id;
            public bool visited;
            public int distance;

        }
        static graphNode[] Nodes; //Θ(1)
        static public int n; //Θ(1)
        static public string[,] cases; //Θ(1)
        static Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>(); //Θ(1)
        static public int distance = 0; //Θ(1)
        static public void getData_RelationFile(string filePath) // function Complexity Θ(n)
        {
            FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read); //Θ(1)
            StreamReader sr = new StreamReader(file); //Θ(1)
            string line; //Θ(1)
            line = sr.ReadLine(); //Θ(1)
            n = int.Parse(line); //Θ(1)
            cases = new string[n, 2]; int i = 0; //Θ(1)
            while (!sr.EndOfStream) //Θ(n) n is relation file length
            {
                line = sr.ReadLine(); //Θ(1)
                string[] lineParts = line.Split(new char[] { ',' }); // split into 2 parts => fixed number Θ(1)
                cases[i, 0] = lineParts[0]; //Θ(1)
                cases[i, 1] = lineParts[1]; //Θ(1)
                i++; //Θ(1)

            }

            sr.Close(); //Θ(1)
            file.Close(); //Θ(1)
        }
        static public Dictionary<int, string[]> outcastCases = new Dictionary<int, string[]>(); //Θ(1)
        static public void getData_outCastFile(string filePath) // Function Complexity Θ(n*k)
        {

            FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read); //Θ(1)
            StreamReader sr = new StreamReader(file); //Θ(1)
            string line; //Θ(1)
            line = sr.ReadLine(); //Θ(1)
            n = int.Parse(line); //Θ(1)
            int i = 0; //Θ(1)
            while (!sr.EndOfStream)  // num of iterations = n  Θ(n*k)
            {
                line = sr.ReadLine(); //Θ(1)
                string[] lineParts = line.Split(new char[] { ',' }); // Θ(k) k is num of words in line 
                outcastCases[i] = lineParts; // Θ(1)
                i++;  // Θ(1)

            }
            sr.Close();  // Θ(1)
            file.Close();  // Θ(1)

        }
        static public int SCA_IDs(int id1, int id2) // Function Complexity O(n*m) n => num of parents in id1 dictionary and m => num of parents in id2 dictionary
        {

            dic = Program.graphDic; //Θ(1)
            if (id1 == id2) //Θ(1)
            {
                distance = 0; //Θ(1)
                return id1; //Θ(1)
            }
            if (id1 == Graph.graphRoot) //Θ(n*m)
            {
                Dictionary<int, int> kv = new Dictionary<int, int>(); //Θ(1)
                SCA_Distance(id2, ref kv); //Θ(n*m)
                foreach (var v in kv.Keys) // num of iterations = k (kv.Count) complexity => Θ(k)
                {
                    if (id1 == v) //Θ(1)
                    {
                        distance = kv[v]; //Θ(1)
                        return id1; //Θ(1)
                    }

                }

            }
            if (id2 == Graph.graphRoot) //Θ(n*m)
            {
                Dictionary<int, int> kv = new Dictionary<int, int>(); //Θ(1)
                SCA_Distance(id1, ref kv); //Θ(n*m)
                foreach (var v in kv.Keys) // num of iterations = k (kv.Count) complexity => Θ(k)
                {
                    if (id2 == v) //Θ(1)
                    {
                        distance = kv[v]; //Θ(1)
                        return id2; //Θ(1)
                    }

                }

            }
           
            Dictionary<int, int> kvp = new Dictionary<int, int>(); //Θ(1)
            SCA_Distance(id1, ref kvp); //Θ(n*m)
            Dictionary<int, int> kvp2 = new Dictionary<int, int>(); //Θ(1)
            SCA_Distance(id2, ref kvp2); //Θ(n*m)
            int totalDistance = 0, min = 10000; int id = 0; //Θ(1)
            foreach (int u in kvp.Keys) //num of iterations n = kvp.Count complexity => Θ(n*m)
            {
                // complexity of if condition => O(m)
                if (id2 == u) //Θ(1)
                {
                    
                    totalDistance = kvp[u]; //Θ(1)
                    if (totalDistance<min) //Θ(1)
                    {
                        min = totalDistance; //Θ(1)
                        id = u; //Θ(1)

                    }
                        
                    
                }
                else //Θ(m)
                {
                    foreach (int v in kvp2.Keys) //num of iterations m = kvp2.Count complexity => Θ(m)
                    {
                        if (id1 == v) //Θ(1)
                        {
                            
                            totalDistance = kvp2[v]; //Θ(1)
                            if (totalDistance < min) //Θ(1)
                            {
                                min = totalDistance; //Θ(1)
                                id = v; //Θ(1)
                            }

                        }
                        if (u == v) //Θ(1)
                        {
                            
                            totalDistance = kvp[u] + kvp2[v]; //Θ(1)
                            if (totalDistance < min) //Θ(1)
                            {
                                min = totalDistance; //Θ(1)
                                id = u; //Θ(1)

                            }
                            
                        }
                        

                    }
                }

            }
            distance = min; //Θ(1)
            return id; //Θ(1)

        }
        static public string[] SCA_Nouns(string noun1, string noun2) // Function Complexity  N = l*k*n*m Θ(N)
        {
            List<int> IDs1 = new List<int>(); //Θ(1)
            IDs1 = mappingFunctions.NounToSynsetIDS(noun1);//Θ(1)
            List<int> IDs2 = new List<int>(); //Θ(1)
            IDs2 = mappingFunctions.NounToSynsetIDS(noun2); //Θ(1)
            int minDistance = 10000; int SCA = 0; //Θ(1)
            for (int i = 0; i < IDs1.Count; i++) // num of iterations l Complexity => Θ(l*k*n*m)
            {
                for (int j = 0; j < IDs2.Count; j++) // num of iterations => k = IDs2.Count Complexity => Θ(k*n*m)
                {
                    
                    int sca = SCA_IDs(IDs1[i], IDs2[j]); //Θ(n*m)

                    if (distance < minDistance) //Θ(1)
                    {
                        minDistance = distance; //Θ(1)
                        SCA = sca; //Θ(1)
                    }
                }
            }
            distance = minDistance; //Θ(1)
            string[] scaNouns = mappingFunctions.SynsetIDToNouns(SCA); //Θ(1)
            return scaNouns; //Θ(1)

        }
        static public void SCA_Distance(int id, ref Dictionary<int, int> mydic) // Function Complexity Θ(n*m)
        {
            dic = Program.graphDic; //Θ(1)
            Nodes = new graphNode[dic.Count]; //Θ(1)
            for (int i = 0; i < dic.Count; i++) // num of iterations = m (dic.Count) complexity => Θ(m)
            {
                Nodes[i].id = i; //Θ(1)
                Nodes[i].visited = false; //Θ(1)
                Nodes[i].distance = 0; //Θ(1)

            }
            Queue<int> queue = new Queue<int>(); //Θ(1)
            queue.Enqueue(id); //Θ(1)
            while (queue.Count > 0) // num of iterations n (num of parents of id ) complexity => Θ(n*m)
            {
                int u = queue.Dequeue(); //Θ(1)
                List<int> parents = new List<int>(); //Θ(1)
                parents = dic[u]; //Θ(1)
                for (int i = 0; i < parents.Count; i++) // num of iterations m (parents.Count) complexity => Θ(m)
                {
                    
                    int m = parents[i]; //Θ(1)
                    if (!Nodes[m].visited) //Θ(1)
                    {
                        Nodes[m].visited = true; //Θ(1)
                        Nodes[m].distance = Nodes[u].distance + 1; //Θ(1)
                        queue.Enqueue(m); //Θ(1)
                        mydic.Add(m, Nodes[m].distance); //Θ(1)
                    }
                    

                }


            }
            
        }
        static public string outcastNoun(string[] nouns) // Function complexity Θ(m*k*N)
        {
            int maxDistance = -1; string outcastNoun = ""; //Θ(1)
            for (int i = 0; i < nouns.Length; i++) //  num of iterations m => nouns.Length complexity Θ(m*k*N)
            {
                int total = 0; //Θ(1)
                for (int j = 0; j < nouns.Length; j++) // num of iterations k => nouns.Length complexity Θ(k*N)
                {
                    SCA_Nouns(nouns[i], nouns[j]); //Θ(N)
                    total += distance; //Θ(1)
                }
                //Console.WriteLine("total is : "+total);
                if (total > maxDistance) //Θ(1)
                {
                    maxDistance = total; //Θ(1)
                    outcastNoun = nouns[i]; //Θ(1)
                }

            }
            return outcastNoun; //Θ(1)


        }

    }
}
