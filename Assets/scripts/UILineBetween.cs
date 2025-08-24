using UnityEngine;

public class UILineBetween : MonoBehaviour
{
    public RectTransform a;         // las dos imágenes que querés unir
    public RectTransform b;
    public RectTransform line;      // este mismo RectTransform (la Image de la línea)
    public Canvas canvas;           // tu Canvas (para grosor 1 píxel real)
    public float pixelsThickness = 1f;

    void Reset()
    {
        line = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    void LateUpdate()
    {
        if (a == null || b == null || line == null) return;

        // Convertir centros a espacio local del padre de la línea
        var parent = (RectTransform)line.parent;

        Vector2 aWorld = a.TransformPoint(a.rect.center);
        Vector2 bWorld = b.TransformPoint(b.rect.center);

        Vector2 aLocal, bLocal;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parent,
            RectTransformUtility.WorldToScreenPoint(null, aWorld),
            canvas.renderMode == RenderMode.ScreenSpaceCamera ? canvas.worldCamera : null,
            out aLocal
        );
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parent,
            RectTransformUtility.WorldToScreenPoint(null, bWorld),
            canvas.renderMode == RenderMode.ScreenSpaceCamera ? canvas.worldCamera : null,
            out bLocal
        );

        // Calcular posición media, distancia y ángulo
        Vector2 delta = bLocal - aLocal;
        float distance = delta.magnitude;
        float angle = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;

        // Grosor = 1 píxel real (independiente del Canvas Scaler)
        float thickness = pixelsThickness / (canvas != null ? canvas.scaleFactor : 1f);

        // Aplicar al RectTransform de la línea
        line.anchoredPosition = (aLocal + bLocal) * 0.5f;
        line.sizeDelta = new Vector2(distance, thickness);
        line.localRotation = Quaternion.Euler(0, 0, angle);
    }
}
