using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Write_Dialogue : MonoBehaviour
{

    public TextMeshProUGUI Text_Component;
    public string[] Lines;
    public float Text_Speed;

    private int Index;

    // Start is called before the first frame update
    void OnEnable()
    {
        Index = 0;
        Text_Component.text = string.Empty;
        Start_Dialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            if(Text_Component.text == Lines[Index])
            {
                Next_Line();
            }
            else
            {
                StopAllCoroutines();
                Text_Component.text = Lines[Index];
            }
        }
    }

    void Start_Dialogue()
    {
        Index = 0;
        StartCoroutine(Type_Line());
    }
    
    IEnumerator Type_Line()
    {
        foreach (char c in Lines[Index].ToCharArray())
        {
            Text_Component.text += c;
            yield return new WaitForSeconds(Text_Speed);

        }
    }

    void Next_Line()
    {
        if(Index < Lines.Length-1)
        {
            Index++;
            Text_Component.text = string.Empty;
            StartCoroutine(Type_Line());

        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
