using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneScript : MonoBehaviour
{
    public Animator fadeSystem; 
    public string sceneName;
public AudioClip doorSound; 


    private void Awake(){
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("MainPlayer")){
           
            StartCoroutine(loadNextScene());
        }
    }

    public IEnumerator loadNextScene(){
        AudioManagerScript.instance.PlayClipAt(doorSound,transform.position);
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(sceneName);
        if(sceneName == "LevelWin"){
            WinScript.instance.whenPlayerWin();  
        }
        AudioManagerScript.instance.PlayNextSong();
    }

}
