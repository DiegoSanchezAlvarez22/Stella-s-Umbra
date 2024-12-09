using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca : MonoBehaviour
{
    [SerializeField] Animator palanca;
    [SerializeField] bool deactivable;
    private void Start()
    {
        palanca.SetBool("Activada", false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ataque")
        {
            if (!palanca.GetBool("Activada")) // Si est� desactivada, activa la palanca
            {
                palanca.SetBool("Activada", true);
                deactivable = true;
                Debug.Log("Palanca Activada");
            }
            else if (deactivable) // Si est� activada y es desactivable, desact�vala
            {
                palanca.SetBool("Activada", false);
                deactivable = false;
                Debug.Log("Palanca Desactivada");
            }
        }
    }
}

