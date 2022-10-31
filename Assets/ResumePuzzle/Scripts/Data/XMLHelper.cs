using ResumePuzzle.Interfaces;
using System.IO;
using System.Xml.Serialization;

namespace ResumePuzzle.Data
{
	public class XMLHelper : ISerializationHelper
	{
		public string Serialize<T>(T objectToSerialieze)
		{
			XmlSerializer serializer = new(typeof(T));
			StringWriter writer = new();
			serializer.Serialize(writer, objectToSerialieze);

			return writer.ToString();
		}

		public T Deserealize<T>(string objectToDeserialize)
		{
			XmlSerializer serializer = new(typeof(T));
			StringReader reader = new(objectToDeserialize);

			try
			{
				return (T)serializer.Deserialize(reader);
			}
			catch
			{
				return default;
			}
		}
	}
}