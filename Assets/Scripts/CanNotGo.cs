using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CanNotGo : MonoBehaviour
{
    /*public TextMeshProUGUI youGreatText;
    public float phrasetime ;*/
 

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        /*youGreatText.gameObject.SetActive(true);*/
        /*StartCoroutine(ReloadScene());*/
        
        /*SceneManager.LoadScene(SceneManager.GetActiveScene().name);*/

    }

    /*private IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }*/
}
