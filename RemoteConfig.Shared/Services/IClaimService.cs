namespace RemoteConfig.Shared.Services
{
    public interface IClaimService
    {
        string GetClaim(string key);

        string GetUserId();

        string GetUserRole();
    }
}