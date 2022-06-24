using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public static class SoundManager
{
    public static void CrearSonido(AudioClip clip, Vector3 posicion)
    {
        GameObject sonido = new GameObject("Sonido");
        AudioSource audioSource = sonido.AddComponent<AudioSource>();
        sonido.transform.position = posicion;
        audioSource.clip = clip;
        audioSource.pitch = 0.5f;
        audioSource.volume = 0.5f;
        audioSource.Play();
        sonido.AddComponent<DestroySound>();
    }
}