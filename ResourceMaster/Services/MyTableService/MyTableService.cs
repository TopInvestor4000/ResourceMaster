using ResourceMaster.DAL.Repositories.MyTableRepository;
using ResourceMaster.Models;
using ResourceMaster.ViewModels;

namespace ResourceMaster.Services.MyTableService
{
    public class MyTableService
    {
        private readonly IMyTableRepository _repository;
        private readonly ILogger<MyTableService> _logger;

        public MyTableService(IMyTableRepository repository, ILogger<MyTableService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<MyTableViewModel>> GetAllAsync( )
        {

            _logger.LogInformation("GetAllAsync Method called");
            var myTableList =  await _repository.GetAllAsync();
            List<MyTableViewModel> resultList = new List<MyTableViewModel>();
            foreach (var table in myTableList)
            {
                var viewModel = new MyTableViewModel()
                {
                    Id = table.Id,
                    Age = table.Age
                };
                resultList.Add(viewModel);
            }
            return resultList;
        }

        public async Task AddAsync(MyTableViewModel myTable)
        {
            var newEntry = new MyTable()
            {
                Age = myTable.Age,
                Id = myTable.Id
            };

            await _repository.AddAsync(newEntry);
        }
    }
}
