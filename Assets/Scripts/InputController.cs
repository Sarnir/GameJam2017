using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
	public CommandRequirement[] commandsReqs;
	public bool enableDebugKeys;

	Dictionary<CommandType,AudioCommand> commands;

	static InputController instance;

	FFT audioInput;

	void Start ()
	{
		instance = this;
		commands = new Dictionary<CommandType, AudioCommand> ();
		audioInput = GetComponent<FFT> ();

		for (int i = 0; i < commandsReqs.Length; i++)
		{
			AddCommand(new AudioCommand(audioInput, commandsReqs[i]));
		}
	}

	void Update () {
		
	}

	void AddCommand(AudioCommand command)
	{
		commands.Add (command.Type, command);
	}

	public static bool IsConditionMet(CommandType type)
	{
		if (instance.commands.ContainsKey (type))
		{
			if (instance.enableDebugKeys)
			{
				if (Input.GetKeyDown (instance.commands [type].requirement.debugKey))
					return true;
			}

			return instance.commands [type].IsCalled ();
		}
		else
		{
			return false;
		}
	}
}
