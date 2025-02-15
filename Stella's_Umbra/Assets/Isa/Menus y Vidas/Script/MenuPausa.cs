using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject menuPausa;
    [SerializeField] private GameObject menuVidas;

    private bool juegoPausado = false;

    [SerializeField] private InputActionAsset _pInput;

    public void EnableControls()
    {
        _pInput.Enable();
    }

    public void DisableControls()
    {
        _pInput.Disable();
    }


    private void Start()
    {
        menuPausa.SetActive(false);
        menuVidas.SetActive(true);
        _pInput.Enable();

        Time.timeScale = 1f;
    }
    private void Update()
    {
        if (UnityEngine.Input.GetKeyUp(KeyCode.Escape)) 
        { 
            if (juegoPausado)
            {
                Reanudar();
            }
            else
            {
                Pausa();
            }
        }
    }

    public void Pausa()
    {
        juegoPausado = true;
        Time.timeScale = 0f;
        menuPausa.SetActive(true);
        menuVidas.SetActive(false);
        _pInput.Disable();
    }
    public void Reanudar()
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        menuPausa.SetActive(false);
        menuVidas.SetActive(true);
        _pInput.Enable();

    }
}
