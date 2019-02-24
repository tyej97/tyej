using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static int gameSetting;

    public void EasyMode()
    {
        WordGenerator.LoadWordArray(1);
        gameSetting = 1;
        WordTimer.ChangeTimerTime();
        SceneManager.LoadScene("Assets/Main.unity", LoadSceneMode.Single);
    }
    public void MediumMode()
    {
        WordGenerator.LoadWordArray(2);
        gameSetting = 2;
        WordTimer.ChangeTimerTime();
        SceneManager.LoadScene("Assets/Main.unity", LoadSceneMode.Single);
    }
    public void HardMode()
    {
        WordGenerator.LoadWordArray(3);
        gameSetting = 3;
        WordTimer.ChangeTimerTime();
        WordDisplay.SetFallSpeed();
        SceneManager.LoadScene("Assets/Main.unity", LoadSceneMode.Single);
    }
    public void UltimateMode()
    {
        WordGenerator.LoadWordArray(4);
        gameSetting = 4;
        WordTimer.ChangeTimerTime();
        WordDisplay.SetFallSpeed();
        SceneManager.LoadScene("Assets/Main.unity", LoadSceneMode.Single);
    }
}
