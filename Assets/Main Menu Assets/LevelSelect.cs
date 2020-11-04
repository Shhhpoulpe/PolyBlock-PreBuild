using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public int level;
    public Button button;

	void Start () {
		button = button.GetComponent<Button>();
		button.onClick.AddListener(TaskOnClick);
	}

    void TaskOnClick(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + level);
	}
}
