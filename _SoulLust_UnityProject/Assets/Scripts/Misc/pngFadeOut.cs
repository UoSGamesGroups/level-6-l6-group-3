using UnityEngine;
using System.Collections;

public class pngFadeOut : MonoBehaviour {

    [SerializeField] private float untilStart;
    [SerializeField] private float fadeSpeed;

    private float a = 1f;
    private bool isFading;
    private SpriteRenderer sprite;




    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(untilStart);
        isFading = true;
    }

    void Update()
    {
        a = Mathf.Clamp(a, 0, 1);
        

        if (isFading)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, a);
            a -= Time.deltaTime * fadeSpeed;

        }

        if (a < 0)
        {
            this.enabled = false;
        }
    }
}
