namespace Ietws
{
    // IET always returns this base info and wraps the array of results in response data
    public class IetResult<T> {
        public string ResponseDetails { get; set; }
        public int ResponseStatus { get; set; }
        
        public ResponseData<T> ResponseData { get; set; }
    }
}
