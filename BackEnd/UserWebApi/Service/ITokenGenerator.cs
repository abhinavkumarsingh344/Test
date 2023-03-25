namespace CourseApplicationWithWebApi.Service
{
    public interface ITokenGenerator
    {
        string GenerateToken(int id, string name);
        bool IsTokenValid(string userAudience, string userIssuer, string userSecretKey, string userToken);
    }

}

