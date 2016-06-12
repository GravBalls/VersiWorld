using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class InstructionSceneController : MonoBehaviour
{
    public float SceneTime = 15;
    void Start()
    {
        StartCoroutine(SceneTimer());

    }

    IEnumerator SceneTimer()
    {
        yield return new WaitForSeconds(SceneTime);
        SceneManager.LoadScene("Init_Level");
    }
}
