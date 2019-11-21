using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="State")]
public class State : ScriptableObject
{
    [TextArea(2,10)] [SerializeField] string storySectionTitle;
    [TextArea(14,10)] [SerializeField] string storyText;
    [SerializeField] State[] nextStates;

    public string GetStateStorySectionTitle()
    {
        return storySectionTitle;
    }

    public string GetStateStoryText()
    {
        return storyText;
    }

    public State[] GetState()
    {
        return nextStates;
    }
}
