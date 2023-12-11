using _07JP27.SystemPromptSwitchingGPTBot.SystemPrompt;

public class Default:IGptConfiguration
{
    public string Id => "default";
    public string Command => "default";
    public string DisplayName => "デフォルト";
    public string Description => "デフォルトのシステムプロンプト";
    public float Temperature => 0.0f;
    public int MaxTokens => 400;
    public string SystemPrompt => "You are an AI assistant. Help users accomplish their goals as quickly and easily as possible.";
}