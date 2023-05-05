using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using FlappyBird.Core;

namespace FlappyBird.SystemSave
{
	public static class SaveSystem
	{
		public const string SAVE_NAME = "score.flappy";

		public static void SaveData(Score score)
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();

			using (var fileStream = File.Create(FilePath()))
			{
				PlayerData data = new PlayerData(score);
				binaryFormatter.Serialize(fileStream, data);
			}
		}

		public static PlayerData LoadData()
		{
			if (File.Exists(FilePath()))
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				using (FileStream stream = new FileStream(FilePath(), FileMode.Open))
				{
					PlayerData data = binaryFormatter.Deserialize(stream) as PlayerData;
					return data;
				}
			}
			else
			{
				Debug.LogError("Save file not found in: " + FilePath());
				return null;
			}
		}

		public static string FilePath()
		{
			return Path.Combine(Application.persistentDataPath, SAVE_NAME);
			//return "C:/Users/lazar/AppData/LocalLow/DefaultCompany/Flappy Bird/score.flappy";
		}
	} 
}
