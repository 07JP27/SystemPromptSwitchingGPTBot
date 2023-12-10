using _07JP27.SystemPromptSwitchingGPTBot.SystemPrompt;

public class Sample:IGptConfiguration
{
    public string Id => "sample";
    public string Command => "sample";
    public string DisplayName => "サンプル";
    public string Description => "サンプルモードです。";
    public float Temperature => 0.5f;
    public int MaxTokens => 400;
    public string SystemPrompt => "You are an AI assistant. Help users accomplish their goals as quickly and easily as possible.";
}