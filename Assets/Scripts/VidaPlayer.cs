using UnityEngine;
using UnityEngine.UI;

public class VidaPlayer : MonoBehaviour
{
    public int vidaMaxima = 100;
    public Slider barraVida;
    private int vida;

    void Start()
    {
        vida = vidaMaxima;
        ActualizarBarra();
    }

    void Update()
    {
        
    }

    public void RecibirDanio(int cantidad)
    {
        if (GameController.instance.juegoTerminado) return;
        vida = Mathf.Max(vida - cantidad, 0);
        ActualizarBarra();
        if (vida <= 0)
        {
            GameController.instance.GameOver();
            gameObject.SetActive(false);
        }
    }

    public void Curar(int cantidad)   // lo usarán las recargas
    {
        vida = Mathf.Min(vida + cantidad, vidaMaxima);
        ActualizarBarra();
    }

    void ActualizarBarra() { barraVida.value = vida; }
}
