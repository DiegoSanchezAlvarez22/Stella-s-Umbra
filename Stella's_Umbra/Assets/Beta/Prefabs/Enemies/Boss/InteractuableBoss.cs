using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InteractuableBoss : MonoBehaviour
{
    private bool jugadorDentro = false;
    private PlayerInput playerInput;
    [SerializeField] BoxCollider interactuar;
    [SerializeField] BoxCollider hitBox;
    [SerializeField] Animator Boss;

    private void OnTriggerEnter(Collider interactuar)
    {
        if (interactuar.CompareTag("Player"))
        {
            jugadorDentro = true;
            playerInput = interactuar.GetComponent<PlayerInput>(); // Obtener PlayerInput del jugador

            if (playerInput != null)
            {
                playerInput.actions["Interact"].performed += Interactuar; // Suscribirse al evento
            }
        }
    }

    private void OnTriggerExit(Collider interactuar)
    {
        if (interactuar.CompareTag("Player"))
        {
            jugadorDentro = false;

            if (playerInput != null)
            {
                playerInput.actions["Interact"].performed -= Interactuar; // Desuscribirse del evento
                playerInput = null;
            }

            Debug.Log("Saliste de la zona de interacci�n.");
        }
    }

    private void Interactuar(InputAction.CallbackContext context)
    {
        if (jugadorDentro)
        {
            Debug.Log("Interacci�n realizada con el objeto.");
            // Aqu� puedes poner la l�gica de interacci�n (abrir puerta, recoger objeto, etc.)
            Boss.SetTrigger("Awake");
        }
    }
}
