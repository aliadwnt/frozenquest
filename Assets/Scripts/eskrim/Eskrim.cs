using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Eskrim : MonoBehaviour
{
    [Header("Eskrim")]
    [SerializeField] private float startingEskrim;
    private Animator anim;
    private SpriteRenderer spriteRend;
    public float currentEskrim { get; private set; }

    private void Awake()
    {
        currentEskrim = startingEskrim;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void AddEskrim(float _value)
    {
        currentEskrim = Mathf.Clamp(currentEskrim + _value, 0, startingEskrim);
    }
}
