using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FundirNegro : MonoBehaviour
{

    Color newColor;
    public bool fundir = false;
    float temp=0;
    SpriteRenderer r;
    // Start is called before the first frame update
    void Start()
    {
        r = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fundir)
        {
            fundir = false;
            StartCoroutine(FadeToBlack());
        }
    }
    IEnumerator FadeToBlack() {
        while (temp <= 1) {
            Debug.Log(temp);
            temp += 0.05f;
            yield return new WaitForSecondsRealtime(0.02f);
            newColor = r.color;
            newColor.a = temp;
            r.color = newColor;
        }
        SceneManager.LoadScene("tuto1");
    }
}
/*if (lineaAnim == 12)
			{
				fn = FindObjectOfType<FundirNegro>();
				fn.fundir = true;
			}*/