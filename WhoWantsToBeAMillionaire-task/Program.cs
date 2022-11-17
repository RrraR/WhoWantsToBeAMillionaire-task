using Microsoft.EntityFrameworkCore;
using WhoWantsToBeAMillionaire_task.Service;
using WWTBAM.Data;
using WWTBAM.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<WWTBAMDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddTransient<IQuestionsRepository, QuestionsRepository>();
builder.Services.AddTransient<IAnswersRepository, AnswersRepository>();
builder.Services.AddTransient<IQuestionLevelRepository, QuestionLevelRepository>();
builder.Services.AddTransient<IWWTBAMGameService, WWTBAMGameService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


