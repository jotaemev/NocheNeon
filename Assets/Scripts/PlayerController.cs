using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidad = 6f;
    public float fuerzaSalto = 7f;
    private Rigidbody rb;
    private float movimientoH;
    private bool tocoSuelo;

    void Start() { rb = GetComponent<Rigidbody>(); }

    void Update()
    {
        movimientoH = Input.GetAxis("Horizontal");
        tocoSuelo = Physics.Raycast(transform.position, Vector3.down, 0.6f);
        if (Input.GetKeyDown(KeyCode.Space) && tocoSuelo)
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, fuerzaSalto, 0);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(movimientoH * velocidad, rb.linearVelocity.y, 0);
    }
}