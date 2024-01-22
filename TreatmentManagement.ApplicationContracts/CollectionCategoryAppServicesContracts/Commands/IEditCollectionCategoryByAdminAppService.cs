using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.CollectionCategoryAppServicesContracts.Commands
{
	public interface IEditCollectionCategoryByAdminAppService
	{
		Task<OperationResult> Run(EditCollectionCategoryDto dto,
			CancellationToken cancellationToken);
	}
}
