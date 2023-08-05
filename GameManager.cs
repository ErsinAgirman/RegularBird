using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{   
    public GameObject GameOverCanvas;
    // public const string HIGH_SCORE_KEY = "HighScore"; 
    // Highscore a reset atmak için ekledim
   
   public GameObject[] characterPrefabs;
   private int selectedCharacterIndex = 0;

    private void Start() 
    {
        Time.timeScale= 1;
        GameOverCanvas.SetActive(false);
        selectedCharacterIndex = UnityEngine.Random.Range(0, characterPrefabs.Length);
        SpawnCharacter();
    }
    public void GameOver()
    {
        GameOverCanvas.SetActive(true);
        Time.timeScale= 0;
    }

    public void Replay()
    {
            SceneManager.LoadScene(0);
    }


    private void SpawnCharacter()
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));

        GameObject newCharacter = Instantiate(characterPrefabs[selectedCharacterIndex]);
    }

    
    
    /* public void Reset()
    {
        PlayerPrefs.DeleteKey(HIGH_SCORE_KEY);
    }
    */
        
}
