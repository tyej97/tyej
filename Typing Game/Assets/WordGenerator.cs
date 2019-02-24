using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WordGenerator : MonoBehaviour {

    private static string[] wordList;


    public static void LoadWordArray(int setting)
    {
        string filename = null;
        switch (setting)
        {
            case 1:
                filename = "Assets/EasyWords.txt";
                break;
            case 2:
                filename = "Assets/MediumWords.txt";
                break;
            case 3:
                filename = "Assets/HardWords.txt";
                break;
            case 4:
                filename = "Assets/UltimateWords.txt";
                break;
        }
        int count = 0;
        try
        {
            using (StreamReader sr = new StreamReader(filename.ToString()))
            {
                while(sr.ReadLine() != null)
                {
                    count += 1;
                }    
            }
        }
        catch
        {
            
        }
        string[] tempArray = new string[count];
        try
        {
            using (StreamReader sr = new StreamReader(filename.ToString()))
            {
                while (sr.Peek() != -1)
                {
                    for (int i = 0; i < count; i++)
                    {
                        string line = sr.ReadLine();
                        line.Trim();
                        tempArray[i] = line;
                    }
                }
            }
        }
        catch
        {

        }
        wordList = tempArray;
    }
    public static string GetRandomWord ()
	{
		int randomIndex = Random.Range(0, wordList.Length);
		string randomWord = wordList[randomIndex];

		return randomWord;
	}

}
