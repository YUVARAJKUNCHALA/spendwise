using System.ComponentModel.DataAnnotations;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var transactions = new List<Transaction>();
app.MapGet("/api/summary", () => {
    var expenses = transactions.Where(x => x.Kind == "expense").Sum(x => x.Amount);
    var income = transactions.Where(x => x.Kind == "income").Sum(x => x.Amount);
    return Results.Ok(new { income, expenses, balance = income - expenses, byCategory = transactions.Where(x=>x.Kind=="expense").GroupBy(x=>x.Category).Select(x=>new { category=x.Key, total=x.Sum(t=>t.Amount) }) });
});
app.MapPost("/api/transactions", (CreateTransaction request) => {
    var errors=new List<ValidationResult>(); if(!Validator.TryValidateObject(request,new ValidationContext(request),errors,true)) return Results.ValidationProblem(errors.ToDictionary(e=>e.MemberNames.FirstOrDefault()??"request",e=>new[]{e.ErrorMessage!}));
    var item=new Transaction(Guid.NewGuid(),request.Description.Trim(),request.Category.Trim(),request.Kind,request.Amount,DateOnly.FromDateTime(DateTime.UtcNow));transactions.Add(item);return Results.Created($"/api/transactions/{item.Id}",item);
}); app.Run();
record Transaction(Guid Id,string Description,string Category,string Kind,decimal Amount,DateOnly PostedOn);
record CreateTransaction([property:Required,StringLength(80)]string Description,[property:Required,StringLength(30)]string Category,[property:RegularExpression("^(income|expense)$")]string Kind,[property:Range(0.01,1000000)]decimal Amount);
