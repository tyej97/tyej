using UnityEngine;
using UnityEngine.SceneManagement;

public class Frog : MonoBehaviour {

	public Rigidbody2D rb;

    private void Start()
    {
        
    }

    void Update () {

		if (Input.GetKeyDown(KeyCode.RightArrow) && gameObject.transform.position.x < 7)
			rb.MovePosition(rb.position + Vector2.right);
		else if (Input.GetKeyDown(KeyCode.LeftArrow) && gameObject.transform.position.x > -7)
			rb.MovePosition(rb.position + Vector2.left);
		else if (Input.GetKeyDown(KeyCode.UpArrow))
			rb.MovePosition(rb.position + Vector2.up);
		else if (Input.GetKeyDown(KeyCode.DownArrow) && gameObject.transform.position.y > -4)
			rb.MovePosition(rb.position + Vector2.down);

	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Car")
		{
			Debug.Log("WE LOST!");
			Score.CurrentScore = 0;
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
