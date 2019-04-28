using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool isInvisible = false;
    public static int fruitSize = 0;
    public static int score = 0;
    public static int missed = 0;
    public static string playerName = "Not Entered";

    public Dropdown fruitSizeDropdown;
    public Text ScoreBox;
    public Toggle checkbox;
    public InputField nameField;
    void Start()
    {
        if (isInvisible == true)
        {
            ScoreBox.color = new Color(24f,71f,96f,0f);
        }
    }

    public void ToHighScoreScene()
    {
        SceneManager.LoadScene(1);
    }

    public void ToMainScene()
    {
        SceneManager.LoadScene(2);
    }

    public void ToEndScoreScene()
    {
        ReadScores.WriteScore();
        SceneManager.LoadScene(3);
    }

    public void StartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void SetFruitSize()
    {
        fruitSize = fruitSizeDropdown.value;
    }

    public void SetIsInvisible()
    {
        isInvisible = checkbox.isOn;
    }

    static public void  IncreaseScore()
    {
        score++;
    }

    static public void IncreaseMissed()
    {
        missed++;
    }

    static public void DecreaseMissed()
    {
        missed--;
    }

    static public int GetTotalScore()
    {
        return score - missed;
    }

    public void SetPlayerName()
    {
        playerName = nameField.text;
    }
}
