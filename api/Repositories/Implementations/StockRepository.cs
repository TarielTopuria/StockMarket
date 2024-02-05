﻿using api.Data;
using api.DTOs.Stock;
using api.Models;
using api.Repositories.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace api.Repositories.Implementations
{
    public class StockRepository(AppDbContext context, IMapper mapper) : IStockRepository
    {
        private readonly AppDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<List<StockResponseDTO>?> GetStocksAsync()
        {
            var stocks = await _context.Stocks.Include(c => c.Comments).ToListAsync();
            
            if(stocks is null)
            {
                return null;
            }

            var result = _mapper.Map<List<StockResponseDTO>>(stocks);
            return result;
        }

        public async Task<StockResponseDTO?> GetStockByIdAsync(int id)
        {
            var stock = await _context.Stocks.Include(c => c.Comments).Where(x => x.Id == id).FirstOrDefaultAsync();
            
            if(stock is null)
            {
                return null;
            }

            var result = _mapper.Map<StockResponseDTO>(stock);

            return result;
        }

        public async Task<StockResponseDTO?> CreateStockAsync(StockRequestDTO stock)
        {
            var stockToCreate = _mapper.Map<Stock>(stock);
            
            await _context.Stocks.AddAsync(stockToCreate);

            var result = await _context.SaveChangesAsync();

            return result > 0 ? _mapper.Map<StockResponseDTO>(stockToCreate) : null;
        }

        public async Task<StockResponseDTO?> UpdateStockAsync(int id, UpdateStockRequestDTO request)
        {
            var stock = await _context.Stocks.Where(x => x.Id == id).FirstOrDefaultAsync();
            
            if(stock is null)
            {
                return null;
            }

            stock.Symbol = request.Symbol;
            stock.CompanyName = request.CompanyName;
            stock.Purchase = request.Purchase;
            stock.LastDiv = request.LastDiv;
            stock.Industry = request.Industry;
            stock.MarketCap = request.MarketCap;

            var changes = await _context.SaveChangesAsync();

            return changes > 0 ? _mapper.Map<StockResponseDTO>(stock) : new StockResponseDTO { };
        }

        public async Task<bool?> DeleteStock(int id)
        {
            var stock = await _context.Stocks.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (stock is null)
            {
                return null;
            }

            _context.Stocks.Remove(stock);

            var changes = await _context.SaveChangesAsync();

            return changes > 0;
        }
    }
}
