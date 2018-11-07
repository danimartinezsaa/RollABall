using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControladorJugador : MonoBehaviour {

    private Rigidbody rb;
    public float velocidad;
    private int contador;
    public Text textocontador,textovictoria;
    private float tiempoMenu = 0.0f;
    public Text texto;
    public float tiempo = 0.0f;

    void Start()
    {
        contador = 0;
        rb = GetComponent<Rigidbody>();
        textovictoria.text = "";
        SetTextoContador();
    }

    void FixedUpdate()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoHorizontal, 0.0f, movimientoVertical);

        rb.AddForce(movimiento*velocidad);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coger"))
        {
            other.gameObject.SetActive(false);
            contador++;
            SetTextoContador();

            if (contador >= 12)
            {
                textovictoria.text = "Ganaste!";
            }
        }
    }

    private void Update()
    {
        if (contador >= 12)
        {
            tiempoMenu = tiempoMenu + Time.deltaTime;

            if (tiempoMenu >= 5.0f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
        }

        if (contador < 12)
        {
            tiempo = tiempo + Time.deltaTime;
            texto.text = "Tiempo: " + tiempo.ToString("f0") + " segundos";
        }

    }
    void SetTextoContador()
    {
        textocontador.text = "Marcador: " + contador;
    }
}
