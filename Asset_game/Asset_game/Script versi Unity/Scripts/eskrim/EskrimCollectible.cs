using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EskrimCollectible : MonoBehaviour
{
    [SerializeField] private AudioClip eskrimupsound;
    public static event Action OnCollected;
    public static int total; // Ubah aksesibilitas menjadi public

    void Awake()
    {
        total = 5;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundManager.instance.PlaySound(eskrimupsound);
            OnCollected?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
