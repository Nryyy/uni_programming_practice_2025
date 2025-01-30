namespace HromadaWEB.Models.DTOs
{
    public class BaseResponseModel
    {
        public bool IsSuccess { get; set; }
        public string ErorMessage { get; set; }
        public object Data { get; set; }
    }
}
