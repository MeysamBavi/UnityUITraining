using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardController : MonoBehaviour
{
    public Transform scrollPanel;
    public GameObject teamInfoPrefab;
    public bool loadFromCSV = false;
    public TextAsset CSVFile;

    void Awake()
    {
        DestroyAllChildrenInScrollPanel();

        if (loadFromCSV)
        {
            var fields = RawCSVLoader.LoadCSV(CSVFile);
            foreach (string[] teamInfoArray in fields)
            {
                int rank = int.Parse(teamInfoArray[0]);
                int score = int.Parse(teamInfoArray[2]);
                InstantiateAndSetInfo(rank, teamInfoArray[1], score);
            }
            return;
        }

        for (int i = 0; i < 8; i++)
        {
            InstantiateAndSetInfo(i + 1, "Meysam", 1000 - i);
        }
    }

    private void DestroyAllChildrenInScrollPanel()
    {
        foreach (Transform child in scrollPanel.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void InstantiateAndSetInfo(int rank, string teamName, int score)
    {
        var createdTeamInfo = Instantiate(teamInfoPrefab, scrollPanel);
        var controller = createdTeamInfo.GetComponent<TeamInfoController>();
        controller.SetInfo(rank, teamName, score);
    }
}
