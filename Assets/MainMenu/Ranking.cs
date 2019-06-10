using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranking : MonoBehaviour
{

    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highScoreEntryTransformList;
    private HighScoreEntry newHighScore;

    private void Awake()
    {
        entryContainer = transform.Find("highScoreEntryContainer");
        entryTemplate = transform.Find("highScoreEntryTemplate");
        entryTemplate.gameObject.SetActive(false);

        string playerName = PlayerPrefs.GetString("playerName");

        newHighScore.score = GameManager.endScore;
        newHighScore.name = playerName;
        AddHighScoreEntry(newHighScore);

        string jsonString = PlayerPrefs.GetString("highScoreTable");
        HighScores highScores =  JsonUtility.FromJson<HighScores>(jsonString);
       

        for(int i = 0; i < highScores.highScoreEntryList.Count; i++)
        {
            for(int j = i + 1; i < highScores.highScoreEntryList.Count; j++)
            {
                if(highScores.highScoreEntryList[j].score > highScores.highScoreEntryList[i].score)
                {
                    HighScoreEntry tmp = highScores.highScoreEntryList[i];
                    highScores.highScoreEntryList[i] = highScores.highScoreEntryList[j];
                    highScores.highScoreEntryList[j] = tmp;
                }
            }
        }

        highScoreEntryTransformList = new List<Transform>();

        foreach(HighScoreEntry highScoreEntry in highScores.highScoreEntryList)
        {
            CreateHighScoreEntryTransform(highScoreEntry, entryContainer, highScoreEntryTransformList);
        }

    }

    private void CreateHighScoreEntryTransform(HighScoreEntry highScoreEntry, Transform container, List<Transform> transformList)
    {
        float templateheight = 20f;

        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateheight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        string rank = (transformList.Count + 1) + "º";
        string score = highScoreEntry.score + "";
        string name = highScoreEntry.name;

        entryTransform.Find("posText").GetComponent<TextEditor>().text = rank;
        entryTransform.Find("scoreText").GetComponent<TextEditor>().text = score;
        entryTransform.Find("nameText").GetComponent<TextEditor>().text = name;

        transformList.Add(entryTransform);
    }

    [System.Serializable]
    private class HighScoreEntry
    {
        public int score;
        public string name;
    }

    private void AddHighScoreEntry(HighScoreEntry newHighScoreEntry)
    {
        HighScoreEntry highScoreEntry = new HighScoreEntry { score = newHighScoreEntry.score, name = newHighScoreEntry.name };

        string jsonString = PlayerPrefs.GetString("highScoreTable");
        HighScores highScores = JsonUtility.FromJson<HighScores>(jsonString);

        highScores.highScoreEntryList.Add(highScoreEntry);

        string json = JsonUtility.ToJson(highScores);
        PlayerPrefs.SetString("highScoreTable", json);
        PlayerPrefs.Save();
    }

    private class HighScores
    {
        public List<HighScoreEntry> highScoreEntryList;
    }
}
