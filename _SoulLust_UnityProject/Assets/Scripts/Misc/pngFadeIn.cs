using UnityEngine;
using System.Collections;

public class pngFadeIn : MonoBehaviour {

    [SerializeField] private float untilStart;
    [SerializeField] private float fadeSpeed;

    private float a = 0f;
    private bool isFading = false;
    private SpriteRenderer sprite;




    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    IEnumerator Start()
    {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0);
        yield return new WaitForSeconds(untilStart);
        isFading = true;
    }

    void Update()
    {
        if (isFading)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, a);
            a += Time.deltaTime * fadeSpeed;
        }

        if (a != 0)
        {
            transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * 0.02f;
        }

        if (a > 1)
        {
            //this.enabled = false;
            isFading = false;
        }
    }


}
