# Geotris — Guía de cambios y de build en la nube

Este documento resume **qué se agregó/mejoró** y los **pasos que tenés que hacer vos**
(una sola vez) para poder jugar el juego desde un link, sin instalar Unity.

---

## ✅ Qué se hizo (ya está en el proyecto)

### 1. Niveles: de 10 a 20
- Se crearon `LevelStats11` … `LevelStats20` (en `Assets/ScriptableObjects/`) con una
  curva de dificultad progresiva (más piezas, más velocidad, más puntaje objetivo).
- Se agregaron al `GameManager` de la escena `MainMenu` (array `levelStats`).
- Se corrigió la lógica hardcodeada que asumía 10 niveles y un bug que rompía el juego
  al terminar (índice fuera de rango). Ahora funciona para cualquier cantidad de niveles.

### 2. Sistema de publicidad (Unity Ads) — modo TEST
- Nuevo script `Assets/Scripts/AdsManager.cs`. Se **crea solo** al iniciar el juego
  (no hay que configurarlo en ninguna escena).
- Muestra un anuncio **intersticial** cuando perdés (Game Over) y al terminar los 20 niveles.
- Arranca en **modo test** (anuncios de prueba, no generan dinero). Para monetizar de verdad:
  abrí `AdsManager.cs` y reemplazá `androidGameId` / `iosGameId` por tu **Game ID** del
  panel de Unity (https://dashboard.unity3d.com) y poné `testMode = false`.
- En WebGL/PC los ads no se muestran (no hay soporte) y el juego funciona igual.

### 3. Mejoras de interfaz (sin tocar las escenas, por código)
- `UIEnhancer.cs`: recorre **todos los botones** de cada escena y les agrega animación de
  presionado/hover y transiciones de color más suaves.
- `ButtonJuice.cs`: la animación individual de cada botón.
- El **marcador** ahora "late" (efecto punch) cada vez que sumás puntos.

### 4. Ajuste para WebGL
- Se cambió la compresión de WebGL a *Disabled* para que cargue bien en GitHub Pages.

---

## 🎮 Cómo lograr que puedas PROBAR el juego (pasos tuyos)

El juego se compila **en la nube** con GitHub Actions y se publica en **GitHub Pages**.
Hacé esto una sola vez:

### Paso 1 — Subir los cambios a GitHub
```bash
cd GeotrisTheGame
git push origin main
```
> Si te pide usuario/contraseña, usá tu usuario de GitHub y un **token** (no la clave).

### Paso 2 — Conseguir la licencia gratuita de Unity
1. En GitHub, andá a la pestaña **Actions** del repo.
2. Ejecutá el workflow **"1) Obtener archivo de activacion de Unity"** (botón *Run workflow*).
3. Cuando termine, entrá al run y **descargá el artifact** `Manual Activation File` (es un `.alf`).
4. Andá a **https://license.unity3d.com/manual**, subí el `.alf`, elegí **Unity Personal**
   (licencia gratuita) y descargá el archivo **`.ulf`** que te genera.
5. Abrí ese `.ulf` con un editor de texto y copiá **todo** su contenido.

### Paso 3 — Cargar el secret en GitHub
1. En el repo: **Settings → Secrets and variables → Actions → New repository secret**.
2. Nombre: `UNITY_LICENSE`
3. Valor: pegá **todo** el contenido del archivo `.ulf`.
4. Guardá.

### Paso 4 — Activar GitHub Pages
1. En el repo: **Settings → Pages**.
2. En **Source** elegí **GitHub Actions**.

### Paso 5 — Compilar y jugar
1. Andá a **Actions → "Build & Deploy (WebGL)" → Run workflow** (o hacé cualquier push).
2. Cuando termine (tarda unos minutos la primera vez), el link para jugar aparece en:
   - el job **Deploy** (campo *url*), o
   - **Settings → Pages** (arriba dice "Your site is live at …").
3. Abrís ese link en el navegador y **jugás con el mouse** (click en las piezas). 🎉

---

## 💰 Cuando quieras ganar dinero real con los ads
1. Creá tu juego en https://dashboard.unity3d.com (Unity Ads / LevelPlay).
2. Copiá el **Game ID** de Android (y el de iOS si aplica).
3. En `Assets/Scripts/AdsManager.cs` reemplazá `androidGameId` / `iosGameId` y poné
   `testMode = false`.
4. Los ads reales solo se muestran en builds de **Android/iOS**, no en WebGL.

---

## ℹ️ Notas
- La primera compilación es la más lenta (descarga el editor de Unity). Las siguientes
  usan caché y son más rápidas.
- Si querés además un **APK para el celular**, se puede agregar otro workflow de build
  para Android (avisame y lo dejo listo).
