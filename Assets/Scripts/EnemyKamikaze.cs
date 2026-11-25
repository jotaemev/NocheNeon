using UnityEngine;

public class EnemyKamikaze : MonoBehaviour
{
    public float velocidad = 4f;
    public float rango = 10f;
    private Rigidbody rb;
    private Transform jugador;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameObject p = GameObject.FindWithTag("Player");
        if (p != null) jugador = p.transform;
    }

    void FixedUpdate()
    {
        float vy = rb.linearVelocity.y;
        if (jugador == null || !jugador.gameObject.activeInHierarchy)
        {
            rb.linearVelocity = new Vector3(0, vy, 0);
            return;
        }
        float dx = jugador.position.x - transform.position.x;
        if (Mathf.Abs(dx) > rango) rb.linearVelocity = new Vector3(0, vy, 0);
        else rb.linearVelocity = new Vector3(Mathf.Sign(dx) * velocidad, vy, 0);
    }
}