var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//builder.Services.AddMvc();//я добавила

var app = builder.Build();


//app.UseDeveloperExceptionPage();
//app.UseStatusCodePages();
//app.UseStaticFiles();
//app.UseMvcWithDefaultRoute();

//Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//if (app.Environment.IsProduction())
//{
//    app.Run(async (contex) =>
//    {
//        await contex.Response.WriteAsync("hi");
//    });

//}


app.UseHttpsRedirection(); //--было изначально
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
