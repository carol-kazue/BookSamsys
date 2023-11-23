namespace webApiBookSamsys.Infrastructure.MessagingHelper
{
    public class MessangingHelper<T>
    {
       public bool Success { get; set; }
       public string Message { get; set; }
       public T Obj { get; set; }
    }
}
