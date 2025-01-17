using UnityEngine;
using UnityEngine.EventSystems;

public class MapaZoom : MonoBehaviour, IScrollHandler
{
<<<<<<< HEAD
    public RectTransform mapa; // El RectTransform del mapa
    public float zoomSpeed = 0.1f; // Velocidad de zoom
    public float minZoom = 0.5f; // Escala m�nima
    public float maxZoom = 2.0f; // Escala m�xima

    public void OnScroll(PointerEventData eventData)
    {
        // Calcula la nueva escala basada en la direcci�n del scroll
        float newScale = Mathf.Clamp(mapa.localScale.x + eventData.scrollDelta.y * zoomSpeed, minZoom, maxZoom);

        // Aplica la escala uniformemente en X e Y
        mapa.localScale = new Vector3(newScale, newScale, 1);
=======
    public RectTransform mapa; // RectTransform del mapa
    public RectTransform contenedor; // RectTransform del contenedor (con la m�scara)
    public float zoomSpeed = 0.1f; // Velocidad de zoom
    private float minZoom; // Escala m�nima (se definir� din�micamente)
    public float maxZoom = 2.0f; // Escala m�xima

    private void Start()
    {
        // Establece el m�nimo nivel de zoom como la escala inicial del mapa
        minZoom = mapa.localScale.x;
    }

    public void OnScroll(PointerEventData eventData)
    {
        // Calcula el nuevo tama�o de escala
        float newScale = Mathf.Clamp(mapa.localScale.x + eventData.scrollDelta.y * zoomSpeed, minZoom, maxZoom);
        mapa.localScale = new Vector3(newScale, newScale, 1);

        // Limita la posici�n del mapa dentro del contenedor
        LimitarPosicion();
    }

    private void LimitarPosicion()
    {
        // Obt�n los bordes del mapa y del contenedor en su espacio local
        Vector3[] contenedorCorners = new Vector3[4];
        Vector3[] mapaCorners = new Vector3[4];
        contenedor.GetWorldCorners(contenedorCorners);
        mapa.GetWorldCorners(mapaCorners);

        // Calcula los l�mites del contenedor en el espacio local del mapa
        Vector3 min = contenedor.InverseTransformPoint(contenedorCorners[0]);
        Vector3 max = contenedor.InverseTransformPoint(contenedorCorners[2]);

        // Aseg�rate de que los bordes del mapa no salgan del contenedor
        Vector3 mapaPos = mapa.localPosition;
        float mapaWidth = mapa.rect.width * mapa.localScale.x;
        float mapaHeight = mapa.rect.height * mapa.localScale.y;

        mapaPos.x = Mathf.Clamp(mapaPos.x, min.x - (mapaWidth / 2), max.x + (mapaWidth / 2));
        mapaPos.y = Mathf.Clamp(mapaPos.y, min.y - (mapaHeight / 2), max.y + (mapaHeight / 2));

        mapa.localPosition = mapaPos;
>>>>>>> 46d7437d5c1df3857f54f94aeb64ee4328e722ba
    }
}
