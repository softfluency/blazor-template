namespace BlazeCore.Server;

public static class Utils
{
    public static string GenerateId()
    {
        return Ulid.NewUlid().ToString();
    }
}