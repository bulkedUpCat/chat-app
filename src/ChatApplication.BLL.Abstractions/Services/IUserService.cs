﻿using ChatApplication.Shared.Models;
using ChatApplication.Shared.Models.User;

namespace ChatApplication.BLL.Abstractions.Services;

public interface IUserService
{
    Task<IEnumerable<UserModel>> GetAllAsync(
        CancellationToken cancellationToken = default);
    
    Task<PagedList<UserModel>> GetAllByFilterAsync(
        UserFilterModel filterModel,
        CancellationToken cancellationToken = default);
    
    Task<IEnumerable<UserModel>> GetAllByChatIdAsync(
        int chatId,
        CancellationToken cancellationToken = default);
    
    Task<IEnumerable<UserModel>> GetAllExceptByChatIdAsync(
        int chatId,
        CancellationToken cancellationToken = default);
    
    Task<UserModel> GetByIdAsync(
        string id,
        CancellationToken cancellationToken = default);

    Task UpdateAsync(
        UpdateUserModel updateUserModel,
        CancellationToken cancellationToken = default);
}