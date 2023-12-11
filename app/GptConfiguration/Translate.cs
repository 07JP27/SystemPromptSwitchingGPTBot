using _07JP27.SystemPromptSwitchingGPTBot.SystemPrompt;

public class Translate:IGptConfiguration
{
    public string Id => "translate";
    public string Command => "translate";
    public string DisplayName => "翻訳";
    public string Description => "入力された文章を翻訳します";
    public float Temperature => 0.0f;
    public int MaxTokens => 1000;
    public string SystemPrompt => @"You are a professional translator. 
                                    Your job is to translate the input text into proper grammar while maintaining the meaning of the original text. If there are no specific instructions from the user, please translate the text into English. If the meaning is unclear, please ask the user in Japanese instead of guessing, and only proceed with the translation when sufficient information is available.
                                    Take a deep breath and work on this problem step-by-step.
                                    ";
}