using AccountManagement.ApplicationContracts.SpecializedTitleAppServicesContracts.Commands;
using AccountManagement.Domain.Entities;
using AccountManagement.Domain.Repositories;
using Physioline.Framework.Application.ResultModels;
using System.Net;

namespace AccountManagement.ApplicationServices.SpecializedTitleAppServices.Commands
{
	public class DeleteSpecializedTitleByAdminAppService : IDeleteSpecializedTitleByAdminAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public DeleteSpecializedTitleByAdminAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<OperationResult> Run(long id, CancellationToken cancellationToken)
		{
			ResultMessage message;

			if (!await _unitOfWork.SpecializedTitleRepository
				    .IsExistAsync(cc
					    => cc.Id == id, cancellationToken))
			{
				message = ResultMessage.EntityNotFound(nameof(SpecializedTitle), id);
				return OperationResult.Failed(message, HttpStatusCode.NotFound);
			}

			var specializedTitle = await _unitOfWork.SpecializedTitleRepository
				.GetAsync(id, cancellationToken);

			if (await _unitOfWork.ExpertRepository.IsExistAsync(e=>e.SpecializedTitleId == specializedTitle.Id, cancellationToken))
			{
				message = ResultMessage.CategoryCanNotBeDelete();
				return OperationResult.Failed(message, HttpStatusCode.BadRequest);
			}

			specializedTitle.IsDeleted = true;
			_unitOfWork.SpecializedTitleRepository.Update(specializedTitle);
			await _unitOfWork.CommitAsync(cancellationToken);

			message = ResultMessage.SuccessfullyDeleted(nameof(SpecializedTitle), specializedTitle.Id);
			return OperationResult.Success(message);
		}
	}
}
