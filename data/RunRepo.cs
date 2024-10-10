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
        return _connection.QuerySingle<Run>("SELECT * FROM Runs WHERE Id = @id", new {id});
    }
    
    public void LogRun(Run run)
    {
        _connection.Execute("INSERT INTO Runs (Date, ElevationGain, Location, Distance, AvgHeartRate, RunType) " +
                            "VALUES (@date, @elevationGain, @location, @distance, @avgHeartRate, @runType);", new
        {
            date = run.Date, elevationGain = run.ElevationGain, location = run.Location, 
            distance = run.Distance, avgHeartRate = run.AvgHeartRate, runType = run.RunType
        });
    }

    public void UpdateRun(Run run)
    {
        _connection.Execute("UPDATE Runs SET Date = @date, ElevationGain = @elevationGain, Location = @location, " +
                            "Distance = @distance, AvgHeartRate = @avgHeartRate, RunType = @runType WHERE Id = @id", new
        {
            date = run.Date, elevationGain = run.ElevationGain, location = run.Location, distance = run.Distance, 
            avgHeartRate = run.AvgHeartRate, runType = run.RunType, id = run.Id
        });
    }

    public void DeleteRun(int id)
    {
        _connection.Execute("DELETE FROM Runs WHERE Id = @Id;", new { Id = id });
        // _connection.Execute("DELETE FROM runs WHERE DATE = @date;", new { date = run.Date });
    }

    public IEnumerable<RunDetail> GetRunDetailsByRunId(int runId)
    {
        return _connection.Query<RunDetail>("SELECT Mile, Pace, HeartRate FROM RunDetails WHERE RunId = @RunId",
            new { RunId = runId }).ToList();
    }
}