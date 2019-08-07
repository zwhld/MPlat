using System;
using System.Collections.Generic;
using Castle.Components.DictionaryAdapter;
using Camc.MES53.Friendships.Dto;

namespace Camc.MES53.Chat.Dto
{
    public class GetUserChatFriendsWithSettingsOutput
    {
        public DateTime ServerTime { get; set; }
        
        public List<FriendDto> Friends { get; set; }

        public GetUserChatFriendsWithSettingsOutput()
        {
            Friends = new EditableList<FriendDto>();
        }
    }
}