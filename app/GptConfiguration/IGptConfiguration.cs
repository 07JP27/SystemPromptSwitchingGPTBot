namespace _07JP27.SystemPromptSwitchingGPTBot.SystemPrompt
{
    public interface IGptConfiguration
    {
        public string Id { get; }
        public string Command { get; }
        public string DisplayName { get; }
        public string Description { get; }
        public string SystemPrompt { get; }
        public float Temperature { get;}
        public int MaxTokens { get; }
    }
}