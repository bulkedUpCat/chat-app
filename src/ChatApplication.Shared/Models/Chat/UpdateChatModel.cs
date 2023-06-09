﻿using System.Text.Json.Serialization;

namespace ChatApplication.Shared.Models.Chat;

public class UpdateChatModel
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Name { get; set; }
    public int ChatTypeId { get; set; }
}