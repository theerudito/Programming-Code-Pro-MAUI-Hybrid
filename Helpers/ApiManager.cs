namespace ProgrammingCodePro.Helpers
{
    public class ApiManager
    {
        public string url { get; private set; } = string.Empty;

        public ApiManager()
        {
            //url = "https://localhost:44380";
            url = "https://programmingcode.web.byerudito.me";
        }
    }
}