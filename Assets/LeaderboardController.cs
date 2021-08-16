using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardController : MonoBehaviour
{
    public Transform scrollPanel;
    public GameObject teamInfoPrefab;


    void Awake()
    {
        foreach (Transform child in scrollPanel.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < 8; i++)
        {
            var createdTeamInfo = Instantiate(teamInfoPrefab, scrollPanel);
            var controller = createdTeamInfo.GetComponent<TeamInfoController>();
            controller.SetInfo(43, "Meysam", 1000);
        }
    }
}
