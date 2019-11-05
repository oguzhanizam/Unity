using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
    [TextArea(10,14)] [SerializeField] string storyText;
    [TextArea(3,14)] [SerializeField] string titleText;
    [SerializeField] State[] nextStates;

    public string GetStateStory (){
        return storyText;
    }

    public string GetStoryTitle (){
        return titleText;
    }

    public State[] GetNextStates (){
        return nextStates;
    }
}
