using System;
using New.Monobehaviours;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class AICommandClip : PlayableAsset, ITimelineClipAsset
{
	[HideInInspector]
	public AICommandBehaviour template = new AICommandBehaviour ();

	public AICommand.CommandType commandType;
	public Vector3 targetPosition; //for movement
	public ExposedReference<ActorView> targetUnit; //for attacks

    public ClipCaps clipCaps
    {
		get { return ClipCaps.None; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<AICommandBehaviour>.Create(graph, template);
		AICommandBehaviour clone = playable.GetBehaviour();
		clone.commandType = commandType;
		clone.targetPosition = targetPosition;
		clone.targetUnit = targetUnit.Resolve(graph.GetResolver());
        return playable;

    }
}
