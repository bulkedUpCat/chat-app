﻿using ChatApplication.DAL.Entities;
using ChatApplication.DAL.Entities.Views;
using ChatApplication.Shared.Models;

namespace ChatApplication.DAL.Repositories.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllAsync(
        CancellationToken cancellationToken = default);
    Task<IEnumerable<UserView>> GetByFilterAsync(
        UserFilterModel filterModel,
        CancellationToken cancellationToken = default);
    Task<IEnumerable<User>> GetByChatIdAsync(
        int chatId,
        CancellationToken cancellationToken = default);
    Task<IEnumerable<User>> GetAllExceptByChatIdAsync(
        int chatId,
        CancellationToken cancellationToken = default);
    Task<int> GetTotalCountAsync(
        UserFilterModel filterModel,
        CancellationToken cancellationToken = default);
    Task<User?> GetByIdAsync(
        string id,
        CancellationToken cancellationToken = default);
    Task<User?> GetByEmailAsync(
        string email,
        CancellationToken cancellationToken = default);
    void Update(User user);
}