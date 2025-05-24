namespace Module_7;

public class Repository
{
    private readonly string _filePath;

    public Repository(string filePath)
    {
        _filePath = filePath;
    }

    public Worker[] GetAllWorkers()
    {
        if (!File.Exists(_filePath))
            return new Worker[0];

        var workers = new List<Worker>();
        var lines = File.ReadAllLines(_filePath);

        foreach (var line in lines)
        {
            var data = line.Split('#');
            var worker = new Worker(
                int.Parse(data[0]),
                DateTime.Parse(data[1]),
                data[2],
                int.Parse(data[3]),
                int.Parse(data[4]),
                DateTime.Parse(data[5]),
                data[6]
            );
            workers.Add(worker);
        }

        return workers.ToArray();
    }

    public Worker GetWorkerById(int id)
    {
        var workers = GetAllWorkers();
        return workers.FirstOrDefault(w => w.Id == id);
    }

    public void AddWorker(Worker worker)
    {
        var workers = GetAllWorkers().ToList();
        worker.Id = workers.Count == 0 ? 1 : workers.Max(w => w.Id) + 1;
        workers.Add(worker);
        File.AppendAllText(_filePath, worker + Environment.NewLine);
    }

    public void DeleteWorker(int id)
    {
        var workers = GetAllWorkers().Where(w => w.Id != id).ToList();
        File.WriteAllLines(_filePath, workers.Select(w => w.ToString()));
    }

    public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
    {
        var workers = GetAllWorkers();
        return workers.Where(w => w.DateAdded >= dateFrom && w.DateAdded <= dateTo).ToArray();
    }

    public void SortWorkersByFIO()
    {
        var workers = GetAllWorkers().OrderBy(w => w.FIO).ToArray();
        File.WriteAllLines(_filePath, workers.Select(w => w.ToString()));
    }

    public void SortWorkersByID()
    {
        var workers = GetAllWorkers().OrderBy(w => w.Id).ToArray();
        File.WriteAllLines(_filePath, workers.Select(w => w.ToString()));
    }
}