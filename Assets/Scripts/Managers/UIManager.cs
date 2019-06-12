using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
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

  private GameObject endgame;
  private Player player;

  private GameObject _missionText;

  private Button backButton;

  void Start() {
    player = GameObject.Find("Player").GetComponent<Player>(); 
    endgame = GameObject.Find("EndGame");
    backButton = GameObject.Find("BackButton").GetComponent<Button>();
    backButton.onClick.AddListener(() => BackClick());
    endgame.SetActive(false);
    
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

  public void SetupUIEndDefeat(){
    endgame.SetActive(true);
  }

  public void SetupUIEndWin(){
    endgame.SetActive(true);
    TextMeshProUGUI mesh = endgame.GetComponent<TextMeshProUGUI>();
    mesh.text = "Missao Cumprida";
  }

  public void Reload(bool isReloading){
    Animator imageAnimator = _ammoDisplay.GetComponent<Animator>(); 
    
    if(isReloading){
      imageAnimator.SetBool("Need_reload", isReloading);
    }else{
      imageAnimator.SetBool("Need_reload", isReloading);            
    }
  }

  private void BackClick(){
    Debug.Log("Clicou");
       SceneManager.LoadScene(0);
  }
}
