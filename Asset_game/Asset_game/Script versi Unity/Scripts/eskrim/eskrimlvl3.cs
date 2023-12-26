using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eskrimlvl3 : MonoBehaviour
{
    [SerializeField] private AudioClip eskrimupsound;
    public static event Action OnCollected3;
    [SerializeField] public static int total; // Ubah aksesibilitas menjadi public

    void Awake()
    {
        total = 10;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundManager.instance.PlaySound(eskrimupsound);
            OnCollected3?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
