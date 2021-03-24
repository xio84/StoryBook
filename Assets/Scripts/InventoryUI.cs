using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    private List<GameObject> objPics;
    private RectTransform rectTransform;
    private RectTransform cursRect;
    private float cursorStart;
    private int cursorLocal;
    private float startPos;
    private float margin;
    private bool show = false;

    public GameObject placeHolder;
    public GameObject selector;
    public Rigidbody player;
    public float timeToFade;
    public float fadeSpeed = 1;
    public float fadeTime = 5;

    public bool Show { get => show; set => show = value; }

    // Start is called before the first frame update
    void Start()
    {
        objPics = new List<GameObject>();
        rectTransform = GetComponent<RectTransform>();
        startPos = rectTransform.anchoredPosition.y;
        rectTransform.anchoredPosition = new Vector2(0, startPos + rectTransform.rect.height);

        cursRect = selector.GetComponent<RectTransform>();
        cursorStart = cursRect.anchoredPosition.x;
        selector.SetActive(false);
        Show = false;
        timeToFade = 0;
        margin = cursRect.rect.width;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = rectTransform.anchoredPosition;
        // Fade in UI
        if (Show && pos.y > startPos)
        {
            rectTransform.anchoredPosition = new Vector2(0, pos.y - (Time.deltaTime * fadeSpeed));
        } 
        // Wait until fade
        else if (pos.y <= startPos && timeToFade > 0)
        {
            Show = false;
            rectTransform.anchoredPosition = new Vector2(0, startPos);
            timeToFade -= Time.deltaTime;
            // When player moves, immediately fades
            if (player.velocity != Vector3.zero)
            {
                timeToFade = 0;
            }
        }
        // Fade out UI
        else if (pos.y < startPos + rectTransform.rect.height && timeToFade <= 0)
        {
            rectTransform.anchoredPosition = new Vector2(0, pos.y + (Time.deltaTime * fadeSpeed));
        }
    }

    // Show UI
    public void UpdateInventory(List<Obtainable> obj)
    {
        float b = cursorStart;
        foreach (GameObject pic in objPics)
        {
            Destroy(pic);
        }
        objPics.Clear();
        foreach (Obtainable o in obj)
        {
            GameObject img = Instantiate(placeHolder, rectTransform);
            Image image = img.GetComponent<Image>();
            image.sprite = o.picture;
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
            cursRect.anchoredPosition = new Vector2(cursorStart + ((margin + 10) * cursorLocal), 0);
        }
        else
        {
            selector.SetActive(false);
        }
        timeToFade = fadeTime;
        Show = true;
    }

    // Scroll through inventory
    public void Scroll(int cursor)
    {
        cursorLocal = cursor;
        cursRect.anchoredPosition = new Vector2(cursorStart + ((margin + 10) * cursor), 0);
        timeToFade = fadeTime;
        Show = true;
        Debug.Log("Cursing...");
    }


}
