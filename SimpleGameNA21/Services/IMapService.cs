namespace SimpleGameNA21.Services
{
    public interface IMapService
    {
        (int width, int height) GetMap();
    }
}