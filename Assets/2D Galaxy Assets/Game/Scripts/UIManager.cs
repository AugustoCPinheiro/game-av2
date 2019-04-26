using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Sprite[] _livesSprites;
    
    public Image livesImageDisplay;

    [SerializeField]
    private Image _menu;

    public int score;

    public Text scoreText;

   public void UpdateLives(int lives){
        livesImageDisplay.sprite = _livesSprites[lives];
   }

   public void UpdateScore(int points){
        score += points;
        scoreText.text = "Score: " + score;
   }
   
   public void SetupUIStart()
   {
        
        _menu.gameObject.SetActive(false);
        livesImageDisplay.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
     
   }
   public void SetupUIEnd()
   {
        score = 0;
        UpdateScore(0);
        _menu.gameObject.SetActive(true);
        livesImageDisplay.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
   }
}
