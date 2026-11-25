using UnityEngine;

public class BalaEnemiga : MonoBehaviour
{
    public int danio = 10;

    void Start() { Destroy(gameObject, 4f); }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<VidaPlayer>().RecibirDanio(danio);
            Destroy(gameObject);
        }
    }
}