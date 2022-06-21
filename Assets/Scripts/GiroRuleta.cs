using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Premios
{
    public string nombre;
    public int cantidad;
}

public class GiroRuleta : MonoBehaviour
{
    public enum Estado {Esperando, Quieto, GiroHorario, GiroAntiHorario}
    public Estado estado;

    Premios[] premios;

    public GuizmoMovements speed;
    
    public float fuerza;
    public Vector3 sentido;
    public Vector3 menos = new Vector3(0, 1, 0);
    private Rigidbody m_Rigidbody;
    bool girando = false;
    Quaternion deltaRotation;

    private float velocidadAngular;
    [Range(0,1)]
    [SerializeField] private float rozamiento;
    [Range(0, 500)]
    [SerializeField] private float multiplicador; 

    // Start is called before the first frame update
    void Start()
    {
        estado = Estado.Esperando;
        m_Rigidbody = GetComponent<Rigidbody>();

        velocidadAngular = 0;
    }

    void Update()
    {
        switch (estado)
        {
            case Estado.Esperando:
                speed = FindObjectOfType<GuizmoMovements>();
                fuerza = speed.mFuerza;

                if(Mathf.Abs(fuerza) > 0)
                {
                    velocidadAngular = Mathf.Abs(fuerza) * multiplicador;
                    StartCoroutine(Frenar());
                    estado = Estado.Quieto;
                }

                break;

            case Estado.Quieto:

                if (velocidadAngular > 0)
                {
                    sentido = new Vector3(0, velocidadAngular, 0);
                    deltaRotation = Quaternion.Euler(sentido * Time.fixedDeltaTime);

                    m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);

                    print(velocidadAngular);
                }

                break;
            
            case Estado.GiroHorario:

                break;

            case Estado.GiroAntiHorario:

                break;
        }
    }

    IEnumerator Frenar()
    {
        do
        {
            velocidadAngular -= rozamiento;
            yield return new WaitForSeconds(0.025f);
        } while (velocidadAngular >= 0);
    }
}

