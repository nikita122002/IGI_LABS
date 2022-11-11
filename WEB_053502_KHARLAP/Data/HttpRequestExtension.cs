namespace WEB_053502_KHARLAP.Data
{
    public static class HttpRequestExtension
    {
        public static bool IsAjaxRequest(this HttpRequest request)
        {
            if (request.Headers["x-requested-with"]
                .ToString().ToLower().Equals("xmlhttprequest"))
                return true;
            return false;
        }
    }
}
