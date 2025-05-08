using UnityEngine;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public enum GameState{
    Intro,
    Playing,
    Dead

    }
public class Gamecontroller : MonoBehaviour
{
    public TMP_Text Score;
    public static Gamecontroller Instance;
    public GameState State = GameState.Intro;
    public float PlayerTime;
    public GameObject IntroUI;
    public GameObject DeadUI;
    public GameObject enemySpawner;
    public GameObject foodSpawner;
    public GameObject goldSpawner;
    public int live = 3;
    public Player player;

    void Awake(){
        if(Instance == null){
            Instance = this;
        }
    }
    void Start()
    {
        IntroUI.SetActive(true);
    }
    float CalculateScore(){
        return Time.time - PlayerTime;
    }
   
    void SaveHighScore(){
        int score= Mathf.FloorToInt(CalculateScore());
        int currentHighScore = PlayerPrefs.GetInt("highScore");
        if(score > currentHighScore){
            PlayerPrefs.SetInt("highScore", score);
            PlayerPrefs.Save();  
        }
    }

    int GetHighScore(){
        return PlayerPrefs.GetInt("highScore");
    }

    void Update()
    {
        if(State == GameState.Playing){
            Score.text = "Score : " + Mathf.FloorToInt(CalculateScore());
        }else if(State == GameState.Dead){
             Score.text = "High Score : " + GetHighScore();
        }
        if(State == GameState.Intro && Input.GetKeyDown(KeyCode.Space)){
            State = GameState.Playing;
            IntroUI.SetActive(false);
            enemySpawner.SetActive(true);
            foodSpawner.SetActive(true);
            goldSpawner.SetActive(true);
            PlayerTime = Time.time;
        }
        if(State ==GameState.Playing&&live == 0){
            player.killPlayer();
            enemySpawner.SetActive(false);
            foodSpawner.SetActive(false);
            goldSpawner.SetActive(false);
            DeadUI.SetActive(true); 
            State = GameState.Dead;
        }
        if(State == GameState.Dead && Input.GetKeyDown(KeyCode.Space)){
            SceneManager.LoadScene("SampleScene");
        }
    }
}
