using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Transform m_canvas_main;
    public Transform m_canvas_gameover;
    protected Text m_text_score;
    protected Text m_text_best;
    protected Text m_text_life;

    protected int m_score = 0;
    public static int m_hiscore = 0;
    protected Player m_player;

    public AudioClip m_musicClip;

    protected AudioSource m_audio;
    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        m_audio = this.gameObject.AddComponent<AudioSource>();
        m_audio.clip = m_musicClip;
        m_audio.loop = true;
        m_audio.Play();

        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        m_text_score = m_canvas_main.transform.Find("Text_score").GetComponent<Text>();
        m_text_best = m_canvas_main.transform.Find("Text_best").GetComponent<Text>();
        m_text_life = m_canvas_main.transform.Find("Text_life").GetComponent<Text>();
        m_text_score.text = string.Format("分数 {0}", m_score);
        m_text_best.text = string.Format("最高分 {0}", m_hiscore);
        m_text_life.text = string.Format("生命 {0}", m_player.m_life);

        var restart_button = m_canvas_gameover.transform.Find("Button_restart").GetComponent<Button>();
        restart_button.onClick.AddListener(delegate ()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });
        m_canvas_gameover.gameObject.SetActive(false);
    }

    public void AddScore(int point)
    {
        m_score += point;
        if(m_hiscore < m_score)
        {
            m_hiscore = m_score;
        }
        m_text_best.text = string.Format("最高分 {0}", m_hiscore);
        m_text_score.text = string.Format("分数 {0}", m_score);
    }

    public void ChangeLife(int life)
    {
        m_text_life.text = string.Format("生命 {0}", life);
        if (life <= 0)
        {
            m_canvas_gameover.gameObject.SetActive(true);
        }
    }
}
