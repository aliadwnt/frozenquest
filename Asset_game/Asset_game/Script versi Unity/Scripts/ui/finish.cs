using UnityEngine;
using UnityEngine.SceneManagement;

public class finish : MonoBehaviour
{
    private bool levelCompleted = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            count countScript = FindObjectOfType<count>();
            if (countScript != null && countScript.Counter == EskrimCollectible.total)
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
