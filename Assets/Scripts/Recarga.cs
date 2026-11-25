using UnityEngine;

public class Recarga : MonoBehaviour
{
    public enum Tipo { Vida, Municion }
    public Tipo tipo = Tipo.Vida;
    public int cantidad = 25;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (tipo == Tipo.Vida) other.GetComponent<VidaPlayer>().Curar(cantidad);
        else other.GetComponent<Disparo>().Recargar(cantidad);
        gameObject.SetActive(false);
    }
}