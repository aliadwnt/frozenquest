using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finishvl2 : MonoBehaviour
{
    private bool levelCompleted = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            coun2 countScript = FindObjectOfType<coun2>();
            if (countScript != null && countScript.Counter == eskrimlvl2.total)
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
