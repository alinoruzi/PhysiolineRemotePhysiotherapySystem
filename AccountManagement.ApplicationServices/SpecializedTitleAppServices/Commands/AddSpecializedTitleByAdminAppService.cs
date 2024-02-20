using AccountManagement.ApplicationContracts.SpecializedTitleAppServicesContracts.Commands;
using AccountManagement.ApplicationContracts.SpecializedTitleAppServicesContracts.DTOs;
using AccountManagement.ApplicationServices.Mappers;
using AccountManagement.Domain.Entities;
using AccountManagement.Domain.Repositories;
using Physioline.Framework.Application.ResultModels;
using System.Net;

namespace AccountManagement.ApplicationServices.SpecializedTitleAppServices.Commands
{
	public class AddSpecializedTitleByAdminAppService : IAddSpecializedTitleByAdminAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public AddSpecializedTitleByAdminAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<OperationResult> Run(AddSpecializedTitleDto dto, long userId, CancellationToken cancellationToken)
		{
			ResultMessage message;

			if (await _unitOfWork.SpecializedTitleRepository
				    .IsExistAsync(cc
					    => cc.Title == dto.Title, cancellationToken))
			{
				message = ResultMessage.AnUniquePropertyAlreadyExist(nameof(SpecializedTitle), nameof(SpecializedTitle.Title));
				return OperationResult.Failed(message, HttpStatusCode.BadRequest);
			}

			var specializedTitle = SpecializedTitleMapper.Map(dto, userId);
			await _unitOfWork.SpecializedTitleRepository.CreateAsync(specializedTitle, cancellationToken);

			await _unitOfWork.CommitAsync(cancellationToken);

			message = ResultMessage.SuccessfullyAdded(nameof(SpecializedTitle), specializedTitle.Id);
			return OperationResult.Success(message);
		}
	}
}
