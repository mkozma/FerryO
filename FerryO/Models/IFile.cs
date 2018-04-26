namespace FerryO.Models
{
    public interface IFile
    {
        string Read();
        void Write(string json);
    }
}