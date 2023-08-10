﻿using VisionCar.Application.ViewModels;
using VisionCar.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using VisionCar.Application.ViewModels;
using System;
using VisionCar.Core.Entities;

namespace VisionCar.Application.Queries.QueriesUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserViewModel>
    {
        private readonly VisionCarDbContext _dbContext;
        public GetUserQueryHandler(VisionCarDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == request.Id);

            if (user == null)
            {
                return null;
            }

            return new UserViewModel(user.Id, user.IdEmpresa, user.Nome, user.Email, user.Senha, user.Data_add, user.Ativo, user.Master);
        }
    }
}