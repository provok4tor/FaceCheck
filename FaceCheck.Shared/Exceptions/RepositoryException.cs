using FaceCheck.Shared.ResultCodes;

namespace FaceCheck.Shared.Exceptions;

public class RepositoryException : Exception
{
    public ResultCode? Code { get; set; }

    public RepositoryException(string message) : base(message)
    {

    }

    public RepositoryException(ResultCode code) : base(code.GetDescription())
    {
        Code = code;
    }
}