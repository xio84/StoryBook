using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    private List<GameObject> objPics;
    private RectTransform rectTransform;
    private RectTransform cursRect;
    private bool show = false;
    private float cursorStart;

    public GameObject placeHolder;
    public GameObject selector;
    public float timeToFade;
    public float fadeSpeed = 1;
    public float fadeTime = 5;
    public float beginning = -230;
    public float margin = 80;
    // Start is called before the first frame update
    void Start()
    {
        objPics = new List<GameObject>();
        rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(0, 180);

        cursRect = selector.GetComponent<RectTransform>();
        cursorStart = cursRect.anchoredPosition.x;
        selector.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = rectTransform.anchoredPosition;
        // Fade in UI
        if (show && pos.y > 80)
        {
            rectTransform.anchoredPosition = new Vector2(0, pos.y - (Time.deltaTime * fadeSpeed));
        } 
        // Wait until fade
        else if (pos.y <= 80 && timeToFade > 0)
        {
            show = false;
            rectTransform.anchoredPosition = new Vector2(0, 80);
            show = false;
            timeToFade -= Time.deltaTime;
        }
        // Fade out UI
        else if (pos.y < 180 && timeToFade <= 0)
        {
            rectTransform.anchoredPosition = new Vector2(0, pos.y + (Time.deltaTime * fadeSpeed));
        }
    }

    // Show UI
    public void UpdateInventory(List<Sprite> pics)
    {
        float b = beginning;
        foreach (GameObject obj in objPics)
        {
            Destroy(obj);
        }
        objPics.Clear();
        foreach (Sprite pic in pics)
        {
            GameObject img = Instantiate(placeHolder, rectTransform);
            Image image = img.GetComponent<Image>();
            image.sprite = pic;
            RectTransform rect = img.GetComponent<RectTransform>();
            rect.SetParent(rectTransform);
            rect.SetAsFirstSibling();
            img.SetActive(true);
            rect.anchoredPosition = new Vector2(b, 0);
            objPics.Add(img);
            b += margin + 10;
        }
        if (objPics.Count > 0)
        {
            selector.SetActive(true);
            cursRect.anchoredPosition = new Vector2(cursorStart, 0);
        }
        else
        {
            selector.SetActive(false);
        }
        timeToFade = fadeTime;
        show = true;
    }

    // Scroll through inventory
    public void Scroll(int cursor)
    {
        cursRect.anchoredPosition = new Vector2(cursorStart + ((margin + 10) * cursor), 0);
        timeToFade = fadeTime;
        show = true;
    }
}
