using System.Collections.Generic;

public class ConversationData
{
    public string Timestamp { get; set; }
    public string ChannelId { get; set; }
    public string CurrentConfigId { get; set; }

    // 本来はOpenAIライブラリのChatRequestMessageのリストで持つと後々簡単だが、State管理でコンストラクタエラーが発生するので独自定義
    public List<GptMessage>  Messages { get; set; }
}

public class GptMessage
{
    public string Role { get; set; }
    public string Content { get; set; }
}

public class UserProfile
{
    public string Name { get; set; }
}