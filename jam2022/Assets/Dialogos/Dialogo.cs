using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogo : MonoBehaviour
{
    public TextMeshProUGUI componenteTexto;
    public string[] lineas;
    public float textSpeed;

    private int i;
    // Start is called before the first frame update
    void Start()
    {
        componenteTexto.text = string.Empty;
        inicioDial();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            if(componenteTexto.text == lineas[i]){     
                proximaLinea();
            }else{
                StopAllCoroutines();
                componenteTexto.text = lineas[i];
            }
        }
    }

    void inicioDial(){
        i = 0;
        StartCoroutine(escribir());
    }
    IEnumerator escribir(){
        foreach(char c in lineas[i].ToCharArray())
        {
            componenteTexto.text +=c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void proximaLinea(){
        if(i < lineas.Length -1)
        {
            i++;
            componenteTexto.text = string.Empty;
            StartCoroutine(escribir());
        }else{
            gameObject.SetActive(false);
        }
    }
}
