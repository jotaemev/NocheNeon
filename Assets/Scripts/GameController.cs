using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public bool juegoTerminado;

    void Awake() { instance = this; }

    public void GameOver()
    {
        if (juegoTerminado) return;
        juegoTerminado = true;
        Debug.Log("Game Over");   // en la sesión 3 aquí se activará el panel
    }

    public void Victoria()
    {
        if (juegoTerminado) return;
        juegoTerminado = true;
        Debug.Log("Victoria");   // en el apartado 11 se activará el panel
    }
}