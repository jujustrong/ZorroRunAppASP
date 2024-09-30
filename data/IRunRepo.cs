using System;
using System.Collections.Generic;
using ZorroASP.Models;

namespace ZorroASP.data;

public interface IRunRepo
{
    public IEnumerable<Run> GetRuns();
    Run GetRun(int id);
    void UpdateRun(Run run);
    public void LogRun(Run runToLog);
    public IEnumerable<RunType> GetRunTypes();
    public Run AssignRunType();
    public void DeleteRun(Run run);






}