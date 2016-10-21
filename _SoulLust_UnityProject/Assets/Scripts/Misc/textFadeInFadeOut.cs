using UnityEngine;
using System.Collections;

public class textFadeInFadeOut : MonoBehaviour {
    
    [SerializeField] private float untilStart;
    [SerializeField] private float activeTime;
    [SerializeField] private float fadeSpeed;


    [SerializeField]private float a = 0f;
    private TextMesh text;
    private bool isFading;

    private float time;

    void Awake()
    {
        text = GetComponent<TextMesh>();
    }

    IEnumerator Start()
    {
        a = 0f;

        yield return new WaitForSeconds(untilStart);

        isFading = true;

        yield return new WaitForSeconds(activeTime);

        isFading = false;
        
    }


    void Update()
    {
        a = Mathf.Clamp(a, 0, 1);
        text.color = new Color(text.color.r, text.color.g, text.color.b, a);
        
        if (isFading && text.color.a <= 1)
        {
            a += Time.deltaTime * fadeSpeed;
        }
        else if (!isFading && text.color.a > 0)
        {
            a -= Time.deltaTime * fadeSpeed;
        }
        


    }

   


}
