using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Le da "vida" a un botón: se agranda un poco al pasar el puntero/dedo y se
/// achica al presionar, con una animación suave. Se agrega automáticamente a
/// todos los botones desde UIEnhancer, así que no hay que configurar nada en las escenas.
/// </summary>
[DisallowMultipleComponent]
public class ButtonJuice : MonoBehaviour,
    IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    private const float hoverScale = 1.06f;
    private const float pressScale = 0.92f;
    private const float speed      = 14f;

    private Vector3 baseScale = Vector3.one;
    private Vector3 targetScale = Vector3.one;
    private bool initialized;
    private bool pointerInside;

    private void CaptureBase()
    {
        if (initialized) return;
        Vector3 s = transform.localScale;
        baseScale = (s == Vector3.zero) ? Vector3.one : s;
        targetScale = baseScale;
        initialized = true;
    }

    private void Awake()   { CaptureBase(); }
    private void OnEnable() { CaptureBase(); targetScale = baseScale; }

    private void Update()
    {
        // unscaledDeltaTime para que funcione aunque el juego esté en pausa.
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.unscaledDeltaTime * speed);
    }

    public void OnPointerEnter(PointerEventData e) { pointerInside = true;  targetScale = baseScale * hoverScale; }
    public void OnPointerExit(PointerEventData e)  { pointerInside = false; targetScale = baseScale; }
    public void OnPointerDown(PointerEventData e)  { targetScale = baseScale * pressScale; }
    public void OnPointerUp(PointerEventData e)    { targetScale = pointerInside ? baseScale * hoverScale : baseScale; }
}
