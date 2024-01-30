using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.Commands
{
	public interface IAddCollectionCategoryByAdminAppService
	{
		Task<OperationResult> Run(AddCollectionCategoryDto dto,
			long userId, CancellationToken cancellationToken);
	}

}
