using Microsoft.EntityFrameworkCore;
using Room2_NorthwindAPI.Data.Repositories;
using Room2_NorthwindAPI.Models;

namespace Room2_NorthwindAPI.Services;

public class NorthwindService : INorthwindService
{
    private readonly INorthwindRepository _repository;

    public NorthwindService(INorthwindRepository repository)
    {
        _repository = repository;
    }
   
    public async Task<bool> CreateAsync(Employee entity)
    {
        if(_repository is null)
        {
            return false;
        }
        _repository.Add(entity);
        await _repository.SaveAsync();
        return true;

    }

    public async Task<bool> DeleteAsync(int id)
    {
        var employeeToDelete = await _repository.FindAsync(id);

        if(employeeToDelete is null)
        {
            return false;
        }

        _repository.Remove(employeeToDelete);

        await _repository.SaveAsync();

        return true;


    }

    public async Task<IEnumerable<Employee>?> GetAllAsync()
    {
        if (_repository.IsNull)
        {
            return null;
        }
        else
        {
            return await _repository.GetAllAsync();
        }

    }

    public async Task<Employee?> GetAsync(int id)
    {
        if(_repository.IsNull)
        {
            return null;
        }

        Employee employee = await _repository.FindAsync(id);

        if(employee is null)
        {
            return null;
        }

        return employee;


    }

    public async Task<bool> UpdateAsync(int id, Employee entity)
    {
        var employeeToUpdate = await _repository.FindAsync(id);
        _repository.Update(employeeToUpdate);
        try
        {
            await _repository.SaveAsync();
        }
        catch(DbUpdateConcurrencyException)
        {
            if (!await EmployeeExists(id))
            {
                return false;
            }
            else
            {
                throw;
            }

        }

        return true;

    }

    private async Task<bool> EmployeeExists(int id)
    {
        return (await _repository.FindAsync(id)) is null;
    }
}
