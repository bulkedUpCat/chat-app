﻿using ChatApplication.BLL.Models.Message;
using ChatApplication.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChatApplication.API.Controllers;

[ApiController]
[Route("api/messages")]
public class MessagesController: ControllerBase
{
    private readonly IMessageService _messageService;

    public MessagesController(IMessageService messageService)
    {
        _messageService = messageService;
    }

    [HttpGet("/api/chats/{chatId}/messages")]
    public async Task<IActionResult> GetByChatId(
        int chatId,
        CancellationToken cancellationToken)
    {
        var messages = await _messageService.GetMessagesByChatIdAsync(chatId, cancellationToken);
        return Ok(messages);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateMessageModel createMessageModel,
        CancellationToken cancellationToken)
    {
        var message = await _messageService.CreateMessageAsync(createMessageModel, cancellationToken);
        return Ok(message);
    }
}