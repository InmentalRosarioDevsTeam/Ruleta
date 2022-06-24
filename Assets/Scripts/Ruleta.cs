using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Premios
{
    public string nombre;
    public int cantidad;
}

public class Ruleta : MonoBehaviour
{
    public enum Estado { Esperando, Girando } // por el momento no se usan
    public Estado estado;

    Premios[] premios; // todavia no esta en uso

    [Range(0, 1)] // dejar en 0,5 en el inspector
    [SerializeField] private float rozamiento;
    [SerializeField] private float fuerzaInicial;
    [SerializeField] private TMPro.TextMeshProUGUI premioGanador;
    private float velocidadAngular;
    private bool girando = false;
    private int premio;

    private Vector3 sentido;
    private Rigidbody m_Rigidbody;
    Quaternion deltaRotation;


    void Start()
    {
        estado = Estado.Esperando;
        m_Rigidbody = GetComponent<Rigidbody>();
        velocidadAngular = 0;
    }

    public void Girar(int x)
    {
        premio = x;

        if (!girando)
        {
            VerPremio(premio);

            girando = true;
        }
    }

    public void GirarRandom()
    {
        premio = Random.Range(0, 12);

        if (!girando)
        {
            VerPremio(premio);

            girando = true;
        }
    }

    void VerPremio(int x)
    {
        switch (x)
        {
            case 0: velocidadAngular = 401.5f; break;
            case 1: velocidadAngular = 403.0f; break;
            case 2: velocidadAngular = 405.0f; break;
            case 3: velocidadAngular = 407.0f; break;
            case 4: velocidadAngular = 408.5f; break;
            case 5: velocidadAngular = 410.5f; break;
            case 6: velocidadAngular = 412.5f; break;
            case 7: velocidadAngular = 414.0f; break;
            case 8: velocidadAngular = 415.5f; break;
            case 9: velocidadAngular = 417.6f; break;
            case 10: velocidadAngular = 419.5f; break;
            case 11: velocidadAngular = 421.5f; break;
        }

        premioGanador.text = "Premio: " + x.ToString();
    }

    public void Reiniciar()
    {
        girando = false;
        estado = Estado.Esperando;
        gameObject.GetComponent<RectTransform>().rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    void FixedUpdate()
    {
        if (girando)
        {
            //determina el sentido del giro
            sentido = new Vector3(0, 0, velocidadAngular);

            //determina la velocidad angular
            deltaRotation = Quaternion.Euler(sentido * Time.fixedDeltaTime);

            //Gira
            m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);

            // va perdiendo velocidad
            velocidadAngular -= rozamiento;

            // si llega a 0 se indica que freno
            if (velocidadAngular <= 0) girando = false;
        }
        else
        {

        }

    }
}