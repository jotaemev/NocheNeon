using UnityEngine;

public class ZonaBoss : MonoBehaviour
{
    public Boss boss;
    public MonoBehaviour camara;   // el script que sigue al Player
    public Respawn respawn;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        boss.Activar();
        if (camara != null) camara.enabled = false;   // la cámara se queda fija
        if (respawn != null) respawn.CancelInvoke();  // se acaba el respawn normal
        Destroy(gameObject);
    }
}