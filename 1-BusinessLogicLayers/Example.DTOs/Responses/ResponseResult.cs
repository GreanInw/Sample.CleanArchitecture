namespace Example.DTOs.Responses;
public class ResponseResult<TResult>
{
    public bool IsSuccess { get; set; }
    public TResult Result { get; set; }
}

public class ResponseResult : ResponseResult<object>
{

}