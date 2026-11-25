using UnityEngine;
using TMPro;

public class Disparo : MonoBehaviour
{
    public GameObject prefabBala;
    public float velocidadBala = 15f;
    public int municionMaxima = 30;
    public int municion = 20;
    public TMP_Text textoMunicion;
    private float direccion = 1f;

    void Start() { ActualizarTexto(); }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if (h > 0) direccion = 1f;
        else if (h < 0) direccion = -1f;

        if (Input.GetKeyDown(KeyCode.J)) Disparar();
    }

    public void Disparar()
    {
        if (municion <= 0) return;
        Vector3 pos = transform.position + new Vector3(direccion * 0.8f, 0, 0);
        GameObject bala = Instantiate(prefabBala, pos, Quaternion.identity);
        bala.GetComponent<Rigidbody>().linearVelocity = new Vector3(direccion * velocidadBala, 0, 0);
        municion--;
        ActualizarTexto();
    }

    public void Recargar(int cantidad)   // lo usarán las recargas
    {
        municion = Mathf.Min(municion + cantidad, municionMaxima);
        ActualizarTexto();
    }

    void ActualizarTexto() { textoMunicion.text = municion + " / " + municionMaxima; }
}
