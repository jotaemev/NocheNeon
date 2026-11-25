using UnityEngine;

public class DanioContacto : MonoBehaviour
{
    public int danio = 20;
    public bool destruirAlTocar = false;

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            c.gameObject.GetComponent<VidaPlayer>().RecibirDanio(danio);
            if (destruirAlTocar) Destroy(gameObject);
        }
    }
}