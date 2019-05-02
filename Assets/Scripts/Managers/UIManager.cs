using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
  [SerializeField]
  private Sprite[] _livesSprites;

  [SerializeField]
  private Sprite[] _ammoSprites;
    
  public Image livesImageDisplay;

  [SerializeField]
  private Image _ammoDisplay;

  [SerializeField]
  private Image _menu;

  public int score;

  public Text scoreText;

  
  public void UpdateLives(int lives){
    livesImageDisplay.sprite = _livesSprites[lives];
  }
  public void UpdateAmmo(int count)
  {
    _ammoDisplay.sprite = _ammoSprites[count];    
  }
  public void UpdateScore(int points){
    score += points;
   scoreText.text = "Score: " + score;
  }
   
   //public void SetupUIStart()
   //{
        
        //_menu.gameObject.SetActive(false);
       // livesImageDisplay.gameObject.SetActive(true);
     //   scoreText.gameObject.SetActive(true);
     
   //}

  public void Reload(bool isReloading){
    Animator imageAnimator = _ammoDisplay.GetComponent<Animator>(); 
    
    if(isReloading){
      imageAnimator.SetBool("Need_reload", isReloading);
    }else{
      imageAnimator.SetBool("Need_reload", isReloading);            
    }
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
