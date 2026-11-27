using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public int vida = 200;
    public Slider barraBoss;
    public GameObject prefabBala;
    public GameObject prefabDron;
    public float velocidadBala = 10f;
    public float cadencia = 1.5f;

    private int vidaMaxima;
    private bool segundaFase;
    private bool activo;
    private Transform jugador;
    public Light luzBoss;   // junto a las demás variables públicas

    void Start()
    {
        vidaMaxima = vida;
        GameObject p = GameObject.FindWithTag("Player");
        if (p != null) jugador = p.transform;
        if (barraBoss != null)
        {
            barraBoss.maxValue = vidaMaxima;
            barraBoss.value = vida;
            barraBoss.gameObject.SetActive(false);
        }
    }

    public void Activar()
    {
        if (activo) return;
        activo = true;
        if (barraBoss != null) barraBoss.gameObject.SetActive(true);
        if (luzBoss != null) luzBoss.gameObject.SetActive(true);
        InvokeRepeating(nameof(Disparar), 1f, cadencia);
    }

    void Disparar()
    {
        if (jugador == null || !jugador.gameObject.activeInHierarchy) return;
        Vector3 dir = jugador.position - transform.position;
        dir.z = 0;
        dir.Normalize();

        if (!segundaFase) Lanzar(dir);
        else
        {
            Lanzar(Quaternion.Euler(0, 0, -15) * dir);
            Lanzar(dir);
            Lanzar(Quaternion.Euler(0, 0, 15) * dir);
        }
    }

    void Lanzar(Vector3 dir)
    {
        GameObject bala = Instantiate(prefabBala, transform.position + dir * 2f, Quaternion.identity);
        bala.GetComponent<Rigidbody>().linearVelocity = dir * velocidadBala;
    }

    void LlamarDron()
    {
        if (prefabDron == null || GameController.instance.juegoTerminado) return;
        Instantiate(prefabDron, transform.position + Vector3.left * 3f, Quaternion.identity);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!activo || !other.CompareTag("BalaPlayer")) return;
        Destroy(other.gameObject);
        vida -= 10;
        if (barraBoss != null) barraBoss.value = vida;

        if (!segundaFase && vida <= vidaMaxima / 2) EntrarSegundaFase();
        if (vida <= 0) Morir();
    }

    void EntrarSegundaFase()
    {
        segundaFase = true;
        CancelInvoke(nameof(Disparar));
        InvokeRepeating(nameof(Disparar), 0.5f, 1f);
        InvokeRepeating(nameof(LlamarDron), 2f, 8f);
        GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(1f, 0.17f, 0.84f) * 3.5f);
    }

    void Morir()
    {
        CancelInvoke();
        GameController.instance.Victoria();
        Destroy(gameObject);
    }
}