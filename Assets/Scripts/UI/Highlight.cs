using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Highlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite unhighlight;
    public Sprite highlight;
    public Vector2 uHighSize;
    public Vector2 highSize;
    private RectTransform tr;
    private Image im;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<RectTransform>();
        im = GetComponent<Image>();
        tr.sizeDelta = uHighSize;
        im.sprite = unhighlight;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tr.sizeDelta = highSize;
        im.sprite = highlight;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tr.sizeDelta = uHighSize;
        im.sprite = unhighlight;
    }
}
