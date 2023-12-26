
using UnityEngine;
using UnityEngine.SceneManagement;

public class finishlvl3 : MonoBehaviour
{
    private bool levelCompleted = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            coun3 countScript = FindObjectOfType<coun3>();
            if (countScript != null && countScript.Counter == eskrimlvl3.total)
            {
                levelCompleted = true;
                Invoke("CompleteLevel", 2f);
            }
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
