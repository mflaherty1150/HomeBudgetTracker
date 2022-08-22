using AutoMapper;
using HomeBudget.Contracts;
using HomeBudget.Data;
using HomeBudget.Models.Place;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private Guid _userId;

        public PlaceService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PlaceListItem>> GetAllPlacesAsync()
        {
            var accounts = await _context.Places
                //.Where(x => x.OwnerId == _userId)
                .Select(entity => _mapper.Map<PlaceListItem>(entity))
                .ToListAsync();

            return accounts;
        }

        public async Task<PlaceDetail> GetPlaceByIdAsync(int id)
        {
            var account = await _context.Places
                .FirstOrDefaultAsync(entity => entity.Id == id/* && entity.OwnerId == _userId*/);

            return account is null ? null : _mapper.Map<PlaceDetail>(account);
        }

        public async Task<bool> CreatePlaceAsync(PlaceCreate model)
        {
            var accountEntity = _mapper.Map<PlaceCreate, PlaceEntity>(model/*, opt => opt.AfterMap((src, dest) => dest.OwnerId = _userId)*/);

            _context.Places.Add(accountEntity);

            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> UpdatePlaceAsync(PlaceEdit model)
        {
            if (model == null) return false;

            var accountIsUserOwned = await _context.Places.AnyAsync(account => account.Id == model.Id/* && account.OwnerId == _userId*/);

            //var accountToUpdate = await _context.Places.FindAsync(model.Id);

            //if (accountToUpdate.OwnerId != _userId) return false;

            if (!accountIsUserOwned) return false;

            var newPlace = _mapper.Map<PlaceEdit, PlaceEntity>(model/*, opt => opt.AfterMap((src, dest) => dest.OwnerId = _userId)*/);

            _context.Entry(newPlace).State = EntityState.Modified;
            //_context.Entry(newPlace).Property(e => e.CreationDate).IsModified = false;

            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeletePlaceAsync(int PlaceId)
        {
            var entity = await _context.Places.FindAsync(PlaceId);
            //if (entity?.OwnerId != _userId) return false;

            _context.Places.Remove(entity);

            return await _context.SaveChangesAsync() == 1;
        }

        public void SetUserId(Guid userId) => _userId = userId;
    }
}
