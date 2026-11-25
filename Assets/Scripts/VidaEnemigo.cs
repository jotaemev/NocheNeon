using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    public int vida = 30;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BalaPlayer"))
        {
            Destroy(other.gameObject);
            vida -= 10;
            if (vida <= 0) Destroy(gameObject);
        }
    }
}