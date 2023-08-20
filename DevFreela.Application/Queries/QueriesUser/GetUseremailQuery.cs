using VisionCar.Application.ViewModels;
using MediatR;

namespace VisionCar.Application.Queries.QueriesUser
{
    public class GetUseremailQuery : IRequest<UserViewModel>
    {
        public GetUseremailQuery(string email)
        {
            Email = email;
        }

        public string Email{ get; private set; }
    }
}
