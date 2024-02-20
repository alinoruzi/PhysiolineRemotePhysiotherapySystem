using AccountManagement.ApplicationContracts.SpecializedTitleAppServicesContracts.Commands;
using AccountManagement.ApplicationContracts.SpecializedTitleAppServicesContracts.DTOs;
using AccountManagement.ApplicationServices.Mappers;
using AccountManagement.Domain.Entities;
using AccountManagement.Domain.Repositories;
using Physioline.Framework.Application.ResultModels;
using System.Net;

namespace AccountManagement.ApplicationServices.SpecializedTitleAppServices.Commands
{
	public class EditSpecializedTitleByAdminAppService : IEditSpecializedTitleByAdminAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public EditSpecializedTitleByAdminAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<OperationResult> Run(EditSpecializedTitleDto dto, CancellationToken cancellationToken)
		{
			ResultMessage message;
			if (!await _unitOfWork.SpecializedTitleRepository
				    .IsExistAsync(cc
					    => cc.Id == dto.Id, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(SpecializedTitle), dto.Id);
				return OperationResult.Failed(message, HttpStatusCode.NotFound);
			}

			var specializedTitle = await _unitOfWork.SpecializedTitleRepository
				.GetAsync(dto.Id, cancellationToken);

			if (specializedTitle.Title != dto.Title)
				if (await _unitOfWork.SpecializedTitleRepository
					    .IsExistAsync(cc
						    => cc.Title == dto.Title, cancellationToken))
				{
					message = ResultMessage.AnUniquePropertyAlreadyExist(nameof(SpecializedTitle), nameof(SpecializedTitle.Title));
					return OperationResult.Failed(message, HttpStatusCode.BadRequest);
				}

			SpecializedTitleMapper.MapForEdit(specializedTitle, dto);

			_unitOfWork.SpecializedTitleRepository.Update(specializedTitle);

			await _unitOfWork.CommitAsync(cancellationToken);

			message = ResultMessage.SuccessfullyEdited(nameof(SpecializedTitle), specializedTitle.Id);
			return OperationResult.Success(message);
		}
	}
}
