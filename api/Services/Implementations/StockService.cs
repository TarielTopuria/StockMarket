using api.DTOs.Stock;
using api.Helpers;
using api.Models;
using api.Services.Interfaces;
using api.UOW.Interfaces;
using AutoMapper;

namespace api.Services.Implementations
{
    public class StockService(IUnitOfWork unitOfWork, IMapper mapper) : IStockService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<List<StockResponseDTO>> GetAllStocksAsync(QueryObject query)
        {
            var stocks = await _unitOfWork.Stocks.GetStocksAsync(query);
            return _mapper.Map<List<StockResponseDTO>>(stocks);
        }

        public async Task<StockResponseDTO?> GetStockByIdAsync(int id)
        {
            var stock = await _unitOfWork.Stocks.GetStockByIdAsync(id);
            return stock != null ? _mapper.Map<StockResponseDTO>(stock) : null;
        }

        public async Task<StockResponseDTO> CreateStockAsync(StockRequestDTO stockDTO)
        {
            var stock = _mapper.Map<Stock>(stockDTO);
            await _unitOfWork.Stocks.CreateStockAsync(stock);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<StockResponseDTO>(stock);
        }

        public async Task<StockResponseDTO?> UpdateStockAsync(int id, UpdateStockRequestDTO stockDTO)
        {
            var stock = await _unitOfWork.Stocks.GetStockByIdAsync(id);
            if (stock == null)
            {
                return null;
            }

            _mapper.Map(stockDTO, stock);
            _unitOfWork.Stocks.UpdateStock(stock);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<StockResponseDTO>(stock);
        }

        public async Task<bool> DeleteStockAsync(int id)
        {
            var success = await _unitOfWork.Stocks.DeleteStockAsync(id);
            if (success)
            {
                await _unitOfWork.CommitAsync();
                return true;
            }
            return false;
        }
    }
}
