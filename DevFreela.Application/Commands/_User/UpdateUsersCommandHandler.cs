using VisionCar.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VisionCar.Core.Repositories;

namespace VisionCar.Application.Commands._User
{
    public class UpdateUsersCommandHandler : IRequestHandler<UpdateUsersCommand, Unit>
    {
        private readonly IUserRepository _userrepository;
        public UpdateUsersCommandHandler(IUserRepository userrepository)
        {
            _userrepository = userrepository;
        }

        public async Task<Unit> Handle(UpdateUsersCommand request, CancellationToken cancellationToken)
        {
            var user = await _userrepository.GetByIdAsync(request.id);

            user.Update(request.nome, request.email,request.ativo,request.senha);

            await _userrepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
