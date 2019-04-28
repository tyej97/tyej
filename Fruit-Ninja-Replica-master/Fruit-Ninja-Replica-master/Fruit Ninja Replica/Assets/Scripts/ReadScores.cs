using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class ReadScores : MonoBehaviour
{

    public Text HighScores;
    public static int num_scores = 5;

    private void Start()
    {
        ShowTopScores();
    }


    public void ShowTopScores()
    {
        string path = "Assets/Scores.txt";
        string line;
        string[] fields;
        string[] playerNames = new string[num_scores];
        int[] playerScores = new int[num_scores];
        int scores_read = 0;

        HighScores.text = "";

        StreamReader reader = new StreamReader(path);
        while(!reader.EndOfStream && scores_read < num_scores)
        {
            line = reader.ReadLine();
            fields = line.Split(',');
            HighScores.text += fields[0] + " : " + fields[1] + "\n";
            scores_read += 1;
        }
    }
    static public void WriteScore()
    {
        string path = "Assets/Scores.txt";
        string line;
        string[] fields;
        string[] playerNames = new string[num_scores];
        int[] playerScores = new int[num_scores];
        int scores_read = 0;
        string[,] HighScores = new string[num_scores,2];
        string[,] newHighScores = new string[num_scores, 2];

        StreamReader reader = new StreamReader(path);
        while (!reader.EndOfStream && scores_read < num_scores)
        {
            line = reader.ReadLine();
            fields = line.Split(',');
            HighScores[scores_read,0] = fields[0];
            HighScores[scores_read,1] = fields[1];
            scores_read += 1;
        }

        reader.Close();

        bool placed = false;

        for(int i = 0; i < num_scores; i++)
        {
            if(GameManager.GetTotalScore() > (int.Parse(HighScores[i,1])) && placed == false)
            {
                newHighScores[i, 0] = GameManager.playerName;
                newHighScores[i, 1] = GameManager.GetTotalScore().ToString();
                placed = true;
            }
            else if(placed == true)
            {
                newHighScores[i, 0] = HighScores[i - 1, 0];
                newHighScores[i, 1] = HighScores[i - 1, 1];
            }
            else
            {
                newHighScores[i, 0] = HighScores[i, 0];
                newHighScores[i, 1] = HighScores[i, 1];
            }
        }

        StreamWriter write = new StreamWriter(path);
        for(int j = 0; j < num_scores; j++)
        {
            write.WriteLine(newHighScores[j, 0] + "," + newHighScores[j, 1]);
        }

        write.Close();
    }
}
