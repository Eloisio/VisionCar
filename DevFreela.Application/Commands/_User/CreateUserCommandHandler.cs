using VisionCar.Core.Entities;
using VisionCar.Infrastructure.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace VisionCar.Application.Commands._User
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly VisionCarDbContext _dbContext;
        public CreateUserCommandHandler(VisionCarDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new VisionCar.Core.Entities.User(request.id,request.idEmpresa ,request.nome, request.email,request.senha,request.data_add,request.ativo,request.Master);

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user.Id;
        }
    }
}
