using UnityEngine;
using UnityEngine.SceneManagement;

public class Meta : MonoBehaviour
{
    public string siguienteEscena = "Nivel2";

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            SceneManager.LoadScene(siguienteEscena);
    }
}