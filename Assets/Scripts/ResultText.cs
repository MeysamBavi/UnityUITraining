using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultText : MonoBehaviour
{

    Localize resultTextLocalize;
    string input;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        resultTextLocalize = GetComponent<Localize>();
    }

    public void SaveInput(string value)
    {
        input = value;
    }

    public void ConfirmPressed()
    {
        resultTextLocalize.SetKey(resultTextLocalize.GetLocalizedString().key, input);
        gameObject.SetActive(true);
    }
}
