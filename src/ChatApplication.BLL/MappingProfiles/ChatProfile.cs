﻿using AutoMapper;
using ChatApplication.BLL.Models.Chat;
using ChatApplication.DAL.Entities;

namespace ChatApplication.BLL.MappingProfiles;

public class GroupChatProfile: Profile
{
    public GroupChatProfile()
    {
        CreateMap<CreateChatModel, Chat>();
        CreateMap<Chat, ChatModel>();
    }
}