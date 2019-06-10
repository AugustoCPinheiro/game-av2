using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
  [SerializeField]
  private Image[] _livesSprites;

  [SerializeField]
  private Sprite[] _ammoSprites;
    
  public Image livesImageDisplay;

  [SerializeField]
  private Image _ammoDisplay;

  [SerializeField]
  private Image _menu;

  public Text scoreText;

  private Player player;

  private GameObject _missionText;
  void Start() {
    player = GameObject.Find("Player").GetComponent<Player>(); 
   
  }
  public void UpdateLives(int lives){
   _livesSprites[lives].enabled = false;
  }
  public void UpdateAmmo(int count)
  {
    _ammoDisplay.sprite  = _ammoSprites[count];    
  }
  public void UpdateScore(int points){
   scoreText.text = "Score: " + points;
  }

  //private void LateUpdate() {
   // UpdateAmmo(player.Ammo);
 // }
  
  public void SetupUIEndDefeat(){

  }

  public void SetupUIEndWin(){
    
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
  
   }
}
