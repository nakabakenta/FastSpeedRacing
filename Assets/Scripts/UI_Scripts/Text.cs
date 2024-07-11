using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Text : MonoBehaviour
{
    private TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = this.gameObject.GetComponent<TMP_Text>();
        text.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        StartCoroutine("Flashing");
    }

    IEnumerator Flashing()
    {
        while (true)
        {
            for (int i = 0; i < 25; i++)
            {
                text.color = text.color - new Color32(0, 0, 0, 10);
                yield return new WaitForSeconds(0.1f);
            }

            for (int k = 0; k < 25; k++)
            {
                text.color = text.color + new Color32(0, 0, 0, 10);
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
