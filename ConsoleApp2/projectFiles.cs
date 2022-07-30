using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class projectFiles
    {
        static public void SampleFilesName(char choice, ref string file1, ref string file2, ref string file3, ref string file4) //Function Complexity Θ(1)
        {

            switch (choice) //Θ(1)
            {
                case '1':
                    file1 = "Sample\\Case1\\Input\\1synsets.txt"; //Θ(1)
                    file2 = "Sample\\Case1\\Input\\2hypernyms.txt"; //Θ(1)
                    file3 = "Sample\\Case1\\Input\\3RelationsQueries.txt"; //Θ(1)
                    file4 = "Sample\\Case1\\Input\\4OutcastQueries.txt"; //Θ(1)

                    break; //Θ(1)
                case '2':
                    file1 = "Sample\\Case2\\Input\\1synsets.txt"; //Θ(1)
                    file2 = "Sample\\Case2\\Input\\2hypernyms.txt"; //Θ(1)
                    file3 = "Sample\\Case2\\Input\\3RelationsQueries.txt"; //Θ(1)
                    break; //Θ(1)
                case '3':
                    file1 = "Sample\\Case3\\Input\\1synsets.txt"; //Θ(1)
                    file2 = "Sample\\Case3\\Input\\2hypernyms.txt"; //Θ(1)
                    file3 = "Sample\\Case3\\Input\\3RelationsQueries.txt"; //Θ(1)
                    file4 = "Sample\\Case3\\Input\\4OutcastQueries.txt"; //Θ(1)


                    break; //Θ(1)
                case '4':
                    file1 = "Sample\\Case4\\Input\\1synsets.txt"; //Θ(1)
                    file2 = "Sample\\Case4\\Input\\2hypernyms.txt"; //Θ(1)
                    file3 = "Sample\\Case4\\Input\\3RelationsQueries.txt"; //Θ(1)
                    file4 = "Sample\\Case4\\Input\\4OutcastQueries.txt"; //Θ(1)

                    break; //Θ(1)
                case '5':
                    file1 = "Sample\\Other special cases\\2 commons case (Bidirectional)\\Input\\1synsets.txt"; //Θ(1)
                    file2 = "Sample\\Other special cases\\2 commons case (Bidirectional)\\Input\\2hypernyms.txt"; //Θ(1)
                    file3 = "Sample\\Other special cases\\2 commons case (Bidirectional)\\Input\\3RelationsQueries.txt"; //Θ(1)

                    break; //Θ(1)
                case '6':
                    file1 = "Sample\\Other special cases\\Many-Many (Noun in more than 1 synset)\\Input\\1synsets.txt"; //Θ(1)
                    file2 = "Sample\\Other special cases\\Many-Many (Noun in more than 1 synset)\\Input\\2hypernyms.txt"; //Θ(1)
                    file3 = "Sample\\Other special cases\\Many-Many (Noun in more than 1 synset)\\Input\\3RelationsQueries.txt"; //Θ(1)

                    break; //Θ(1)
                default:
                    Console.WriteLine(" Wrong Choice .. "); //Θ(1)
                    break; //Θ(1)

            }
        }
        static public void SampleOuputFiles(char choice, ref string file1,ref string file2) // Function Complexity Θ(1)
        {
            switch (choice) //Θ(1)
            {
                case '1':
                    file1 = "Sample\\Case1\\Output\\Output1.txt"; //Θ(1)
                    file2 = "Sample\\Case1\\Output\\Output2.txt"; //Θ(1)
                    break; //Θ(1)
                case '2':
                    file1 = "Sample\\Case2\\Output\\Output1.txt"; //Θ(1)
                    break; //Θ(1)
                case '3':
                    file1 = "Sample\\Case3\\Output\\Output1.txt"; //Θ(1)
                    file2 = "Sample\\Case3\\Output\\Output2.txt"; //Θ(1)
                    break; //Θ(1)
                case '4':
                    file1 = "Sample\\Case4\\Output\\Output1.txt"; //Θ(1)
                    file2 = "Sample\\Case4\\Output\\Output2.txt"; //Θ(1)
                    break; //Θ(1)
                case '5':
                    file1 = "Sample\\Other special cases\\2 commons case (Bidirectional)\\Output\\Output1.txt"; //Θ(1)
                    break; //Θ(1)
                case '6':
                    file1 = "Sample\\Other special cases\\Many-Many (Noun in more than 1 synset)\\Output\\Output1.txt"; //Θ(1)
                    break; //Θ(1)
                default: 
                    Console.WriteLine("Wrong Choice .. "); //Θ(1)
                    break; //Θ(1)

            }
        }
        static public void CompleteFilesName(char choice1, char choice2, ref string file1, ref string file2, ref string file3, ref string file4) // Function Complexity Θ(1)
        {
            switch (choice1) //Θ(1)
            {
                case '1':
                    if (choice2 == '1') //Θ(1)
                    {
                        file1 = "Complete\\1-Small\\Case1_100_100\\Input\\1synsets.txt"; //Θ(1)
                        file2 = "Complete\\1-Small\\Case1_100_100\\Input\\2hypernyms.txt"; //Θ(1)
                        file3 = "Complete\\1-Small\\Case1_100_100\\Input\\3RelationsQueries.txt"; //Θ(1)
                        file4 = "Complete\\1-Small\\Case1_100_100\\Input\\4OutcastQueries.txt"; //Θ(1)


                    }
                    else if (choice2 == '2') //Θ(1)
                    {
                        file1 = "Complete\\1-Small\\Case2_1000_500\\Input\\1synsets.txt"; //Θ(1)
                        file2 = "Complete\\1-Small\\Case2_1000_500\\Input\\2hypernyms.txt"; //Θ(1)
                        file3 = "Complete\\1-Small\\Case2_1000_500\\Input\\3RelationsQueries.txt"; //Θ(1)
                        file4 = "Complete\\1-Small\\Case2_1000_500\\Input\\4OutcastQueries.txt"; //Θ(1)
                    }

                    break; //Θ(1)
                case '2':
                    if (choice2 == '1') //Θ(1)
                    {
                        file1 = "Complete\\2-Medium\\Case1_10000_5000\\Input\\1synsets.txt"; //Θ(1)
                        file2 = "Complete\\2-Medium\\Case1_10000_5000\\Input\\2hypernyms.txt"; //Θ(1)
                        file3 = "Complete\\2-Medium\\Case1_10000_5000\\Input\\3RelationsQueries.txt"; //Θ(1)
                        file4 = "Complete\\2-Medium\\Case1_10000_5000\\Input\\4OutcastQueries.txt"; //Θ(1)
                    }
                    else if (choice2 == '2') //Θ(1)
                    {
                        file1 = "Complete\\2-Medium\\Case2_10000_50000\\Input\\1synsets.txt"; //Θ(1)
                        file2 = "Complete\\2-Medium\\Case2_10000_50000\\Input\\2hypernyms.txt"; //Θ(1)
                        file3 = "Complete\\2-Medium\\Case2_10000_50000\\Input\\3RelationsQueries.txt"; //Θ(1)
                        file4 = "Complete\\2-Medium\\Case2_10000_50000\\Input\\4OutcastQueries.txt"; //Θ(1)
                    }

                    break; //Θ(1)
                case '3':
                    if (choice2 == '1') //Θ(1)
                    {
                        file1 = "Complete\\3-Large\\Case1_82K_100K_5000RQ\\Input\\1synsets.txt"; //Θ(1)
                        file2 = "Complete\\3-Large\\Case1_82K_100K_5000RQ\\Input\\2hypernyms.txt"; //Θ(1)
                        file3 = "Complete\\3-Large\\Case1_82K_100K_5000RQ\\Input\\3RelationsQueries.txt"; //Θ(1)
                        file4 = "Complete\\3-Large\\Case1_82K_100K_5000RQ\\Input\\4OutcastQueries.txt"; //Θ(1)
                    }
                    else if (choice2 == '2') //Θ(1)
                    {
                        file1 = "Complete\\3-Large\\Case2_82K_300K_1500RQ\\Input\\1synsets.txt"; //Θ(1)
                        file2 = "Complete\\3-Large\\Case2_82K_300K_1500RQ\\Input\\2hypernyms.txt"; //Θ(1)
                        file3 = "Complete\\3-Large\\Case2_82K_300K_1500RQ\\Input\\3RelationsQueries.txt"; //Θ(1)
                        file4 = "Complete\\3-Large\\Case2_82K_300K_1500RQ\\Input\\4OutcastQueries.txt"; //Θ(1)
                    }
                    else if (choice2 == '3') //Θ(1)
                    {

                        file1 = "Complete\\3-Large\\Case3_82K_300K_5000RQ\\Input\\1synsets.txt"; //Θ(1)
                        file2 = "Complete\\3-Large\\Case3_82K_300K_5000RQ\\Input\\2hypernyms.txt"; //Θ(1)
                        file3 = "Complete\\3-Large\\Case3_82K_300K_5000RQ\\Input\\3RelationsQueries.txt"; //Θ(1)

                    }

                    break; //Θ(1)
                default:
                    Console.WriteLine(" Wrong Choice .. "); //Θ(1)
                    break; //Θ(1)

            }
        }
        static public void CompleteOutputFiles(char choice1 , char choice2, ref string file1,ref string file2) //Function Complexity Θ(1)
        {
            switch (choice1) //Θ(1)
            {
                case '1':
                    if (choice2 == '1') //Θ(1)
                    {
                        file1 = "Complete\\1-Small\\Case1_100_100\\Output\\Output1.txt"; //Θ(1)
                        file2 = "Complete\\1-Small\\Case1_100_100\\Output\\Output2.txt"; //Θ(1)
                    }
                    else if(choice2 == '2') //Θ(1)
                    {
                        file1 = "Complete\\1-Small\\Case2_1000_500\\Output\\Output1.txt"; //Θ(1)
                        file2 = "Complete\\1-Small\\Case2_1000_500\\Output\\Output2.txt"; //Θ(1)
                    }
                    else Console.WriteLine(" Wrong Choice .. "); //Θ(1)
                    break; //Θ(1)
                case '2':
                    if (choice2 == '1') //Θ(1)
                    {
                        file1 = "Complete\\2-Medium\\Case1_10000_5000\\Output\\Output1.txt"; //Θ(1)
                        file2 = "Complete\\2-Medium\\Case1_10000_5000\\Output\\Output2.txt";//Θ(1)
                    }
                    else if (choice2 == '2') //Θ(1)
                    {
                        file1 = "Complete\\2-Medium\\Case2_10000_50000\\Output\\Output1.txt"; //Θ(1)
                        file2 = "Complete\\2-Medium\\Case2_10000_50000\\Output\\Output2.txt"; //Θ(1)
                    }
                    else Console.WriteLine(" Wrong Choice .. "); //Θ(1)
                    break; //Θ(1)
                case '3':
                    if (choice2 == '1') //Θ(1)
                    {
                        file1 = "Complete\\3-Large\\Case1_82K_100K_5000RQ\\Output\\Output1.txt"; //Θ(1)
                        file2 = "Complete\\3-Large\\Case1_82K_100K_5000RQ\\Output\\Output2.txt"; //Θ(1)

                    }
                    else if (choice2 == '2') //Θ(1)
                    {
                        file1 = "Complete\\3-Large\\Case2_82K_300K_1500RQ\\Output\\Output1.txt"; //Θ(1)
                        file2 = "Complete\\3-Large\\Case2_82K_300K_1500RQ\\Output\\Output2.txt"; //Θ(1)

                    }
                    else if (choice2 == '3') //Θ(1)
                    {

                        file1 = "Complete\\3-Large\\Case3_82K_300K_5000RQ\\Output\\Output1.txt"; //Θ(1)
                        file2 = "Complete\\3-Large\\Case3_82K_300K_5000RQ\\Output\\Output2.txt"; //Θ(1)
                    }
                    else Console.WriteLine(" Wrong Choice .. "); //Θ(1)
                    break; //Θ(1)
                default: 
                    Console.WriteLine(" Wrong Choice .. "); //Θ(1)
                    break; //Θ(1)
            }
        }

    }
}
