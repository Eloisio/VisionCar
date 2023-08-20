using VisionCar.Application.ViewModels;
using VisionCar.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using VisionCar.Application.ViewModels;
using System.Numerics;
using System;
using VisionCar.Core.Entities;
using VisionCar.Core.Repositories;
using System.Linq;
using System.Collections.Generic;

namespace VisionCar.Application.Queries.QueriesUser
{
    public class GetUsersEmpresaQueryHandler : IRequestHandler<GetUserEmpresaQuery, List<UserViewModel>>
    {
        private readonly IUserRepository _UserRepository;
        public GetUsersEmpresaQueryHandler(IUserRepository userRepository)
        {
            _UserRepository = userRepository;
        }

        public async Task<List<UserViewModel>> Handle(GetUserEmpresaQuery request, CancellationToken cancellationToken)
        {
            var user = await _UserRepository.GetAllAsync();

                user = user
                        .Where(p => p.IdEmpresa == request.IdEmpresa)
                        .ToList();

            var userViewModel = user
                        .Select(p => new UserViewModel(p.Id, p.IdEmpresa, p.Nome, p.Email, p.Senha, p.Data_add, p.Ativo, p.Master))
                        .ToList();

            return userViewModel;
        }
    }
}
