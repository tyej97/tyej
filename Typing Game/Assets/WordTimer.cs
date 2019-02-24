using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordTimer : MonoBehaviour {

	public WordManager wordManager;

	public static float wordDelay = 1.5f;
	private float nextWordTime = 0f;

	private void Update()
	{
		if (Time.time >= nextWordTime)
		{
			wordManager.AddWord();
			nextWordTime = Time.time + wordDelay;
			wordDelay *= .99f;
		}
	}

    public static void ChangeTimerTime()
    {
        switch(GameManager.gameSetting)
        {
            case 1: wordDelay = 2f;
                break;
            case 2:
                wordDelay = 5f;
                break;
            case 3:
                wordDelay = 10f;
                break;
            case 4:
                wordDelay = 20f;
                break;
        }
    }

}
