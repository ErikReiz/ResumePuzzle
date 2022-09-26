using System.IO;
using System.Xml.Serialization;

namespace ResumePuzzle.Data
{
	[System.Serializable]
	public struct SettingsPresset 
	{
		public int QualityPresset;

		public float ResolutionScale;
		public float SoundVolume;
		public float MusicVolume;
	}
	
	public static class XMLHelper
	{
		public static string Serialize<T>(T objectToSerialieze)
		{
			XmlSerializer serializer = new(typeof(T));
			StringWriter writer = new();
			serializer.Serialize(writer, objectToSerialieze);

			return writer.ToString();
		}

		public static T Deserealize<T>(string objectToDeserialize)
		{
			XmlSerializer serializer = new(typeof(T));
			StringReader reader = new(objectToDeserialize);

			return (T)serializer.Deserialize(reader);
		}
	}
}