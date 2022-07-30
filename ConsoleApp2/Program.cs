using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ConsoleApp2;
using System.Diagnostics;

namespace WordNetSemantics

{
    internal class Program
    {
       public static Dictionary<int, List<int>> graphDic = new Dictionary<int, List<int>>();

        static void Main(string[] args)
        {
            
            FileStream file; StreamReader sr; string line;  // Θ(1)
            FileStream file2; StreamWriter sw; //Θ(1)
            string[,] cases; int wrongAns = 0; //Θ(1)
            Console.WriteLine("\t\t\t   |--- WordNet Semantics Project ---| \n  [1] Sample Test Cases \n  [2] Complete Test Cases "); //Θ(1)
            Console.Write(" Enter Your Choice : "); //Θ(1)
            char choice = (char) Console.ReadLine()[0]; //Θ(1)
            char ch;
            string sysnsetsFileName = "", hypernymsFileName = "" , relationFile ="",outCastFile ="",outputFile1 ="" , outputFile2 =""; //Θ(1)
            switch (choice)
            {
                case '1':

                    #region Sample Test Cases

                    Console.WriteLine("  1- Sample Test No.1 \n  2- Sample Test No.2 \n  3- Sample Test No.3 \n  4- Sample Test No.4"); //Θ(1)
                    Console.WriteLine("  5- Bidirectional TestCase \n  6- Many-Many TestCase "); //Θ(1)
                    Console.Write(" Enter Your Choice : "); //Θ(1)
                    ch = (char)Console.ReadLine()[0]; //Θ(1)
                    projectFiles.SampleFilesName(ch, ref sysnsetsFileName, ref hypernymsFileName, ref relationFile, ref outCastFile); //Θ(1)
                    // STEP 1 build wordnet Graph
                    graphDic = Graph.buildGraph(hypernymsFileName); // Θ(n*m) where n is synsets number 
                    // STEP 2 load data from txt files
                    mappingFunctions.getData(sysnsetsFileName); // Θ(n*m*k^2)
                    shortestCommonAncestor.getData_RelationFile(relationFile); //Θ(n)
                    //STEP 3 check output
                    projectFiles.SampleOuputFiles(ch, ref outputFile1, ref outputFile2); //Θ(1)
                    file = new FileStream(outputFile1, FileMode.Open, FileAccess.Read); //Θ(1)
                    sr = new StreamReader(file); //Θ(1)
                    wrongAns = 0; //Θ(1)
                    cases = shortestCommonAncestor.cases; int j = 0; //Θ(1)
                    file2 = new FileStream("sample case " + ch + " output 1.txt", FileMode.Create, FileAccess.Write); //Θ(1)
                    sw = new StreamWriter(file2); //Θ(1)
                    // 1- Semantics Relations 
                    while (!sr.EndOfStream) // num of iterations m Complexity Θ(m*N)
                    {
                        line = sr.ReadLine(); //Θ(1)
                        string[] parts = line.Split(','); // split into 2 parts fixed number complexity Θ(1) 
                        string[] actualSCA = parts[1].Split(' '); // Θ(1)
                        string[] recevedSCA = shortestCommonAncestor.SCA_Nouns(cases[j, 0], cases[j, 1]); // Θ(N) N = l*k*n*m 
                        int recevedDistance = shortestCommonAncestor.distance; //Θ(1)
                        if (recevedDistance != int.Parse(parts[0]) && recevedSCA[0] != actualSCA[0]) //Θ(1)
                            wrongAns++; //Θ(1)

                        sw.Write(recevedDistance.ToString() + ","); //Θ(1)
                        for (int m = 0; m < recevedSCA.Length; m++) //Θ(1)
                        {
                            sw.Write(recevedSCA[m] + " "); //Θ(1)
                        }
                        sw.WriteLine(); //Θ(1)


                        j++; //Θ(1)

                    }
                    sw.Close(); //Θ(1)
                    // 2- Find OutCast (odd)word
                    if (ch == '1' || ch == '3' || ch == '4')
                    {
                        file2 = new FileStream("sample case " + ch + " output 2.txt", FileMode.Create, FileAccess.Write); //Θ(1)
                        sw = new StreamWriter(file2); //Θ(1)
                        shortestCommonAncestor.getData_outCastFile(outCastFile); //Θ(n*k)
                        Dictionary<int, string[]> Cases = new Dictionary<int, string[]>(); //Θ(1)
                        Cases = shortestCommonAncestor.outcastCases; //Θ(1)
                        file = new FileStream(outputFile2, FileMode.Open, FileAccess.Read); //Θ(1)
                        sr = new StreamReader(file); int x = 0; //Θ(1)
                        while (!sr.EndOfStream) // num of iterations l complexity Θ(l*m*k*N)
                        {
                            line = sr.ReadLine(); //Θ(1)
                            string[] parts = line.Split(' '); //Θ(1)
                            string recevedNoun = shortestCommonAncestor.outcastNoun(Cases[x]); //Θ(m*k*N)
                            if (parts[0] != recevedNoun) //Θ(1)
                                  wrongAns++; //Θ(1)
                            
                            sw.WriteLine(recevedNoun); //Θ(1)
                            x++; //Θ(1)
                        }
                        sr.Close();//Θ(1)
                        sw.Close();//Θ(1)

                    }
                    if (wrongAns == 0) //Θ(1)
                    {
                        Console.WriteLine(" Congratulations Sample Test No.{0} runs successfully .. !!", ch); //Θ(1)

                    }

                    #endregion
                    break; //Θ(1)
                case '2': 

                    #region Complete Test Cases

                    Console.WriteLine("  1- Small Test \n  2- Medium Test \n  3- Large Test "); //Θ(1)
                    Console.Write(" Enter Your Choice : "); //Θ(1)
                    ch = (char)Console.ReadLine()[0]; //Θ(1)
                    char ch1 = ' ';
                    if (ch == '1' || ch == '2') //Θ(1)
                    {
                        Console.WriteLine("  1- Test Case No.1 \n  2- Test Case No.2 "); //Θ(1)
                        Console.Write(" Enter Your Choice : "); //Θ(1)
                        ch1 = (char)Console.ReadLine()[0]; //Θ(1)
                        projectFiles.CompleteFilesName(ch, ch1, ref sysnsetsFileName, ref hypernymsFileName, ref relationFile, ref outCastFile); //Θ(1)


                    }
                    else if (ch == '3') //Θ(1)
                    {
                        Console.WriteLine("  1- Test Case No.1 \n  2- Test Case No.2 \n  3- Test Case No.3 ");//Θ(1)
                        Console.Write(" Enter Your Choice : "); //Θ(1)
                        ch1 = (char)Console.ReadLine()[0]; //Θ(1)
                        projectFiles.CompleteFilesName(ch, ch1, ref sysnsetsFileName, ref hypernymsFileName, ref relationFile, ref outCastFile); //Θ(1)
                    }
                    else //Θ(1)
                        Console.WriteLine(" Wrong Choice .. "); //Θ(1)

                    // STEP 1 build wordnet Graph
                    graphDic = Graph.buildGraph(hypernymsFileName); //Θ(n*m)
                    // STEP 2 load data from txt files
                    mappingFunctions.getData(sysnsetsFileName); //O(n*m*k^2)
                    shortestCommonAncestor.getData_RelationFile(relationFile); //Θ(n)
                    projectFiles.CompleteOutputFiles(ch, ch1, ref outputFile1, ref outputFile2); //Θ(1)
                    file = new FileStream(outputFile1, FileMode.Open, FileAccess.Read); //Θ(1)
                    sr = new StreamReader(file); //Θ(1)

                    // 1- Semantics Relations 
                    cases = shortestCommonAncestor.cases; int i = 0; //Θ(1)
                    wrongAns = 0; //Θ(1)
                    file2 = new FileStream("Complete case " + ch + "." + ch1 + " output 1.txt", FileMode.Create, FileAccess.Write); //Θ(1)
                    sw = new StreamWriter(file2); //Θ(1)
                    Stopwatch SW = Stopwatch.StartNew(); //Θ(1)
                    while (!sr.EndOfStream) // num of iterations m complexity => Θ(m*N)
                    {
                        line = sr.ReadLine(); //Θ(1)
                        string[] parts = line.Split(','); //Θ(1)
                        string[] actualnouns = parts[1].Split(' '); //Θ(1)
                        string[] recevednouns = shortestCommonAncestor.SCA_Nouns(cases[i, 0], cases[i, 1]); //Θ(N)
                        int recevedDistance = shortestCommonAncestor.distance; //Θ(1)
                        if (recevedDistance != int.Parse(parts[0]) && recevednouns[0] != actualnouns[0]) //Θ(1)
                            wrongAns++; //Θ(1)

                        sw.Write(recevedDistance.ToString() + ","); //Θ(1)
                        for (int m = 0; m < recevednouns.Length; m++) // num of iterations n = recevednouns.Length complexity Θ(n)
                            sw.Write(recevednouns[m] + " "); //Θ(1)
                        
                        sw.WriteLine(); //Θ(1)
                        i++; //Θ(1)

                    }
                    SW.Stop(); //Θ(1)
                    sr.Close(); //Θ(1)
                    sw.Close(); //Θ(1)
                    // output 1 Time  
                    double TimeInSec; //Θ(1)
                    Console.WriteLine("\t\t [ Semantic Relations Time ] "); //Θ(1)
                    if (ch == '1') //Θ(1)
                    {
                        if (SW.ElapsedMilliseconds <= 60000) //Θ(1)
                        {
                            Console.WriteLine(" \t Time in MilliSeconds : " + SW.ElapsedMilliseconds + "ms"); //Θ(1)
                            TimeInSec = SW.ElapsedMilliseconds / 1000; //Θ(1)
                            Console.WriteLine(" \t Time in Seconds : " + TimeInSec + "s"); //Θ(1)
                        }
                    }
                    else if (ch == '2') //Θ(1)
                    {

                        if (SW.ElapsedMilliseconds <= 60000 || SW.ElapsedMilliseconds <= 120000) //Θ(1)
                        {
                            Console.WriteLine(" \t Time in MilliSeconds : " + SW.ElapsedMilliseconds + "ms"); //Θ(1)
                            TimeInSec = SW.ElapsedMilliseconds / 1000; //Θ(1)
                            Console.WriteLine(" \t Time in Seconds : " + TimeInSec + "s"); //Θ(1)
                        }
                        

                    }
                    else if (ch == '3') //Θ(1)
                    {

                        if (SW.ElapsedMilliseconds <= 210000 || SW.ElapsedMilliseconds <= 360000) //Θ(1)
                        {
                            Console.WriteLine(" \t Time in MilliSeconds : " + SW.ElapsedMilliseconds + "ms"); //Θ(1)
                            TimeInSec = SW.ElapsedMilliseconds / 1000; //Θ(1)
                            Console.WriteLine(" \t Time in Seconds : " + TimeInSec + "s"); //Θ(1)
                        }
                    
                    }
            
                 
                    // 2- Find OutCast (odd)word
                    if (ch1 != '3')
                    {
                        SW = Stopwatch.StartNew(); //Θ(1)
                        shortestCommonAncestor.getData_outCastFile(outCastFile); //Θ(n*k)
                        Dictionary<int, string[]> Cases = new Dictionary<int, string[]>(); //Θ(1)
                        Cases = shortestCommonAncestor.outcastCases; //Θ(1)
                        file = new FileStream(outputFile2, FileMode.Open, FileAccess.Read); //Θ(1)
                        sr = new StreamReader(file); int x = 0; //Θ(1)
                        file2 = new FileStream("Complete case " + ch + "." + ch1 + " output 2.txt", FileMode.Create, FileAccess.Write); //Θ(1)
                        sw = new StreamWriter(file2); //Θ(1)
                        while (!sr.EndOfStream) // num of iterations n complexity Θ(n*(m*k*N))
                        {
                            line = sr.ReadLine(); //Θ(1)
                            string[] parts = line.Split(' '); //Θ(1)
                            string recevedNoun = shortestCommonAncestor.outcastNoun(Cases[x]); //Θ(m*k*N)
                            if (parts[0] != recevedNoun) //Θ(1)
                                wrongAns++; //Θ(1)
                            sw.WriteLine(recevedNoun); //Θ(1)
                            x++; //Θ(1)
                        }
                        SW.Stop();  //Θ(1)
                        sw.Close(); //Θ(1)
                        sr.Close(); //Θ(1)

                    }
                    if(ch1 != '3')  //Θ(1)
                        Console.WriteLine("\t\t [ Outcast Word Time ] "); //Θ(1)
                    if (ch == '1')  //Θ(1)
                    {
                        if (SW.ElapsedMilliseconds <= 60000)  //Θ(1)
                        {
                            Console.WriteLine(" \t Time in MilliSeconds : " + SW.ElapsedMilliseconds + "ms");  //Θ(1)
                            TimeInSec = SW.ElapsedMilliseconds / 1000;  //Θ(1)
                            Console.WriteLine(" \t Time in Seconds : " + TimeInSec + "s");  //Θ(1)
                        }
                    }
                    else if (ch == '2') //Θ(1)
                    {
                        
                        if (SW.ElapsedMilliseconds <= 30000 || SW.ElapsedMilliseconds <= 45000)  //Θ(1)
                        {
                            TimeInSec = SW.ElapsedMilliseconds / 1000;  //Θ(1)
                            Console.WriteLine(" \t Time in MilliSeconds : " + SW.ElapsedMilliseconds + "ms");  //Θ(1)
                            Console.WriteLine(" \t Time in Seconds : " + TimeInSec +"s");  //Θ(1)

                        }
                    }
                    else if (ch == '3')  //Θ(1)
                    {
                        if (ch1 != '3')  //Θ(1)
                        {
                            if (SW.ElapsedMilliseconds <= 129000 || SW.ElapsedMilliseconds <= 60000)  //Θ(1)
                            {
                                TimeInSec = SW.ElapsedMilliseconds / 1000;  //Θ(1)
                                Console.WriteLine(" \t Time in MilliSeconds : " + SW.ElapsedMilliseconds + "ms");  //Θ(1)
                                Console.WriteLine(" \t Time in Seconds : " + TimeInSec + "s");  //Θ(1)
                            }
                        }
                    }

                    if (wrongAns == 0)  //Θ(1)
                    {
                        Console.WriteLine(" Congratulations Complete Test No:{0}.{1} runs successfully .. !!", ch,ch1);  //Θ(1)
                    }
                    #endregion

                    break;  //Θ(1)
                default: //Θ(1)
                    Console.WriteLine(" Wrong Choice .. "); //Θ(1)
                    break; //Θ(1)


            }
           
        }
        
       
       
    }
}
