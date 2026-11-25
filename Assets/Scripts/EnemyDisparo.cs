using UnityEngine;

public class EnemyDisparo : MonoBehaviour
{
    public GameObject prefabBala;
    public float velocidadBala = 10f;
    public float cadencia = 2f;
    public float rango = 15f;
    private Transform jugador;

    void Start()
    {
        GameObject p = GameObject.FindWithTag("Player");
        if (p != null) jugador = p.transform;
        InvokeRepeating(nameof(Disparar), 1f, cadencia);
    }

    void Disparar()
    {
        if (jugador == null || !jugador.gameObject.activeInHierarchy) return;
        Vector3 dir = jugador.position - transform.position;
        dir.z = 0;
        if (dir.magnitude > rango) return;
        dir.Normalize();
        GameObject bala = Instantiate(prefabBala, transform.position + dir * 0.8f, Quaternion.identity);
        bala.GetComponent<Rigidbody>().linearVelocity = dir * velocidadBala;
    }
}