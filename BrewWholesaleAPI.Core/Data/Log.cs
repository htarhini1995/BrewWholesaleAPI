namespace BrewWholesaleAPI.Core.Data;

public partial class Log
{
    public int Id { get; set; }

    public DateTime? Date { get; set; }

    public string? Message { get; set; }

    public string? Exception { get; set; }

    public void Insert()
    {
        using (var ctx = Configuration.OpenContext(false))
        {
            ctx.Logs.Add(this);
            ctx.SaveChanges();
        }
    }

}
