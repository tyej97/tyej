using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WordDisplay : MonoBehaviour
{

	public Text text;
	public static float fallSpeed = 1f;

	public void SetWord (string word)
	{
		text.text = word;
	}

	public void RemoveLetter ()
	{
		text.text = text.text.Remove(0, 1);
		text.color = Color.red;
	}

	public void RemoveWord ()
	{
		Destroy(gameObject);
	}

	private void Update()
	{
		transform.Translate(0f, -fallSpeed * Time.deltaTime, 0f);
        if (transform.position.y < -5)
        {
            SceneManager.LoadScene("Assets/Menu.unity", LoadSceneMode.Single);
        }
            
	}

    public static void SetFallSpeed()
    {
        switch(GameManager.gameSetting)
        {
            case 3: fallSpeed = 0.5f;
                break;
            case 4: fallSpeed = 0.1f;
                break;
        }
    }
}
