using UnityEngine;

[CreateAssetMenu(fileName = "InteractionNPC", menuName = "Scriptable Objects/InteractionNPC")]
public class InteractionNPC : ScriptableObject
{
    public string npcName;
    public Sprite profile;
    public string[] dialogueLines;
    public float dialogSpeed = 0.5f;
    public bool[] autoProgress;
    public float autoProgressDelay = 2f;

}
