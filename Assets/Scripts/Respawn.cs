using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject[] enemigos;   // los prefabs Enemy1 y Enemy2
    public Transform[] puntos;      // los SpawnPoint
    public Transform padre;         // el objeto vacío Enemigos
    public float intervalo = 3f;
    public int maximo = 4;

    void Start()
    {
        InvokeRepeating(nameof(Crear), 2f, intervalo);
    }

    void Crear()
    {
        if (GameController.instance.juegoTerminado)
        {
            CancelInvoke();
            return;
        }
        if (GameObject.FindGameObjectsWithTag("Enemigo").Length >= maximo) return;

        Transform punto = puntos[Random.Range(0, puntos.Length)];
        GameObject prefab = enemigos[Random.Range(0, enemigos.Length)];
        Instantiate(prefab, punto.position, Quaternion.identity, padre);
    }
}