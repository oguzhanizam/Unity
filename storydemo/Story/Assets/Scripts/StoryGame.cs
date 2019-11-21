using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryGame : MonoBehaviour
{

    [SerializeField] Text storyText;
    [SerializeField] Text storyTitle;
    [SerializeField] Text storySectionTitle;
    [SerializeField] State startingState;
    State state;

    // Start is called before the first frame update
    void Start()
    {
        state = startingState;
        storyTitle.text = "Dynamically Changeable Story Title";
        storyText.text = state.GetStateStoryText();
        storySectionTitle.text = state.GetStateStorySectionTitle();
    }

    // Update is called once per frame
    void Update()
    {
        ManageStates();
    }

    private void ManageStates()
    {
        var nextStates = state.GetState();

        for(int stateIndex = 0; stateIndex < nextStates.Length; stateIndex++){
            if(Input.GetKeyDown(KeyCode.Alpha1 + stateIndex)){
                state = nextStates[stateIndex];
            } else if(Input.GetKeyDown(KeyCode.Q)){
                state = startingState;
            }
        }
        
        storySectionTitle.text = state.GetStateStorySectionTitle();
        storyText.text = state.GetStateStoryText();
    }
}
