using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIOption : MonoBehaviour
{
    private TMP_Text text;

    public UIOptionInfo textOptionInfo;//�g�p����e�L�X�g�ݒ�

    // Start is called before the first frame update
    void Start()
    {
        text = this.gameObject.GetComponent<TMP_Text>();

        if (textOptionInfo.textFlashing == true)
        {
            StartCoroutine("Flashing");
        }
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

[System.Serializable]
public class UIOptionInfo
{
    public bool textFlashing;//�e�L�X�g�̓_��
}
