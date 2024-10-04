using System;
using System.Collections.Generic;
using ZorroASP.Models;

namespace ZorroASP.data;

public interface IRunRepo
{
    public IEnumerable<Run> GetAllRuns();
    Run GetRun(int Id);
    void UpdateRun(Run run);
    public void LogRun(Run run);
    public void DeleteRun(int Id);






}