namespace WebApiBookSamsys.Infrastructure
{
    public class MenssageHelper
    {
        public class MessageHelper<T>
        {
            public bool Success { get; set; }
            public string Message { get; set; }
            public T Obj { get; set; }
        }
    }
}
