using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Openwrks.Business.Contracts.Interfaces;
using AutoMapper;
using Serilog;
using Openwrks.ViewModels.Models.Response.Generic;
using Openwrks.ViewModels.Models.Response.Bank;
using Openwrks.ViewModels.Models.Request.Bank;
using Openwrks.Core.Enums;
using Openwrks.Business.Models.Models.Bank;

namespace Openwrks.API.Controllers.v1
{
    [Route("api/bank/")]
    [ApiController]
    public class BankController : BaseController
    {
        private readonly IBankService _bankService;
        
        public BankController(IMapper mapper, ILogger log, IBankService bankService) : base(mapper, log)
        {
            _bankService = bankService;
        }
        
        /// <summary>
        /// Return list of banks
        /// </summary>
        /// <param name="model"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        [HttpGet()]
        [Produces("application/json", Type = typeof(ListViewModel<BankViewModel>))]
        public async Task<IActionResult> GetBanks([FromQuery] BankListRequestModel model, DataMode mode = DataMode.Full)
        {
            var filters = Mapper.Map<BankListQueryModel>(model);

            var banks = await _bankService.GetItemsAsync(filters, mode);
            var totalCount = await _bankService.CountAsync(filters);

            return await GetListViewModel(banks, model, totalCount);
        }

        /// <summary>
        /// Return single bank
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetBank")]
        [Produces("application/json", Type = typeof(ItemViewModel<BankViewModel>))]
        public async Task<IActionResult> GetBank(Guid id)
        {
            var bank = await _bankService.GetAsync(id);
            if (bank == null)
                return GetNotFound();

            var bankVm = Mapper.Map<BankViewModel>(bank);

            return await GetItemViewModel(bankVm);
        }

        /// <summary>
        /// Create new bank.
        /// </summary>
        /// <param name="bank"></param>
        /// <returns></returns>
        [HttpPost()]
        [Produces("application/json", Type = typeof(ItemViewModel<BankCreateModel>))]
        public async Task<IActionResult> CreateBank([FromBody] BankCreateRequestModel bank)
        {
            if (bank == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var bankDto = Mapper.Map<BankCreateModel>(bank);

            var newBankId = await _bankService.AddAsync(bankDto);

            return await GetCreatedRequestModel(bank, newBankId, "GetBank");
        }

        /// <summary>
        /// Update bank
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bank"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Produces("application/json", Type = null)]
        public async Task<IActionResult> UpdateBank(Guid id, [FromBody] BankCreateRequestModel bank)
        {
            if (bank == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var bankExists = await _bankService.ExistsAsync(id);
            if (!bankExists)
                return GetNotFound();


            var bankDto = Mapper.Map<BankCreateModel>(bank);
            await _bankService.UpdateAsync(id, bankDto);

            return NoContent();
        }


        /// <summary>
        /// Delete bank
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Produces("application/json", Type = null)]
        public async Task<IActionResult> DeleteBank(Guid id)
        {
            var bankExists = _bankService.ExistsAsync(id);
            if (!(await bankExists))
                return NotFound();

            await _bankService.DeleteAsync(id);

            return NoContent();
        }
    }
}
