using System.Threading.Tasks;

namespace ResumePuzzle.Interfaces
{
    public interface IAddresableLoaderModel
    {
        public Task<T> LoadAsset<T>(string assetID);
        public void UnloadAsset();
    }
}

