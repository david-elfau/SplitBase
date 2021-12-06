using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NodeLabel : MonoBehaviour
{
    public Text TextLabel;
    public Node NodeAttached;
    // Start is called before the first frame update
    public void Initialize(Node objectAttached)
    {
        NodeAttached = objectAttached;

        SetLabelText();
        SetLabelPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if(NodeAttached.LifeCycle.IsRunning())
        {
            SetLabelText();
            SetLabelPosition();
        }        
    }

    void SetLabelPosition()
    {
        Vector3 textPos = Camera.main.WorldToScreenPoint(NodeAttached.transform.position);
        TextLabel.transform.position = textPos;
    }

    void SetLabelText()
    {
        TextLabel.text = ((int)NodeAttached.Power).ToString();
    }

}
