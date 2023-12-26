using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coun3 : MonoBehaviour
{
    TMPro.TMP_Text text;
    int counter;

    public int Counter // Properti untuk mengakses nilai counter
    {
        get { return counter; }
    }

    private void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();
    }

    void Start() => UpdateCount();

    void OnEnable()
    {
        //EskrimCollectible.OnCollected += OnCollectibleCollected;
        //eskrimlvl2.OnCollected2 += OnCollectibleCollected;
        eskrimlvl3.OnCollected3 += OnCollectibleCollected;
    }

    void OnDisable()
    {
        //EskrimCollectible.OnCollected -= OnCollectibleCollected;
        //eskrimlvl2.OnCollected2 -= OnCollectibleCollected;
        eskrimlvl3.OnCollected3 -= OnCollectibleCollected;

    }



    void OnCollectibleCollected()
    {
        counter++;
        UpdateCount();
    }

    void UpdateCount()
    {
        //text.text = $"{counter} / {EskrimCollectible.total}";
        //text.text = $"{counter} / {eskrimlvl2.total}";
        text.text = $"{counter} / {eskrimlvl3.total}";
    }
}
