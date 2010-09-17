namespace Guardian.OpenPlatform.Async
{
    internal class AsyncSearchCallbackParameter
    {
        public LoadJsonDelegate Delegate { get; set; }
        public ContentSearchCallback CallbackFunction { get; set; }
    }
}
