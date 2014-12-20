using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Main : MonoBehaviour {

    public GameTimer timer;

    public GameObject EnemyManagerPrefab;
    public GameObject PlayerPrefab;
    public Text RemainedTimeText;
    public Text TotalScoreText;

	// Use this for initialization
	void Start () {
        GameObject obj = Instantiate(EnemyManagerPrefab) as GameObject;
        obj.transform.parent = this.transform;

        EnemyManager em = obj.GetComponent<EnemyManager>();
        em.main = this;

        Player player = (Instantiate(PlayerPrefab) as GameObject).GetComponent<Player>();
        player.timer = timer;
	}
	
	// Update is called once per frame
	void Update () {

        timer.Seconds -= Time.deltaTime;

        int seconds = (int)Mathf.Floor(timer.Seconds);
        int min = seconds / 60;
        int sec = seconds % 60;
        RemainedTimeText.text = string.Format("TimeLimit {0}:{1}", min, sec);

        TotalScoreText.text = string.Format("TotalScore:{0}", TotalScore);
	}

    public int TotalScore { get; set; }

}
