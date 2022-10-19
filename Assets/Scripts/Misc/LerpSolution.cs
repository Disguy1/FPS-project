using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;
using TMPro;

public class LerpSolution : MonoBehaviour
{
    #region Instance Instantiation
    public static LerpSolution instance = null;
    public static LerpSolution Instance
    {
        get
        {
            if (instance != null)
            {
                instance = FindObjectOfType<LerpSolution>();
                if (instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = "LerpSolution";
                    instance = go.AddComponent<LerpSolution>();
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        StopAllCoroutines();
    }

    public static void StopCoroutines()
    {
        if (instance != null)
        {
            instance.StopAllCoroutines();
        }
    }

    #endregion
    #region Methods
    public static void lerpVolume(AudioSource source, float targetVolume, float speed)
    {
        instance.StartCoroutine(instance.lerpVolumeEnum(source, targetVolume, speed));
    }

    public static void lerpVolume(AudioSource source, float targetVolume, float speed, float startVolume)
    {
        instance.StartCoroutine(instance.lerpVolumeEnum(source, targetVolume, speed, startVolume));
    }

    public static void lerpPitch(AudioSource source, float targetPitch, float speed)
    {
        instance.StartCoroutine(instance.lerpPitchEnum(source, targetPitch, speed));
    }

    public static void lerpPitch(AudioSource source, float targetPitch, float speed, float startPitch)
    {
        instance.StartCoroutine(instance.lerpPitchEnum(source, targetPitch, speed, startPitch));
    }

    public static void lerpLowPass(AudioLowPassFilter source, float targetCutoff, float speed)
    {
        instance.StartCoroutine(instance.lerpLowPassEnum(source, targetCutoff, speed));
    }

    public static void lerpLowPass(AudioLowPassFilter source, float targetCutoff, float speed, float startCutoff)
    {
        instance.StartCoroutine(instance.lerpLowPassEnum(source, targetCutoff, speed, startCutoff));
    }

    public static void lerpHighPass(AudioHighPassFilter source, float targetCutoff, float speed)
    {
        instance.StartCoroutine(instance.lerpHighPassEnum(source, targetCutoff, speed));
    }

    public static void lerpHighPass(AudioHighPassFilter source, float targetCutoff, float speed, float startCutoff)
    {
        instance.StartCoroutine(instance.lerpHighPassEnum(source, targetCutoff, speed, startCutoff));
    }

    public static void lerpPosition(Transform modelTransform, Vector3 targetPosition, float speed, bool useLocalPosition = false)
    {
        instance.StartCoroutine(instance.lerpPositionEnum(modelTransform, targetPosition, speed, useLocalPosition));
    }

    public static void lerpPosition(Transform modelTransform, Vector3 targetPosition, float speed, Vector3 startPosition)
    {
        instance.StartCoroutine(instance.lerpPositionEnum(modelTransform, targetPosition, speed, startPosition));
    }

    public static void lerpRotation(Transform modelTransform, Quaternion targetRotation, float speed)
    {
        instance.StartCoroutine(instance.lerpRotationEnum(modelTransform, targetRotation, speed));
    }

    public static void lerpRotation(Transform modelTransform, Quaternion targetRotation, float speed, Quaternion startRotation)
    {
        instance.StartCoroutine(instance.lerpRotationEnum(modelTransform, targetRotation, speed, startRotation));
    }

    public static void lerpLocalRotation(Transform modelTransform, Quaternion targetRotation, float speed)
    {
        instance.StartCoroutine(instance.lerpLocalRotationEnum(modelTransform, targetRotation, speed));
    }

    public static void lerpLocalRotation(Transform modelTransform, Quaternion targetRotation, float speed, Quaternion startRotation)
    {
        instance.StartCoroutine(instance.lerpLocalRotationEnum(modelTransform, targetRotation, speed, startRotation));
    }

    public static void lerpScale(Transform modelTransform, Vector3 targetScale, float speed)
    {
        instance.StartCoroutine(instance.lerpScaleEnum(modelTransform, targetScale, speed));
    }

    public static void lerpScale(Transform modelTransform, Vector3 targetScale, float speed, Vector3 startScale)
    {
        instance.StartCoroutine(instance.lerpScaleEnum(modelTransform, targetScale, speed, startScale));
    }

    public static void lerpMaterialColour(Material material, Color targetColour, float speed)
    {
        instance.StartCoroutine(instance.lerpMaterialColourEnum(material, targetColour, speed));
    }

    public static void lerpMaterialColour(Material material, Color targetColour, float speed, Color startColour)
    {
        instance.StartCoroutine(instance.lerpMaterialColourEnum(material, targetColour, speed, startColour));
    }

    public static void lerpSpriteColour(SpriteRenderer spriteRenderer, Color targetColour, float speed)
    {
        instance.StartCoroutine(instance.lerpSpriteColourEnum(spriteRenderer, targetColour, speed));
    }

    public static void lerpSpriteColour(SpriteRenderer spriteRenderer, Color targetColour, float speed, Color startColour)
    {
        instance.StartCoroutine(instance.lerpSpriteColourEnum(spriteRenderer, targetColour, speed, startColour));
    }

    public static void lerpImageColour(Image image, Color targetColour, float speed)
    {
        instance.StartCoroutine(instance.lerpImageColourEnum(image, targetColour, speed));
    }

    public static void lerpImageColour(Image image, Color targetColour, float speed, Color startColour)
    {
        instance.StartCoroutine(instance.lerpImageColourEnum(image, targetColour, speed, startColour));
    }

    public static void lerpTextColour(TextMeshProUGUI text, Color targetColour, float speed)
    {
        instance.StartCoroutine(instance.lerpTextColourEnum(text, targetColour, speed));
    }

    public static void lerpTextColour(TextMeshProUGUI text, Color targetColour, float speed, Color startColour)
    {
        instance.StartCoroutine(instance.lerpTextColourEnum(text, targetColour, speed, startColour));
    }

    public static void lerpTextColour(TextMeshPro text, Color targetColour, float speed)
    {
        instance.StartCoroutine(LerpSolution.lerpTextColourEnum(text, targetColour, speed));
    }

    public static void lerpTextColour(TextMeshPro text, Color targetColour, float speed, Color startColour)
    {
        instance.StartCoroutine(instance.lerpTextColourEnum(text, targetColour, speed, startColour));
    }

    public static void lerpCamColour(Camera camera, Color targetColour, float speed)
    {
        instance.StartCoroutine(instance.lerpCamColourEnum(camera, targetColour, speed));
    }

    public static void lerpCamColour(Camera camera, Color targetColour, float speed, Color startColour)
    {
        instance.StartCoroutine(instance.lerpCamColourEnum(camera, targetColour, speed, startColour));
    }

    public static void lerpCamSize(Camera camera, float targetSize, float speed)
    {
        instance.StartCoroutine(instance.lerpCamSizeEnum(camera, targetSize, speed));
    }

    public static void lerpCamSize(Camera camera, float targetSize, float speed, float startSize)
    {
        instance.StartCoroutine(instance.lerpCamSizeEnum(camera, targetSize, speed, startSize));
    }

    public static void lerpCamFov(Camera camera, float targetFov, float speed)
    {
        instance.StartCoroutine(instance.lerpCamFovEnum(camera, targetFov, speed));
    }

    public static void lerpCamFov(Camera camera, float targetFov, float speed, float startFov)
    {
        instance.StartCoroutine(instance.lerpCamFovEnum(camera, targetFov, speed, startFov));
    }

    //public static void lerpVignetteIntensity(Vignette vignette, float targetIntensity, float speed)
    //{
    //    instance.StartCoroutine(instance.lerpVignetteIntensityEnum(vignette, targetIntensity, speed));
    //}

    //public static void lerpVignetteIntensity(Vignette vignette, float targetIntensity, float speed, float startIntensity)
    //{
    //    instance.StartCoroutine(instance.lerpVignetteIntensityEnum(vignette, targetIntensity, speed, startIntensity));
    //}

    //public static void LerpColourFilter(ColorGrading colorGrading, Color targetColour, float speed)
    //{
    //    instance.StartCoroutine(instance.lerpColourFilterEnum(colorGrading, targetColour, speed));
    //}

    //public static void LerpColourFilter(ColorGrading colorGrading, Color targetColour, float speed, Color startColour)
    //{
    //    instance.StartCoroutine(instance.lerpColourFilterEnum(colorGrading, targetColour, speed, startColour));
    //}

    //public static void LerpColourGradingGeneral(ColorGrading colorGrading, float targetTemperature, float targetTint, float targetRedMix, float targetGreenMix, float targetBlueMix, float speed)
    //{
    //    instance.StartCoroutine(instance.lerpColourGradingGeneralEnum(colorGrading, targetTemperature, targetTint, targetRedMix, targetGreenMix, targetBlueMix, speed));
    //}

    public static void LerpLightRange(Light light, float targetRange, float speed)
    {
        instance.StartCoroutine(instance.lerpLightRange(light, targetRange, speed));
    }
    public static void LerpLightRange(Light light, float targetRange, float speed, float startRange)
    {
        instance.StartCoroutine(instance.lerpLightRange(light, targetRange, speed, startRange));
    }


    #endregion
    #region Coroutines

    IEnumerator lerpVolumeEnum(AudioSource source, float targetVolume, float speed)
    {
        float currentVolume = source.volume;
        float dist = 0;
        while (dist < 1)
        {
            dist += Time.deltaTime * speed;
            source.volume = Mathf.Lerp(currentVolume, targetVolume, dist);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator lerpVolumeEnum(AudioSource source, float targetVolume, float speed, float startVolume)
    {
        float currentVolume = startVolume;
        float dist = 0;
        while (dist < 1)
        {
            dist += Time.deltaTime * speed;
            source.volume = Mathf.Lerp(currentVolume, targetVolume, dist);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator lerpPitchEnum(AudioSource source, float targetPitch, float speed)
    {
        float currentPitch = source.pitch;
        float dist = 0;
        while (dist < 1)
        {
            dist += Time.deltaTime * speed;
            source.pitch = Mathf.Lerp(currentPitch, targetPitch, dist);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator lerpPitchEnum(AudioSource source, float targetPitch, float speed, float startPitch)
    {
        float currentPitch = startPitch;
        float dist = 0;
        while (dist < 1)
        {
            dist += Time.deltaTime * speed;
            source.pitch = Mathf.Lerp(currentPitch, targetPitch, dist);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator lerpLowPassEnum(AudioLowPassFilter lowPass, float targetCutoff, float speed)
    {
        float currentCutoff = lowPass.cutoffFrequency;
        float dist = 0;
        while (dist < 1)
        {
            dist += Time.deltaTime * speed;
            lowPass.cutoffFrequency = Mathf.Lerp(currentCutoff, targetCutoff, dist);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator lerpLowPassEnum(AudioLowPassFilter lowPass, float targetCutoff, float speed, float startCutoff)
    {
        float currentCutoff = startCutoff;
        float dist = 0;
        while (dist < 1)
        {
            dist += Time.deltaTime * speed;
            lowPass.cutoffFrequency = Mathf.Lerp(currentCutoff, targetCutoff, dist);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator lerpHighPassEnum(AudioHighPassFilter highPass, float targetCutoff, float speed)
    {
        float currentCutoff = highPass.cutoffFrequency;
        float dist = 0;
        while (dist < 1)
        {
            dist += Time.deltaTime * speed;
            highPass.cutoffFrequency = Mathf.Lerp(currentCutoff, targetCutoff, dist);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator lerpHighPassEnum(AudioHighPassFilter highPass, float targetCutoff, float speed, float startCutoff)
    {
        float currentCutoff = startCutoff;
        float dist = 0;
        while (dist < 1)
        {
            dist += Time.deltaTime * speed;
            highPass.cutoffFrequency = Mathf.Lerp(currentCutoff, targetCutoff, dist);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator lerpPositionEnum(Transform modelTransform, Vector3 targetPosition, float speed, bool useLocalPosition)
    {
        Vector3 currentPosition = modelTransform.position;
        if (useLocalPosition) currentPosition = modelTransform.localPosition;
        float dist = 0;
        while (dist < 1)
        {
            dist += Time.deltaTime * speed;
            if (useLocalPosition) modelTransform.localPosition = Vector3.Lerp(currentPosition, targetPosition, dist);
            else modelTransform.position = Vector3.Lerp(currentPosition, targetPosition, dist);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator lerpPositionEnum(Transform modelTransform, Vector3 targetPosition, float speed, Vector3 startPosition)
    {
        Vector3 currentPosition = startPosition;
        float dist = 0;
        while (dist < 1)
        {
            dist += Time.deltaTime * speed;
            modelTransform.position = Vector3.Lerp(currentPosition, targetPosition, dist);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator lerpRotationEnum(Transform modelTransform, Quaternion targetRotation, float speed)
    {
        Quaternion currentRotation = modelTransform.rotation;
        float dist = 0;
        while (dist < 1)
        {
            dist += Time.deltaTime * speed;
            modelTransform.rotation = Quaternion.Lerp(currentRotation, targetRotation, dist);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator lerpRotationEnum(Transform modelTransform, Quaternion targetRotation, float speed, Quaternion startRotation)
    {
        Quaternion currentRotation = startRotation;
        float dist = 0;
        while (dist < 1)
        {
            dist += Time.deltaTime * speed;
            modelTransform.rotation = Quaternion.Lerp(currentRotation, targetRotation, dist);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator lerpLocalRotationEnum(Transform modelTransform, Quaternion targetRotation, float speed)
    {
        Quaternion currentRotation = modelTransform.localRotation;
        float dist = 0;
        while (dist < 1)
        {
            dist += Time.deltaTime * speed;
            modelTransform.localRotation = Quaternion.Lerp(currentRotation, targetRotation, dist);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator lerpLocalRotationEnum(Transform modelTransform, Quaternion targetRotation, float speed, Quaternion startRotation)
    {
        Quaternion currentRotation = startRotation;
        float dist = 0;
        while (dist < 1)
        {
            dist += Time.deltaTime * speed;
            modelTransform.localRotation = Quaternion.Lerp(currentRotation, targetRotation, dist);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator lerpScaleEnum(Transform modelTransform, Vector3 targetScale, float speed)
    {
        Vector3 currentScale = modelTransform.localScale;
        float dist = 0;
        while (dist < 1)
        {
            dist += Time.deltaTime * speed;
            modelTransform.localScale = Vector3.Lerp(currentScale, targetScale, dist);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator lerpScaleEnum(Transform modelTransform, Vector3 targetScale, float speed, Vector3 startScale)
    {
        Vector3 currentScale = startScale;
        float dist = 0;
        while (dist < 1)
        {
            dist += Time.deltaTime * speed;
            modelTransform.localScale = Vector3.Lerp(currentScale, targetScale, dist);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator lerpMaterialColourEnum(Material material, Color targetColour, float speed)
    {
        Color currentColour = material.color;
        float dist = 0;
        while (dist < 1)
        {
            dist += Time.deltaTime * speed;
            material.color = Color.Lerp(currentColour, targetColour, dist);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator lerpMaterialColourEnum(Material material, Color targetColour, float speed, Color startColour)
    {
        Color currentColour = startColour;
        float dist = 0;
        while (dist < 1)
        {
            dist += Time.deltaTime * speed;
            material.color = Color.Lerp(currentColour, targetColour, dist);
            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator lerpSpriteColourEnum(SpriteRenderer spriteRenderer, Color targetColour, float speed)
    {
        Color currentColour = spriteRenderer.color;
        float dist = 0;
        while (dist < 1)
        {
            dist += Time.deltaTime * speed;
            spriteRenderer.color = Color.Lerp(currentColour, targetColour, dist);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator lerpSpriteColourEnum(SpriteRenderer spriteRenderer, Color targetColour, float speed, Color startColour)
    {
        Color currentColour = startColour;
        float dist = 0;
        while (dist < 1)
        {
            dist += Time.deltaTime * speed;
            spriteRenderer.color = Color.Lerp(currentColour, targetColour, dist);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator lerpImageColourEnum(Image image, Color targetColour, float speed)
    {
        Color currentColour = image.color;
        float dist = 0;
        while (dist < 1)
        {
            dist += Time.deltaTime * speed;
            image.color = Color.Lerp(currentColour, targetColour, dist);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator lerpImageColourEnum(Image image, Color targetColour, float speed, Color startColour)
    {
        Color currentColour = startColour;
        float dist = 0;
        while (dist < 1)
        {
            dist += Time.deltaTime * speed;
            image.color = Color.Lerp(currentColour, targetColour, dist);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator lerpTextColourEnum(TextMeshProUGUI text, Color targetColour, float speed)
    {
        Color currentColour = text.color;
        float dist = 0;
        while (dist < 1)
        {
            dist += Time.deltaTime * speed;
            text.color = Color.Lerp(currentColour, targetColour, dist);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator lerpTextColourEnum(TextMeshProUGUI text, Color targetColour, float speed, Color startColour)
    {
        Color currentColour = startColour;
        float dist = 0;
        while (dist < 1)
        {
            dist += Time.deltaTime * speed;
            text.color = Color.Lerp(currentColour, targetColour, dist);
            yield return new WaitForEndOfFrame();
        }
    }

    public static IEnumerator lerpTextColourEnum(TextMeshPro text, Color targetColour, float speed)
    {
        Color currentColour = text.color;
        float dist = 0;
        while (dist < 1)
        {
            dist += Time.deltaTime * speed;
            text.color = Color.Lerp(currentColour, targetColour, dist);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator lerpTextColourEnum(TextMeshPro text, Color targetColour, float speed, Color startColour)
    {
        Color currentColour = startColour;
        float dist = 0;
        while (dist < 1)
        {
            dist += Time.deltaTime * speed;
            text.color = Color.Lerp(currentColour, targetColour, dist);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator lerpCamColourEnum(Camera camera, Color targetColour, float speed)
    {
        Color currentColour = camera.backgroundColor;
        float dist = 0;
        while (dist < 1)
        {
            dist += Time.deltaTime * speed;
            camera.backgroundColor = Color.Lerp(currentColour, targetColour, dist);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator lerpCamColourEnum(Camera camera, Color targetColour, float speed, Color startColour)
    {
        float dist = 0;
        while (dist < 1)
        {
            dist += Time.deltaTime * speed;
            camera.backgroundColor = Color.Lerp(startColour, targetColour, dist);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator lerpCamSizeEnum(Camera camera, float targetSize, float speed)
    {
        float currentSize = camera.orthographicSize;
        float dist = 0;
        while (dist < 1)
        {
            dist += Time.deltaTime * speed;
            camera.orthographicSize = Mathf.Lerp(currentSize, targetSize, dist);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator lerpCamSizeEnum(Camera camera, float targetSize, float speed, float startSize)
    {
        float dist = 0;
        while (dist < 1)
        {
            dist += Time.deltaTime * speed;
            camera.orthographicSize = Mathf.Lerp(startSize, targetSize, dist);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator lerpCamFovEnum(Camera camera, float targetFov, float speed)
    {
        float currentFov = camera.fieldOfView;
        float dist = 0;
        while (dist < 1)
        {
            dist += Time.deltaTime * speed;
            camera.fieldOfView = Mathf.Lerp(currentFov, targetFov, dist);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator lerpCamFovEnum(Camera camera, float targetFov, float speed, float startFov)
    {
        float currentFov = startFov;
        float dist = 0;
        while (dist < 1)
        {
            dist += Time.deltaTime * speed;
            camera.fieldOfView = Mathf.Lerp(currentFov, targetFov, dist);
            yield return new WaitForEndOfFrame();
        }
    }

    //IEnumerator lerpVignetteIntensityEnum(Vignette vignette, float targetIntensity, float speed)
    //{
    //    float currentIntensity = vignette.intensity.value;
    //    float dist = 0;
    //    while (dist < 1)
    //    {
    //        dist += Time.deltaTime * speed;
    //        vignette.intensity.value = Mathf.Lerp(currentIntensity, targetIntensity, dist);
    //        yield return new WaitForEndOfFrame();
    //    }
    //}

    //IEnumerator lerpVignetteIntensityEnum(Vignette vignette, float targetIntensity, float speed, float startIntensity)
    //{
    //    float currentIntensity = startIntensity;
    //    float dist = 0;
    //    while (dist < 1)
    //    {
    //        dist += Time.deltaTime * speed;
    //        vignette.intensity.value = Mathf.Lerp(currentIntensity, targetIntensity, dist);
    //        yield return new WaitForEndOfFrame();
    //    }
    //}

    //IEnumerator lerpColourFilterEnum(ColorGrading colorGrading, Color targetColour, float speed)
    //{
    //    Color currentColour = colorGrading.colorFilter.value;
    //    float dist = 0;
    //    while (dist < 1)
    //    {
    //        dist += Time.deltaTime * speed;
    //        colorGrading.colorFilter.value = (Color.Lerp(currentColour, targetColour, dist));
    //        yield return new WaitForEndOfFrame();
    //    }
    //}

    //IEnumerator lerpColourFilterEnum(ColorGrading colorGrading, Color targetColour, float speed, Color startColour)
    //{
    //    Color currentColour = startColour;
    //    float dist = 0;
    //    while (dist < 1)
    //    {
    //        dist += Time.deltaTime * speed;
    //        colorGrading.colorFilter.value = Color.Lerp(currentColour, targetColour, dist);
    //        yield return new WaitForEndOfFrame();
    //    }
    //}

    //IEnumerator lerpColourGradingGeneralEnum(ColorGrading colorGrading, float targetTemperature, float targetTint, float targetRedMix, float targetGreenMix, float targetBlueMix, float speed)
    //{
    //    instance.StartCoroutine(instance.lerpTemperature(colorGrading, targetTemperature, speed));
    //    instance.StartCoroutine(instance.lerpTint(colorGrading, targetTint, speed));
    //    instance.StartCoroutine(instance.lerpRedMix(colorGrading, targetRedMix, speed));
    //    instance.StartCoroutine(instance.lerpGreenMix(colorGrading, targetGreenMix, speed));
    //    instance.StartCoroutine(instance.lerpBlueMix(colorGrading, targetBlueMix, speed));

    //    yield return new WaitForEndOfFrame();
    //}

    //IEnumerator lerpTemperature(ColorGrading colorGrading, float targetTemperature, float speed)
    //{
    //    float currentTemp = colorGrading.temperature;
    //    float dist = 0;
    //    while (dist < 1)
    //    {
    //        dist += Time.deltaTime * speed;
    //        colorGrading.temperature.value = Mathf.Lerp(currentTemp, targetTemperature, dist);
    //        yield return new WaitForEndOfFrame();
    //    }
    //}

    //IEnumerator lerpTint(ColorGrading colorGrading, float targetTint, float speed)
    //{
    //    float currentTint = colorGrading.tint;
    //    float dist = 0;
    //    while (dist < 1)
    //    {
    //        dist += Time.deltaTime * speed;
    //        colorGrading.tint.value = Mathf.Lerp(currentTint, targetTint, dist);
    //        yield return new WaitForEndOfFrame();
    //    }
    //}

    //IEnumerator lerpRedMix(ColorGrading colorGrading, float targetMix, float speed)
    //{
    //    float currentMix = colorGrading.mixerRedOutRedIn;
    //    float dist = 0;
    //    while (dist < 1)
    //    {
    //        dist += Time.deltaTime * speed;
    //        colorGrading.mixerRedOutRedIn.value = Mathf.Lerp(currentMix, targetMix, dist);
    //        yield return new WaitForEndOfFrame();
    //    }
    //}

    //IEnumerator lerpGreenMix(ColorGrading colorGrading, float targetMix, float speed)
    //{
    //    float currentMix = colorGrading.mixerRedOutGreenIn;
    //    float dist = 0;
    //    while (dist < 1)
    //    {
    //        dist += Time.deltaTime * speed;
    //        colorGrading.mixerRedOutGreenIn.value = Mathf.Lerp(currentMix, targetMix, dist);
    //        yield return new WaitForEndOfFrame();
    //    }
    //}

    //IEnumerator lerpBlueMix(ColorGrading colorGrading, float targetMix, float speed)
    //{
    //    float currentMix = colorGrading.mixerRedOutBlueIn;
    //    float dist = 0;
    //    while (dist < 1)
    //    {
    //        dist += Time.deltaTime * speed;
    //        colorGrading.mixerRedOutBlueIn.value = Mathf.Lerp(currentMix, targetMix, dist);
    //        yield return new WaitForEndOfFrame();
    //    }
    //}

    IEnumerator lerpLightRange(Light light, float targetRange, float speed)
    {
        float currentRange = light.range;
        float dist = 0;
        while (dist < 1)
        {
            dist += Time.deltaTime * speed;
            light.range = (Mathf.Lerp(currentRange, targetRange, dist));
            yield return new WaitForEndOfFrame();
        }
    }
    IEnumerator lerpLightRange(Light light, float targetRange, float speed, float startRange)
    {
        float currentRange = startRange;
        float dist = 0;
        while (dist < 1)
        {
            dist += Time.deltaTime * speed;
            light.range = (Mathf.Lerp(currentRange, targetRange, dist));
            yield return new WaitForEndOfFrame();
        }
    }

    #endregion
}