using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderController : MonoBehaviour
{
    [SerializeField] public Animator transition;
    [SerializeField] public float beforeTransitionTime = 0f;
    [SerializeField] public float transitionTime = 2f;
    [SerializeField] public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            beforeTransitionTime = 5f;
            if (player != null && player.endGame == true)
            {
                player.endGame = false;
                LoadNextLevel();
            }
        }
        else
        {
            if (Input.anyKey)
            {
                LoadNextLevel();
            }
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel((SceneManager.GetActiveScene().buildIndex + 1) % 3));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //yield return new WaitForSeconds(beforeTransitionTime);

        //Play animation
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(transitionTime);

        //Load Scene
        SceneManager.LoadScene(levelIndex);
    }
}
