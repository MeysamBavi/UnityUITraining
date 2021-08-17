using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTLTMPro;

public class TeamInfoController : MonoBehaviour
{

    public RTLTextMeshPro rank;
    public RTLTextMeshPro teamName;
    public RTLTextMeshPro score;


    public void SetInfo(int rank, string teamName, int score)
    {
        this.rank.text = rank.ToString();
        this.teamName.text = teamName;
        this.score.text = score.ToString();
    }

}
