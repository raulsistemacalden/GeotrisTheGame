using UnityEngine;
using UnityEngine.Advertisements;

/// <summary>
/// Sistema de publicidad con Unity Ads.
///
/// - Se crea a sí mismo automáticamente al iniciar el juego (RuntimeInitializeOnLoadMethod),
///   así NO hace falta arrastrarlo a ninguna escena.
/// - Arranca en MODO TEST: se ven anuncios de prueba, no generan dinero real.
/// - Para monetizar de verdad: reemplazá androidGameId / iosGameId por el Game ID
///   de tu panel de Unity (https://dashboard.unity3d.com) y poné testMode = false.
/// - En plataformas sin soporte (WebGL, PC), no muestra nada y no rompe el juego.
/// </summary>
public class AdsManager : MonoBehaviour
{
    public static AdsManager _instance;

    // === CONFIGURACIÓN ===
    // Reemplazá estos IDs por los tuyos del panel de Unity Ads para ganar dinero real.
    private const string androidGameId = "0000000";
    private const string iosGameId     = "0000000";
    private const bool   testMode      = true;

    // Placements (dejá estos por defecto; se ajustan solos si no existen).
    private const string interstitialPlacement = "Interstitial_Android";
    private const string rewardedPlacement     = "Rewarded_Android";

    /// <summary>Se ejecuta automáticamente antes de cargar la primera escena.</summary>
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Bootstrap()
    {
        if (_instance == null)
        {
            GameObject go = new GameObject("AdsManager");
            go.AddComponent<AdsManager>();
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
        InitializeAds();
    }

    private void InitializeAds()
    {
        try
        {
            if (!Advertisement.isSupported)
                return; // p.ej. WebGL o Editor sin soporte: no hace nada.

            string gameId = androidGameId;
#if UNITY_IOS
            gameId = iosGameId;
#endif
            if (!Advertisement.isInitialized)
                Advertisement.Initialize(gameId, testMode);
        }
        catch (System.Exception e)
        {
            Debug.LogWarning("[AdsManager] No se pudo inicializar Unity Ads: " + e.Message);
        }
    }

    /// <summary>Muestra un anuncio intersticial (pantalla completa) si hay uno listo.</summary>
    public void ShowInterstitial()
    {
        try
        {
            if (!Advertisement.isSupported || !Advertisement.isInitialized)
                return;

            if (Advertisement.IsReady(interstitialPlacement))
                Advertisement.Show(interstitialPlacement);
            else if (Advertisement.IsReady())
                Advertisement.Show();
        }
        catch (System.Exception e)
        {
            Debug.LogWarning("[AdsManager] No se pudo mostrar el intersticial: " + e.Message);
        }
    }

    /// <summary>Muestra un anuncio recompensado si hay uno listo.</summary>
    public void ShowRewarded()
    {
        try
        {
            if (!Advertisement.isSupported || !Advertisement.isInitialized)
                return;

            if (Advertisement.IsReady(rewardedPlacement))
                Advertisement.Show(rewardedPlacement);
            else if (Advertisement.IsReady())
                Advertisement.Show();
        }
        catch (System.Exception e)
        {
            Debug.LogWarning("[AdsManager] No se pudo mostrar el recompensado: " + e.Message);
        }
    }
}
