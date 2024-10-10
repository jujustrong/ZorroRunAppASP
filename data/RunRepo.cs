using System.Data;
using Dapper;
using MySql.Data.MySqlClient;
using ZorroASP.Models;

namespace ZorroASP.data;

public class RunRepo : IRunRepo
{
    private readonly MySqlConnection _connection;

    public RunRepo(MySqlConnection connection)
    {
        _connection = connection;
    }
    public IEnumerable<Run> GetAllRuns()
    {
        return _connection.Query<Run>("SELECT * FROM Runs;");
    }

    public Run GetRun(int id)
    {
        return _connection.QuerySingle<Run>("SELECT * FROM Runs WHERE Id = @id", new {Id = id});
    }
    
    public void LogRun(Run run)
    {
        _connection.Execute("INSERT INTO Runs (Date, ElevationGain, Location, Distance, AvgPace, AvgHeartRate, RunType) " +
                            "VALUES (@date, @elevationGain, @location, @distance, @avgPace, @avgHeartRate, @runType);", new
        {
            date = run.Date, elevationGain = run.ElevationGain, location = run.Location, 
            distance = run.Distance, avgPace = run.AvgPace, avgHeartRate = run.AvgHeartRate, runType = run.RunType
        });
    }

    public void UpdateRun(Run run)
    {
        _connection.Execute("UPDATE Runs SET Date = @date, ElevationGain = @elevationGain, Location = @location, " +
                            "Distance = @distance, AvgPace = @avgPace, AvgHeartRate = @avgHeartRate, RunType = @runType WHERE Id = @id", new
        {
            date = run.Date, elevationGain = run.ElevationGain, location = run.Location, distance = run.Distance, 
            avgPace = run.AvgPace, avgHeartRate = run.AvgHeartRate, runType = run.RunType, id = run.Id
        });
    }

    public void DeleteRun(int id)
    {
        _connection.Execute("DELETE FROM Runs WHERE Id = @Id;", new { Id = id });
        // _connection.Execute("DELETE FROM runs WHERE DATE = @date;", new { date = run.Date });
    }

    public void UpdateRunNotes(int runId, string notes)
    {
        _connection.Execute("UPDATE Runs SET Notes = @Notes WHERE Id = @Id", new
        {
            Notes = notes, Id = runId
        });
    }
}