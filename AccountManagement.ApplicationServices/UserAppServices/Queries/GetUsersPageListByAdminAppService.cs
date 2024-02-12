using AccountManagement.ApplicationContracts.UserAppServicesContracts.DTOs;
using AccountManagement.ApplicationContracts.UserAppServicesContracts.Queries;
using AccountManagement.ApplicationServices.Mappers;
using AccountManagement.Domain.Enums;
using AccountManagement.Domain.Repositories;

namespace AccountManagement.ApplicationServices.UserAppServices.Queries
{
	public class GetUsersPageListByAdminAppService : IGetUsersPageListByAdminAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public GetUsersPageListByAdminAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<List<GetUserListItemDto>> Run(UserRole role, 
			int pageNumber, int pageSize, CancellationToken cancellationToken)
		{
			var users = await _unitOfWork.UserRepository.GetPageIncludePersonAsync(role, pageNumber, pageSize, cancellationToken);
			return users.Select(UserMapper.MapToItem).ToList();
		}
		
	}
}
