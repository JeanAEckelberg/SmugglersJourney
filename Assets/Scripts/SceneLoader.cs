using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Image black;
    public Animator anim;

    public void LoadGame(){ StartCoroutine(Fade()); }

    IEnumerator Fade()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ExitGame(){ Application.Quit(); }
    public void PlayAgain(){ SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); }
}