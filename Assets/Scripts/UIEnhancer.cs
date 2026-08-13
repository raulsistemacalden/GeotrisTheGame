using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Mejora la interfaz de todo el juego SIN tocar las escenas.
/// Se crea solo al iniciar y, cada vez que se carga una escena, recorre todos
/// los botones y les agrega animación de presionado/hover y transiciones de
/// color más suaves. Mejor feedback y sensación general, cero configuración.
/// </summary>
public class UIEnhancer : MonoBehaviour
{
    public static UIEnhancer _instance;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Bootstrap()
    {
        if (_instance == null)
        {
            GameObject go = new GameObject("UIEnhancer");
            go.AddComponent<UIEnhancer>();
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
        Enhance();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Enhance();
    }

    private void Enhance()
    {
        // Incluye objetos inactivos (p. ej. botones del panel de Game Over).
        Button[] buttons = Resources.FindObjectsOfTypeAll<Button>();
        foreach (Button b in buttons)
        {
            if (b == null) continue;
            // Ignorar prefabs/assets: solo objetos que están en una escena real.
            if (!b.gameObject.scene.IsValid()) continue;

            if (b.GetComponent<ButtonJuice>() == null)
                b.gameObject.AddComponent<ButtonJuice>();

            // Transición de color un poco más suave al interactuar.
            ColorBlock cb = b.colors;
            cb.fadeDuration = 0.12f;
            if (cb.highlightedColor == cb.normalColor)
                cb.highlightedColor = cb.normalColor * 1.08f;
            b.colors = cb;
        }
    }
}
