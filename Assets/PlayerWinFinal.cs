using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerWinFinal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Win"))
        {
            //Debug.Log("Win");
            //Debug.LogError("Win");
            //SceneManager.LoadScene(2);

            fade();
            Invoke("win2", 2);
        }
    }

    void win2(){
            Debug.Log("Win2");
            Debug.LogError("Win2");
            SceneManager.LoadScene(5);

    }


void fade(){
        StartCoroutine(FadeAlphaToZero(GetComponent<SpriteRenderer>(), 2f));
        IEnumerator FadeAlphaToZero(SpriteRenderer renderer, float duration) {
        Color startColor = renderer.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0);
        float time = 0;
        while (time < duration) {
            time += Time.deltaTime;
            renderer.color = Color.Lerp(startColor, endColor, time/duration);
            yield return null;
}
        }
}
}