using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using UnityEngine.SceneManagement;

public class Dialogo : MonoBehaviour
{
    public TextMeshProUGUI componenteTexto;
    public string[] lineas;
    public float textSpeed;
	public int[] personaje;
	Animator animations = new Animator();
	public GameObject fundidoNegro;
	private int i;
	private int lineaAnim = 0;
	FundirNegro fn;
	// Start is called before the first frame update
	void Start()
	{
		animations = gameObject.GetComponent<Animator>();
		componenteTexto.text = string.Empty;
		inicioDial();
	}

	// Update is called once per frame
	void Update()
	{

		animations.SetInteger("Personaje", personaje[lineaAnim]);

		if (Input.GetMouseButtonDown(0) || Input.GetKeyUp("space"))
		{
			if (componenteTexto.text == lineas[i])
			{
				
				Debug.Log(lineaAnim + "    " + personaje[lineaAnim]);
				proximaLinea();
			}
			else
			{
				StopAllCoroutines();
				componenteTexto.text = lineas[i];
			}

			if (lineaAnim == 12)
			{
				fn = FindObjectOfType<FundirNegro>();
				fn.fundir = true;
			}
		}
	}

	void inicioDial()
	{
		i = 0;
		StartCoroutine(escribir());
	}
	IEnumerator escribir()
	{
		foreach (char c in lineas[i].ToCharArray())
		{
			componenteTexto.text += c;
			yield return new WaitForSeconds(textSpeed);
		}
	}
	void proximaLinea()
	{
		//animación

		//animación
		if (i < lineas.Length - 1)
		{
			lineaAnim++;
			i++;
			componenteTexto.text = string.Empty;
			StartCoroutine(escribir());
		}
		else
		{
			gameObject.SetActive(false);
		}
	}
}
