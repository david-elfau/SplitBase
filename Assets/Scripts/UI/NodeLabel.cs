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
    }

    // Update is called once per frame
    void Update()
    {
        if(NodeAttached.LifeCycle.IsRunning())
        {
            Vector3 textPos = Camera.main.WorldToScreenPoint(NodeAttached.transform.position);
            TextLabel.text = ((int) NodeAttached.Power).ToString();
            TextLabel.transform.position = textPos;
        }        
    }
}
