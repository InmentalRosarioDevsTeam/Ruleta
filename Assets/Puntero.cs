using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntero : MonoBehaviour
{
    public AudioClip clip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Barra")
        {
            SoundManager.CrearSonido(clip, transform.position);
        }
    }
}
