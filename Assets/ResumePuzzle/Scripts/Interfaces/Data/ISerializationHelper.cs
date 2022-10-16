namespace ResumePuzzle.Interfaces
{
	public interface ISerializationHelper
	{
		public string Serialize<T>(T objectToSerialieze);
		public T Deserealize<T>(string objectToDeserialize);
	}
}