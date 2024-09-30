using System.Data;
using Dapper;
using ZorroASP.Models;

namespace ZorroASP.data;

public class RunRepo : IRunRepo
{
    private readonly IDbConnection _connection;

    public RunRepo(IDbConnection connection)
    {
        _connection = connection;
    }
    public IEnumerable<Run> GetRuns()
    {
        return _connection.Query<Run>("SELECT * FROM Runs;");
    }

    public Run GetRun(int id)
    {
        return _connection.QuerySingle<Run>("SELECT * FROM Runs WHERE ID = @id", new {id});
    }

    public void UpdateRun(Run run)
    {
        _connection.Execute("UPDATE Runs SET Date = @date, Elevation = @elevation, Location = @location, " +
                            "Mileage = @mileage, HeartRate = @heartRate WHERE ID = @id", new
        {
            date = run.Date, elevation = run.Elevation, location = run.Location, mileage = run.Mileage, 
            heartRate = run.HeartRate
        });
    }

    public void LogRun(Run runToLog)
    {
        _connection.Execute("INSERT INTO Runs (UserID, Date, Elevation, Location, Mileage, HeartRate) " +
                            "VALUES (@userID, @date, @elevation, @location, @mileage, @heartRate);", new
        {
            date = runToLog.Date, elevation = runToLog.Elevation, location = runToLog.Location, 
            mileage = runToLog.Mileage, heartRate = runToLog.HeartRate, userID = runToLog.UserID
        });
    }
    
    public IEnumerable<RunType> GetRunTypes()
    {
        return _connection.Query<RunType>("SELECT * FROM RunTypes;");
    }

    public Run AssignRunType()
    {
        var typeList = GetRunTypes();
        var run = new Run();
        run.RunTypes = typeList;
        return run;
    } 

    public void DeleteRun(Run run)
    {
        _connection.Execute("DELETE FROM runs WHERE ID = @id;", new { id = run.ID });
        _connection.Execute("DELETE FROM Users WHERE ID = @id;", new { id = run.ID });
    }
}