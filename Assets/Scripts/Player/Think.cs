using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Think : MonoBehaviour
{
    public GameObject ThinkBox;
    public SpriteRenderer ThinkFill;
    public float fadeSpeed;
    public Sprite eKey;
    public Sprite fKey;

    private SpriteRenderer TBSR;
    private PlayerInventory PI;
    private LayerMask interactable;
    private float interactRadius;
    [SerializeField] private bool show;
    // Start is called before the first frame update
    void Start()
    {
        TBSR = ThinkBox.GetComponent<SpriteRenderer>();
        PI = this.GetComponent<PlayerInventory>();
        interactable = PI.interactable;
        interactRadius = PI.interactRadius;
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, interactRadius, interactable);
        if (targets.Length == 0)
        {
            show = false;
        } else
        {
            if (targets.Length > 1)
            {
                targets = targets.OrderBy(c => Vector3.Distance(transform.position, c.transform.position)).ToArray();
            }

            IThinkable iT = targets[0].GetComponent<IThinkable>();
            if (iT != null)
            {
                switch (iT.Think()) {
                    case 0:
                        ThinkFill.sprite = eKey;
                        break;
                    case 1:
                        ThinkFill.sprite = fKey;
                        break;
                    default:
                        break;
                }
                show = true;
            } else
            {
                show = false;
            }
        }

        // Fade In
        if (show)
        {
            Color c = ThinkFill.material.color;
            if (c.a < 1f)
            {
                c.a += Time.deltaTime * fadeSpeed;
                c.a = Mathf.Clamp(c.a, 0f, 1f);
                ThinkFill.material.color = c;
            }
            c = TBSR.material.color;
            if (c.a < 1f)
            {
                c.a += Time.deltaTime * fadeSpeed;
                c.a = Mathf.Clamp(c.a, 0f, 1f);
                TBSR.material.color = c;
            }
        } else {
            Color c = ThinkFill.material.color;
            if (c.a > 0f)
            {
                c.a -= Time.deltaTime * fadeSpeed;
                c.a = Mathf.Clamp(c.a, 0f, 1f);
                ThinkFill.material.color = c;
            }
            c = TBSR.material.color;
            if (c.a > 0f)
            {
                c.a -= Time.deltaTime * fadeSpeed;
                c.a = Mathf.Clamp(c.a, 0f, 1f);
                TBSR.material.color = c;
            }
        }
    }
}
