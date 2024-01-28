using AccountManagement.Domain.Repositories;

namespace AccountManagement.Infrastructure.EntityFrameworkCore.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AmContext _context;
		public UnitOfWork(AmContext context)
		{
			_context = context;
		}
		
		private IUserRepository _userRepository;
		public IUserRepository UserRepository
			=> _userRepository = _userRepository ?? new UserRepository(_context);
		
		
		private IAdminRepository _adminRepository;
		public IAdminRepository AdminRepository
			=> _adminRepository = _adminRepository ?? new AdminRepository(_context);


		private IExpertRepository _expertRepository;
		public IExpertRepository ExpertRepository
			=> _expertRepository = _expertRepository ?? new ExpertRepository(_context);


		private IClientRepository _clientRepository;
		public IClientRepository ClientRepository
			=> _clientRepository = _clientRepository ?? new ClientRepository(_context);


		private ISpecializedTitleRepository _specializedTitleRepository;
		public ISpecializedTitleRepository SpecializedTitleRepository
			=> _specializedTitleRepository = _specializedTitleRepository ?? new SpecializedTitleRepository(_context);
		
		
		public async Task<int> CommitAsync(CancellationToken cancellationToken)
			=> await _context.SaveChangesAsync(cancellationToken);
		
		public void Dispose()
			=> _context.Dispose();
	}

}
