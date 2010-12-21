namespace Guardian.OpenPlatform.Async
{
    internal class AsyncItemCallbackParameter
    {
        public LoadJsonDelegate Delegate { get; set; }
        public ItemCallback CallbackFunction { get; set; }
    }
}
