using BepInEx;
using GorillaNetworking;
using Photon.Pun;
using System.IO;
using UnityEngine;

namespace GorillaMod
{
	[BepInPlugin("com.nova.gorillamodgui", "BasicGUI", "1.0.0")]
	public class Plugin : BaseUnityPlugin
	{
		private string RoomCode;
		private string PlayerName;
		public void OnGUI()
		{
            PlayerName = GUILayout.TextArea(PlayerName);
            if (GUILayout.Button("Change Name"))
            {
				PhotonNetwork.LocalPlayer.NickName = PlayerName;
				GorillaComputer.instance.currentName = PlayerName;
				PlayerPrefs.SetString("playerName", PlayerName);
				PlayerPrefs.Save();
            }

            if (GUILayout.Button("Disconnect"))
			{
				PhotonNetwork.Disconnect();
			}

			RoomCode = GUILayout.TextArea(RoomCode);
			if (GUILayout.Button("Join Room"))
			{
				PhotonNetworkController.Instance.AttemptToJoinSpecificRoom(RoomCode, JoinType.Solo);
			}
		}
	}
}
