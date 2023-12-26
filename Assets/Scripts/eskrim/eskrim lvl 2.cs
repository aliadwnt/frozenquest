using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class eskrimlvl2 : MonoBehaviour
{
    [SerializeField] private AudioClip eskrimupsound;
    public static event Action OnCollected2;
    [SerializeField] public static int total; // Ubah aksesibilitas menjadi public

    void Awake()
    {
        total = 7;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundManager.instance.PlaySound(eskrimupsound);
            OnCollected2?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
