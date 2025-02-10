using UnityEngine;

public class ParticleTrigger : MonoBehaviour
{
    [SerializeField] ParticleSystem particleSystem;  // Referencia al sistema de part�culas
    public float newSpeed = 5f; // Nueva velocidad de las part�culas

    void Start()
    {
        var main = particleSystem.main;  // Obtener el m�dulo Main
        main.startSpeed = newSpeed;      // Cambiar la velocidad de emisi�n
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegurar que es el personaje
        {
            particleSystem.Play(); // Activar part�culas
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            particleSystem.Stop(); // Detener part�culas
        }
    }
}
