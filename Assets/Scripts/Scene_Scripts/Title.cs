using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip titleSelect;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        GameManager.nowScene = "Title";
        GameManager.titleState = "Waiting";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && GameManager.titleState == "Waiting")
        {
            GameManager.titleState = "Loading";
            audioSource.PlayOneShot(titleSelect);
            StartCoroutine("LoadScene");
        }
    }

    IEnumerator LoadScene()
    {
        //コルーチン待機時間(2秒)
        yield return new WaitForSeconds(2);
        //Scene読み込み("StageSelect")
        SceneManager.LoadScene("StageSelect");
    }
}
