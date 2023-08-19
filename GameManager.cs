using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{   
   public GameObject GameOverCanvas;
   public GameObject[] characterPrefabs;
   private int selectedCharacterIndex = 0;
   public GameObject[] backgroundPrefabs; // Farklı arkaplan prefabları

    private void Start() 
    {
        Time.timeScale= 1;
        GameOverCanvas.SetActive(false);
        selectedCharacterIndex = UnityEngine.Random.Range(0, characterPrefabs.Length);
        SpawnCharacter();
        ChangeBackground();
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

    private void ChangeBackground()
    {
        int randomBackgroundIndex = Random.Range(0, backgroundPrefabs.Length);
        Destroy(GameObject.FindGameObjectWithTag("Background")); // Önceki arkaplanı sil
        Instantiate(backgroundPrefabs[randomBackgroundIndex]); // Yeni arkaplanı oluştur
    }

    
    
    /* public void Reset()
    {
        PlayerPrefs.DeleteKey(HIGH_SCORE_KEY);
    }
    */
        
}
