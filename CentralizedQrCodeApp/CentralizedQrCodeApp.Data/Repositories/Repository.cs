using CentralizedQrCodeApp.Data.DataModels;
using CentralizedQrCodeApp.Data.Repositories.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CentralizedQrCodeApp.Data.Repositories
{
    /// <summary>
    /// This is the base class that handles DatabaseComtext CRUD operations
    /// </summary>
    /// <typeparam name="TEntity">Entity type from database.</typeparam>
    public class Repository <TEntity> : IRepository <TEntity> where TEntity :class , new()
    {
        protected readonly QrCodeContext _context;

        public Repository(QrCodeContext context)
        {
            _context = context;
        }
      
        /// <summary>
        /// Gets all entityType objects from the database.
        /// </summary>
        /// <returns>IQueryable</returns>
        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return _context.Set<TEntity>();
            }
            catch(Exception e)
            {
                throw new Exception($"Couldn't retrieve entities: {e.Message}");
            }
        }

        /// <summary>
        /// Retireves entityType object based on id.
        /// </summary>
        /// <param name="id">Id of the object.</param>
        /// <returns>Task<TEntity></returns>
        public async Task<TEntity> GetAsync(int id)
        {
            try
            {
                return await _context.Set<TEntity>().FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entity: {ex.Message}");
            }
        }

        /// <summary>
        /// Creates a new entityType object into de database.
        /// </summary>
        /// <param name="entity">Object to be created.</param>
        /// <returns>Task<TEntity></returns>
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates the entityType object from the database. If object's "id" is "0", then a new object is created in the database.
        /// </summary>
        /// <param name="entity">Object to be updated.</param>
        /// <returns>Task<TEntity></returns>
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }

        /// <summary>
        /// Removes the entityType object from the database.
        /// </summary>
        /// <param name="entity">Object to be removed from the database.</param>
        /// <returns>Task</returns>
        public async Task DeleteAsync(TEntity entity)
        {
            try
            {
               //var result=await  _context.Set<TEntity>().FindAsync(id);
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't delete entity: {ex.Message}");
            }
        }
    }
}
