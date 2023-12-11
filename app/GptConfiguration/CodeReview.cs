using _07JP27.SystemPromptSwitchingGPTBot.SystemPrompt;

public class CodeReview:IGptConfiguration
{
    public string Id => "codereview";
    public string Command => "codereview";
    public string DisplayName => "コードレビュー";
    public string Description => "コードをレビューします";
    public float Temperature => 0.0f;
    public int MaxTokens => 1000;
    public string SystemPrompt => @"You are an excellent programmer. You are proficient in all programming languages in the world.
                                    Please review the code that will be entered from now on. When doing so, please comment on the parts that 'should definitely be corrected' and the parts that 'should be corrected depending on the case'. If there is insufficient information to conduct the review, please ask the user for more information instead of making assumptions.
                                    Take a deep breath and work on this problem step-by-step.
                                    Please conduct the conversation with the user in Japanese.
                                    ";
}