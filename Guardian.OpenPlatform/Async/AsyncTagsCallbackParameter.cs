namespace Guardian.OpenPlatform.Async
{
    internal class AsyncTagsCallbackParameter
    {
        public LoadJsonDelegate Delegate { get; set; }
        public TagSearchCallback CallbackFunction { get; set; }
    }
}
