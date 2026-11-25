using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public GameObject jugador;
    private Vector3 offset;

    void Start() { offset = transform.position - jugador.transform.position; }

    void LateUpdate()
    {
        transform.position = new Vector3(
            jugador.transform.position.x + offset.x,
            transform.position.y,
            transform.position.z);
    }
}